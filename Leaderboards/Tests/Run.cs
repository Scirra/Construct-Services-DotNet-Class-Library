using ConstructServices.Common;
using ConstructServices.Common.Tests;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using ConstructServices.Authentication.Actions;
using ConstructServices.Authentication.Enums;
using ConstructServices.Leaderboards.Actions;
using ConstructServices.Leaderboards.Enums;

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
        DeletePlayerBan
    }

    [UsedImplicitly]
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey, Guid leaderboardID)
    {
        var results = new Dictionary<string, TestResult>();
        var service = new LeaderboardService(gameID, leaderboardID, apiKey);
        
        // Get player
        var authService = new Authentication.AuthenticationService(gameID, apiKey);
        var playerResponse = authService.ListPlayers(new Players.GetPlayersOptions(PlayerOrdering.Newest));
        if (playerResponse.Success)
        {
            var player = playerResponse.Players.First();
            if (player != null)
            {
                {
                    var createTeamResponse = service.CreateTeam(new Teams.CreateTeamOptions("Test Team"));
                    results[nameof(LeaderboardTest.CreateTeam)] = new TestResult(createTeamResponse);
                    if (createTeamResponse.Success)
                    {
                        var team = createTeamResponse.Team;

                        {
                            var response = service.ListTeams(new Teams.ListTeamOptions(GetTeamsOrdering.Newest), new PaginationOptions(1, 20));
                            results[nameof(LeaderboardTest.ListTeams)] = new TestResult(response);
                            if (response.Success)
                            {
                                if (response.Teams.All(c => c.ID != team.ID))
                                {
                                    results[nameof(LeaderboardTest.ListTeams)] = new TestResult(TestResultStatus.Failed, "Team not found.");
                                }
                            }
                        }

                        {
                            var response = service.GetTeam(team.ID);
                            results[nameof(LeaderboardTest.GetTeam)] = new TestResult(response);
                        }

                        {
                            var response = service.UpdateTeam(team.ID, new Teams.UpdateTeamOptions{Name = "New Team Name"});
                            results[nameof(LeaderboardTest.UpdateTeam)] = new TestResult(response);
                        }

                        {
                            var response = service.AssignPlayerToTeam(team.ID, player.ID);
                            results[nameof(LeaderboardTest.AssignPlayer)] = new TestResult(response);
                        }

                        {
                            var response = service.ListTeamPlayers(team.ID, new Teams.ListTeamPlayersOptions(TeamPlayersOrdering.PlayerName), new PaginationOptions(1, 20));
                            results[nameof(LeaderboardTest.ListPlayers)] = new TestResult(response);
                            if (response.Success)
                            {
                                if (response.Players.All(c => c.Player.ID != player.ID))
                                {
                                    results[nameof(LeaderboardTest.ListPlayers)] = new TestResult(TestResultStatus.Failed, "Team Player not found.");
                                }
                            }
                        }

                        {
                            var response = service.DeletePlayerFromTeam(team.ID, player.ID);
                            results[nameof(LeaderboardTest.RemovePlayer)] = new TestResult(response);
                        }

                        {
                            var response = service.DeleteTeam(team.ID);
                            results[nameof(LeaderboardTest.DeleteTeam)] = new TestResult(response);
                        }

                        // Bans
                        {
                            var response = service.CreateShadowBan(new ShadowBans.CreateIPShadowBanOptions(1));
                            results[nameof(LeaderboardTest.CreateIPBan)] = new TestResult(response);
                        }

                        {
                            var response = service.ListIPShadowBans(new ListShadowBanOptions(), new PaginationOptions(1, 20));
                            results[nameof(LeaderboardTest.ListIPBan)] = new TestResult(response);
                            if (response.Success)
                            {
                                if (response.Bans.All(c => c.IPHash != 1))
                                {
                                    results[nameof(LeaderboardTest.ListIPBan)] = new TestResult(TestResultStatus.Failed, "IP ban not found.");
                                }
                            }
                        }

                        {
                            var response = service.CreateShadowBan(new ShadowBans.CreatePlayerShadowBanOptions(player.ID));
                            results[nameof(LeaderboardTest.CreatePlayerBan)] = new TestResult(response);
                        }

                        {
                            var response = service.ListPlayerShadowBans(new ListShadowBanOptions(), new PaginationOptions(1, 20));
                            results[nameof(LeaderboardTest.ListPlayerBan)] = new TestResult(response);
                            if (response.Success)
                            {
                                if (response.Bans.All(c => c.Player.ID != player.ID))
                                {
                                    results[nameof(LeaderboardTest.ListPlayerBan)] = new TestResult(TestResultStatus.Failed, "Player ban not found.");
                                }
                            }
                        }

                        {
                            var response = service.DeleteShadowBan(new ShadowBans.DeleteIPShadowBanOptions("1.2.3.4"));
                            results[nameof(LeaderboardTest.DeleteIPBan)] = new TestResult(response);
                        }

                        {
                            var response = service.DeleteShadowBan(new ShadowBans.DeletePlayerShadowBanOptions(player.ID));
                            results[nameof(LeaderboardTest.DeletePlayerBan)] = new TestResult(response);
                        }
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