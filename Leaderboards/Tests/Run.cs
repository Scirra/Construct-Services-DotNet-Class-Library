using ConstructServices.Authentication.Actions;
using ConstructServices.Authentication.Enums;
using ConstructServices.Common;
using ConstructServices.Common.Tests;
using ConstructServices.Leaderboards.Actions;
using ConstructServices.Leaderboards.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConstructServices.Leaderboards.Tests;

public static class Run
{
    private enum LeaderboardTest
    {
        CreateTeam,
        ListTeams,
        GetTeam,
        UpdateTeam,
        AssignPlayer,
        ListPlayers,
        RemovePlayer,
        DeleteTeam,

        CreateIPBan,
        ListIPBan,
        DeleteIPBan,
        CreatePlayerBan,
        ListPlayerBan,
        DeletePlayerBan,

        CreateScore,
        AdjustScoreByID,
        AdjustScoreByPlayer,
        ListNewest,
        ListPlayerScores,
        ListScoreHistory,
        ListPlayersScoreHistory,
        ListScoreNeighbours,
        ListPlayerScoreNeighbours,
        ListScores,
        DeleteScore,
        DeletePlayerScores
    }

    [UsedImplicitly]
    public static List<Tuple<string, TestResult>> RunTests(Guid gameID, SecretAPIKey apiKey, Guid leaderboardID, Action<string> logger = null)
    {
        var results = new Dictionary<LeaderboardTest, TestResult>();
        var service = new LeaderboardService(gameID, leaderboardID, apiKey);

        // Get player
        var authService = new Authentication.AuthenticationService(gameID, apiKey);

        var sw = new Stopwatch();

        var playerResponse = authService.ListPlayers(new Players.ListPlayersOptions
        {
            Ordering = PlayerOrdering.Newest
        }, new PaginationOptions(1, 20));
        if (playerResponse.Success)
        {
            var player = playerResponse.Players.First();
            if (player != null)
            {
                {
                    sw.Start();
                    var createTeamResponse = service.CreateTeam("Test Team");
                    results[LeaderboardTest.CreateTeam] = new TestResult(createTeamResponse, sw);
                    if (createTeamResponse.Success)
                    {
                        var team = createTeamResponse.Team;

                        {
                            sw.Restart();
                            var response = service.ListTeams(new Teams.ListTeamOptions
                            {
                                Ordering = GetTeamsOrdering.Newest
                            }, new PaginationOptions(1, 20));
                            results[LeaderboardTest.ListTeams] = new TestResult(response, sw);
                            if (response.Success)
                            {
                                if (response.Teams.All(c => c.ID != team.ID))
                                {
                                    results[LeaderboardTest.ListTeams] = new TestResult(TestResultStatus.Failed, sw, "Team not found.");
                                }
                            }
                        }

                        {
                            sw.Restart();
                            var response = service.GetTeam(team.ID);
                            results[LeaderboardTest.GetTeam] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.UpdateTeam(team.ID, new Teams.UpdateTeamOptions{Name = "New Team Name"});
                            results[LeaderboardTest.UpdateTeam] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.AssignPlayerToTeam(team.ID, player.ID);
                            results[LeaderboardTest.AssignPlayer] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.ListTeamPlayers(team.ID, new Teams.ListTeamPlayersOptions
                            {
                                Ordering = TeamPlayersOrdering.PlayerName
                            }, new PaginationOptions(1, 20));
                            results[LeaderboardTest.ListPlayers] = new TestResult(response, sw);
                            if (response.Success)
                            {
                                if (response.Players.All(c => c.Player.ID != player.ID))
                                {
                                    results[LeaderboardTest.ListPlayers] = new TestResult(TestResultStatus.Failed, sw, "Team Player not found.");
                                }
                            }
                        }

                        {
                            sw.Restart();
                            var response = service.DeletePlayerFromTeam(team.ID, player.ID);
                            results[LeaderboardTest.RemovePlayer] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.DeleteTeam(team.ID);
                            results[LeaderboardTest.DeleteTeam] = new TestResult(response, sw);
                        }

                        // Bans
                        {
                            sw.Restart();
                            var response = service.CreateShadowBan(new ShadowBans.CreateIPShadowBanOptions(1));
                            results[LeaderboardTest.CreateIPBan] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.ListIPShadowBans(new PaginationOptions(1, 20));
                            results[LeaderboardTest.ListIPBan] = new TestResult(response, sw);
                            if (response.Success)
                            {
                                if (response.Bans.All(c => c.IPHash != 1))
                                {
                                    results[LeaderboardTest.ListIPBan] = new TestResult(TestResultStatus.Failed, sw, "IP ban not found.");
                                }
                            }
                        }

                        {
                            sw.Restart();
                            var response = service.CreateShadowBan(new ShadowBans.CreatePlayerShadowBanOptions(player.ID));
                            results[LeaderboardTest.CreatePlayerBan] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.ListPlayerShadowBans(new PaginationOptions(1, 20));
                            results[LeaderboardTest.ListPlayerBan] = new TestResult(response, sw);
                            if (response.Success)
                            {
                                if (response.Bans.All(c => c.Player.ID != player.ID))
                                {
                                    results[LeaderboardTest.ListPlayerBan] = new TestResult(TestResultStatus.Failed, sw, "Player ban not found.");
                                }
                            }
                        }

                        {
                            sw.Restart();
                            var response = service.DeleteShadowBan(new ShadowBans.DeleteIPShadowBanOptions(1));
                            results[LeaderboardTest.DeleteIPBan] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.DeleteShadowBan(new ShadowBans.DeletePlayerShadowBanOptions(player.ID));
                            results[LeaderboardTest.DeletePlayerBan] = new TestResult(response, sw);
                        }

                        // Scores
                        {
                            sw.Restart();
                            var createScoreResponse = service.CreateScore(player.ID, new Scores.CreateScoreOptions
                            {
                                RequesterIP = "1.2.3.4",
                                Score = 1000,
                                OptValue1 = 1,
                                OptValue2 = 5,
                                OptValue3 = 10
                            });
                            results[LeaderboardTest.CreateScore] = new TestResult(createScoreResponse, sw);
                            if (createScoreResponse.Success)
                            {
                                var score = createScoreResponse.Score;
                                
                                {
                                    sw.Restart();
                                    var response = service.AdjustScore(score.ID, new Scores.AdjustScoreOptions
                                    {
                                        Adjustment = 100,
                                        OptValue1 = 4
                                    });
                                    results[LeaderboardTest.AdjustScoreByID] = new TestResult(response, sw);
                                }
                                {
                                    sw.Restart();
                                    var response = service.AdjustBestScore(player.ID, new Scores.AdjustScoreOptions
                                    {
                                        Adjustment = 100,
                                        OptValue2 = 4
                                    });
                                    results[LeaderboardTest.AdjustScoreByPlayer] = new TestResult(response, sw);
                                }

                                {
                                    sw.Restart();
                                    var response = service.ListNewestScores(new Scores.ListNewestScoresOptions(), new PaginationOptions(1, 20));
                                    results[LeaderboardTest.ListNewest] = new TestResult(response, sw);
                                    if (response.Success)
                                    {
                                        if (response.Scores.All(c => c.ID != score.ID))
                                        {
                                            results[LeaderboardTest.ListNewest] = new TestResult(TestResultStatus.Failed, sw, "Score not found in newest.");
                                        }
                                    }
                                }

                                {
                                    sw.Restart();
                                    var response = service.ListPlayerScores(player.ID, new PaginationOptions(1, 20));
                                    results[LeaderboardTest.ListPlayerScores] = new TestResult(response, sw);
                                    if (response.Success)
                                    {
                                        if (response.Scores.All(c => c.ID != score.ID))
                                        {
                                            results[LeaderboardTest.ListPlayerScores] = new TestResult(TestResultStatus.Failed, sw, "Score not found in newest.");
                                        }
                                    }
                                }

                                {
                                    sw.Restart();
                                    var response = service.ListScoreHistory(score.ID);
                                    results[LeaderboardTest.ListScoreHistory] = new TestResult(response, sw);
                                }

                                {
                                    sw.Restart();
                                    var response = service.ListPlayersScoreHistory(player.ID);
                                    results[LeaderboardTest.ListPlayersScoreHistory] = new TestResult(response, sw);
                                }

                                {
                                    sw.Restart();
                                    var response = service.ListScoreNeighbours(score.ID, new Scores.ListScoreNeighbourOptions
                                    {
                                        CompareRanks = 5
                                    });
                                    results[LeaderboardTest.ListScoreNeighbours] = new TestResult(response, sw);
                                }

                                {
                                    sw.Restart();
                                    var response = service.ListPlayersScoreNeighbours(player.ID, new Scores.ListScoreNeighbourOptions
                                    {
                                        Range = 5
                                    });
                                    results[LeaderboardTest.ListPlayerScoreNeighbours] = new TestResult(response, sw);
                                }

                                {
                                    sw.Restart();
                                    var response = service.ListScores(new Scores.ListScoreOptions(), new PaginationOptions(1, 10));
                                    results[LeaderboardTest.ListScores] = new TestResult(response, sw);
                                }

                                {
                                    sw.Restart();
                                    var response = service.DeleteScore(score.ID);
                                    results[LeaderboardTest.DeleteScore] = new TestResult(response, sw);
                                }

                                {
                                    sw.Restart();
                                    var response = service.DeletePlayerScores(player.ID);
                                    results[LeaderboardTest.DeletePlayerScores] = new TestResult(response, sw);
                                }
                            }
                        }
                    }
                }
            }
        }

        var tests = Extensions.ToList<LeaderboardTest>();
        foreach (var test in tests.Where(test => !results.ContainsKey(test)))
        {
            results[test] = new TestResult();
        }
        return results
            .Select(c=> 
                new Tuple<string, TestResult>(c.Key.ToString(), c.Value)
            )
            .ToList();
    }
}