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
        ListScoreNeighbours,
        ListScores,
        DeleteScore
    }

    [UsedImplicitly]
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey, Guid leaderboardID)
    {
        var results = new Dictionary<string, TestResult>();
        var service = new LeaderboardService(gameID, leaderboardID, apiKey);

        // Get player
        var authService = new Authentication.AuthenticationService(gameID, apiKey);

        var sw = new Stopwatch();

        var playerResponse = authService.ListPlayers(new Players.GetPlayersOptions(PlayerOrdering.Newest));
        if (playerResponse.Success)
        {
            var player = playerResponse.Players.First();
            if (player != null)
            {
                {
                    sw.Start();
                    var createTeamResponse = service.CreateTeam(new Teams.CreateTeamOptions("Test Team"));
                    results[nameof(LeaderboardTest.CreateTeam)] = new TestResult(createTeamResponse, sw);
                    if (createTeamResponse.Success)
                    {
                        var team = createTeamResponse.Team;

                        {
                            sw.Restart();
                            var response = service.ListTeams(new Teams.ListTeamOptions(GetTeamsOrdering.Newest), new PaginationOptions(1, 20));
                            results[nameof(LeaderboardTest.ListTeams)] = new TestResult(response, sw);
                            if (response.Success)
                            {
                                if (response.Teams.All(c => c.ID != team.ID))
                                {
                                    results[nameof(LeaderboardTest.ListTeams)] = new TestResult(TestResultStatus.Failed, sw, "Team not found.");
                                }
                            }
                        }

                        {
                            sw.Restart();
                            var response = service.GetTeam(team.ID);
                            results[nameof(LeaderboardTest.GetTeam)] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.UpdateTeam(team.ID, new Teams.UpdateTeamOptions{Name = "New Team Name"});
                            results[nameof(LeaderboardTest.UpdateTeam)] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.AssignPlayerToTeam(team.ID, player.ID);
                            results[nameof(LeaderboardTest.AssignPlayer)] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.ListTeamPlayers(team.ID, new Teams.ListTeamPlayersOptions(TeamPlayersOrdering.PlayerName), new PaginationOptions(1, 20));
                            results[nameof(LeaderboardTest.ListPlayers)] = new TestResult(response, sw);
                            if (response.Success)
                            {
                                if (response.Players.All(c => c.Player.ID != player.ID))
                                {
                                    results[nameof(LeaderboardTest.ListPlayers)] = new TestResult(TestResultStatus.Failed, sw, "Team Player not found.");
                                }
                            }
                        }

                        {
                            sw.Restart();
                            var response = service.DeletePlayerFromTeam(team.ID, player.ID);
                            results[nameof(LeaderboardTest.RemovePlayer)] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.DeleteTeam(team.ID);
                            results[nameof(LeaderboardTest.DeleteTeam)] = new TestResult(response, sw);
                        }

                        // Bans
                        {
                            sw.Restart();
                            var response = service.CreateShadowBan(new ShadowBans.CreateIPShadowBanOptions(1));
                            results[nameof(LeaderboardTest.CreateIPBan)] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.ListIPShadowBans(new PaginationOptions(1, 20));
                            results[nameof(LeaderboardTest.ListIPBan)] = new TestResult(response, sw);
                            if (response.Success)
                            {
                                if (response.Bans.All(c => c.IPHash != 1))
                                {
                                    results[nameof(LeaderboardTest.ListIPBan)] = new TestResult(TestResultStatus.Failed, sw, "IP ban not found.");
                                }
                            }
                        }

                        {
                            sw.Restart();
                            var response = service.CreateShadowBan(new ShadowBans.CreatePlayerShadowBanOptions(player.ID));
                            results[nameof(LeaderboardTest.CreatePlayerBan)] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.ListPlayerShadowBans(new PaginationOptions(1, 20));
                            results[nameof(LeaderboardTest.ListPlayerBan)] = new TestResult(response, sw);
                            if (response.Success)
                            {
                                if (response.Bans.All(c => c.Player.ID != player.ID))
                                {
                                    results[nameof(LeaderboardTest.ListPlayerBan)] = new TestResult(TestResultStatus.Failed, sw, "Player ban not found.");
                                }
                            }
                        }

                        {
                            sw.Restart();
                            var response = service.DeleteShadowBan(new ShadowBans.DeleteIPShadowBanOptions(1));
                            results[nameof(LeaderboardTest.DeleteIPBan)] = new TestResult(response, sw);
                        }

                        {
                            sw.Restart();
                            var response = service.DeleteShadowBan(new ShadowBans.DeletePlayerShadowBanOptions(player.ID));
                            results[nameof(LeaderboardTest.DeletePlayerBan)] = new TestResult(response, sw);
                        }

                        // Scores
                        {
                            sw.Restart();
                            var createScoreResponse = service.CreateScore(new Scores.CreateScoreOptions(player.ID, "1.1.1.1", 1000, 1, 2, 3));
                            results[nameof(LeaderboardTest.CreateScore)] = new TestResult(createScoreResponse, sw);
                            if (createScoreResponse.Success)
                            {
                                var score = createScoreResponse.Score;
                                
                                {
                                    sw.Restart();
                                    var response = service.AdjustScore(new Scores.AdjustScoreByIDOptions(score.ID)
                                    {
                                        Adjustment = 100,
                                        OptValue1 = 4
                                    });
                                    results[nameof(LeaderboardTest.AdjustScoreByID)] = new TestResult(response, sw);
                                }
                                {
                                    sw.Restart();
                                    var response = service.AdjustScore(new Scores.AdjustScoreByIDOptions(player.ID)
                                    {
                                        Adjustment = 100,
                                        OptValue2 = 4
                                    });
                                    results[nameof(LeaderboardTest.AdjustScoreByPlayer)] = new TestResult(response, sw);
                                }

                                {
                                    sw.Restart();
                                    var response = service.ListNewestScores(new Scores.ListNewestScoresOptions(), new PaginationOptions(1, 20));
                                    results[nameof(LeaderboardTest.ListNewest)] = new TestResult(response, sw);
                                    if (response.Success)
                                    {
                                        if (response.Scores.All(c => c.ID != score.ID))
                                        {
                                            results[nameof(LeaderboardTest.ListNewest)] = new TestResult(TestResultStatus.Failed, sw, "Score not found in newest.");
                                        }
                                    }
                                }

                                {
                                    sw.Restart();
                                    var response = service.ListPlayerScores(player.ID, new PaginationOptions(1, 20));
                                    results[nameof(LeaderboardTest.ListPlayerScores)] = new TestResult(response, sw);
                                    if (response.Success)
                                    {
                                        if (response.Scores.All(c => c.ID != score.ID))
                                        {
                                            results[nameof(LeaderboardTest.ListPlayerScores)] = new TestResult(TestResultStatus.Failed, sw, "Score not found in newest.");
                                        }
                                    }
                                }
                            }
                        }


                        /*
                           ,
                           ListScoreHistory,
                           ListScoreNeighbours,
                           ListScores,
                           DeleteScore,
                         */
                    }
                }
            }
        }


        var testNames = Enum.GetNames(typeof(LeaderboardTest));
        foreach (var testName in testNames)
        {
            if (!results.ContainsKey(testName))
            {
                results[testName] = new TestResult();
            }
        }
        return results;
    }
}