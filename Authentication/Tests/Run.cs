using ConstructServices.Common;
using ConstructServices.Common.Tests;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ConstructServices.Authentication.Actions;
using ConstructServices.Authentication.Enums;
using ConstructServices.Authentication.Objects;

namespace ConstructServices.Authentication.Tests;

public static class Run
{
    private enum AuthTest
    {
        Login,
        LoginPoll,
        Link,
        LinkPoll,
        GetSession,
        RefreshSession,
        EndSession,

        CreatePlayer,
        ListNewestPlayers,
        ListMostRecentlyActivePlayers,
        ListPlayersAlphabetically,
        ListPlayersByID,
        GetPlayerByID,
        GetPlayerByPlayerName,
        ChangePlayerName,
        GetPlayerByUpdatedName,
        GetExpandedPlayer,
        SetUsernamePassword,
        SetUsername,
        SetPassword,
        ForgottenPassword,
        SetEmailAddress,
        SetRestrictions,
        SetAvatarByURL,
        SetAvatarByBase64,
        DeleteAvatar,
        DeletePlayer,
    }

    [UsedImplicitly]
    public static List<Tuple<string, TestResult>> RunTests(Guid gameID, SecretAPIKey apiKey, Action<string> logger = null)
    {
        var results = new Dictionary<AuthTest, TestResult>();
        var service = new AuthenticationService(gameID, apiKey);

        var sw = new Stopwatch();
        sw.Start();

        // CREATE NEW PLAYER
        var playerName = "Test" + new Random().Next(0, 10000);
        var createResult = service.RegisterPlayer(new Players.RegisterPlayerOptions
        {
            PlayerName = playerName
        });
        results[AuthTest.CreatePlayer] = new TestResult(createResult, sw);

        if (createResult.Success)
        {
            var player = createResult.Player;

            var playerService = new PlayerAuthenticationService(gameID, new SessionKey(createResult.Session.Key));
            
            // LOGIN
            {
                sw.Restart();
                var result = playerService.Login(LoginProvider.Discord);
                results[AuthTest.Login] = new TestResult(result, sw);
                if (result.Success)
                {
                    var pollToken = result.PollToken;

                    // LOGIN POLL
                    {
                        sw.Restart();
                        var pollResult = playerService.LoginPoll(pollToken);
                        results[AuthTest.LoginPoll] = new TestResult(pollResult, sw);
                    }
                }
            }
            
            // LINK
            {
                sw.Restart();
                var result = playerService.LinkLoginProvider(LoginProvider.Apple);
                results[AuthTest.Link] = new TestResult(result, sw);
                if (result.Success)
                {
                    var pollToken = result.PollToken;

                    // LINK POLL
                    {
                        sw.Restart();
                        var pollResult = playerService.LinkPoll(pollToken);
                        results[AuthTest.LinkPoll] = new TestResult(pollResult, sw);
                    }
                }
            }

            // GET SESSION
            {
                sw.Restart();
                var result = playerService.GetSession();
                results[AuthTest.GetSession] = new TestResult(result, sw);
            }

            // REFRESH SESSION
            {
                sw.Restart();
                var result = playerService.RefreshSession();
                results[AuthTest.RefreshSession] = new TestResult(result, sw);
            }

            // END SESSION
            {
                sw.Restart();
                var result = playerService.EndSession();
                results[AuthTest.EndSession] = new TestResult(result, sw);
            }

            // LIST NEWEST PLAYERS
            {
                sw.Restart();
                var result = service.ListPlayers(
                    new Players.ListPlayersOptions
                    {
                        Ordering = PlayerOrdering.Newest
                    },
                    new PaginationOptions(1, 20)
                );
                results[AuthTest.ListNewestPlayers] = new TestResult(result, sw);
                if (result.Success && result.Players.All(c => c.ID != player.ID))
                {
                    results[AuthTest.ListNewestPlayers] = new TestResult(TestResultStatus.Failed, sw, "New player ID not found.");
                }
            }

            // LIST RECENTLY ACTIVE PLAYERS
            {
                sw.Restart();
                var result = service.ListPlayers(
                    new Players.ListPlayersOptions
                    {
                        Ordering = PlayerOrdering.MostRecentlyActive
                    },
                    new PaginationOptions(1, 20)
                );
                results[AuthTest.ListMostRecentlyActivePlayers] = new TestResult(result, sw);
                if (result.Success && result.Players.All(c => c.ID != player.ID))
                {
                    results[AuthTest.ListMostRecentlyActivePlayers] = new TestResult(TestResultStatus.Failed, sw, "New player ID not found.");
                }
            }

            // LIST PLAYERS ALPHABETICALLY
            {
                sw.Restart();
                var result = service.ListPlayers(
                    new Players.ListPlayersOptions
                    {
                        Ordering = PlayerOrdering.AZ
                    },
                    new PaginationOptions(1, 20)
                );
                results[AuthTest.ListPlayersAlphabetically] = new TestResult(result, sw);
            }

            // LIST PLAYERS BY ID
            {
                sw.Restart();
                var result = service.ListPlayers(
                    new Players.ListPlayersOptions
                    {
                        PlayerIDs = [player.ID]
                    },
                    new PaginationOptions(1, 20)
                );
                results[AuthTest.ListPlayersByID] = new TestResult(result, sw);
                if (result.Success && result.Players.All(c => c.ID != player.ID))
                {
                    results[AuthTest.ListPlayersByID] = new TestResult(TestResultStatus.Failed, sw, "New player ID not found.");
                }
            }

            // GET PLAYER BY ID
            {
                sw.Restart();
                var result = service.GetPlayer(player.ID);
                results[AuthTest.GetPlayerByID] = new TestResult(result, sw);
                if (result.Success && result.Player == null)
                {
                    results[AuthTest.GetPlayerByID] = new TestResult(TestResultStatus.Failed, sw);
                }
            }

            // GET PLAYER BY PLAYER NAME
            {
                sw.Restart();
                var result = service.GetPlayer(playerName);
                results[AuthTest.GetPlayerByPlayerName] = new TestResult(result, sw);
                if (result.Success && result.Player == null)
                {
                    results[AuthTest.GetPlayerByPlayerName] = new TestResult(TestResultStatus.Failed, sw);
                }
            }

            // CHANGE PLAYER NAME
            var newPlayerName = "Test" + new Random().Next(0, 10000);
            {
                sw.Restart();
                var result = service.ChangePlayerName(player.ID, newPlayerName);
                results[AuthTest.ChangePlayerName] = new TestResult(result, sw);
            }

            // GET PLAYER BY PLAYER NAME
            {
                sw.Restart();
                var result = service.GetPlayer(newPlayerName);
                results[AuthTest.GetPlayerByUpdatedName] = new TestResult(result, sw);
                if (result.Success && result.Player == null)
                {
                    results[AuthTest.GetPlayerByUpdatedName] = new TestResult(TestResultStatus.Failed, sw);
                }
            }

            // GET EXPANDED PLAYER
            {
                sw.Restart();
                var result = service.GetExpandedPlayer(player.ID);
                results[AuthTest.GetExpandedPlayer] = new TestResult(result, sw);
            }

            // SET USERNAME/PASSWORD
            {
                sw.Restart();
                var result = service.SetUsernameAndPassword(player.ID, "Test" + new Random().Next(0, 10000), "abc123#AB£");
                results[AuthTest.SetUsernamePassword] = new TestResult(result, sw);
            }

            // SET PASSWORD
            {
                sw.Restart();
                var result = service.ChangePassword(player.ID, "abcdEE1234###£");
                results[AuthTest.SetPassword] = new TestResult(result, sw);
            }

            // SET USERNAME
            {
                sw.Restart();
                var result = service.ChangeUsername(player.ID, "Test" + new Random().Next(0, 10000));
                results[AuthTest.SetUsername] = new TestResult(result, sw);
            }
            
            // FORGOTTEN PASSWORD
            {
                sw.Restart();
                var result = service.RequestForgottenPasswordEmail("testemail@construct.ner");
                results[AuthTest.ForgottenPassword] = new TestResult(result, sw);
            }

            // SET EMAIL ADDRESS
            {
                sw.Restart();
                var result = service.SetEmailAddress(player.ID, "test+email@construct.net");
                results[AuthTest.SetEmailAddress] = new TestResult(result, sw);
            }

            // SET RESTRICTIONS
            {
                sw.Restart();
                var result = service.SetPlayerRestrictions(player.ID, [PlayerRestriction.PlayerRateObjects]);
                results[AuthTest.SetRestrictions] = new TestResult(result, sw);
            }

            // SET AVATAR BY URL
            {
                sw.Restart();
                var result = service.SetAvatar(
                    player.ID,
                    new PictureData(
                        new Uri("https://construct-static.com/images/v1746/r/uploads/user/15844/avatar/94145/avatar_v128.jpg", UriKind.Absolute)
                    )
                );
                results[AuthTest.SetAvatarByURL] = new TestResult(result, sw);
            }

            // SET AVATAR BY BASE 64
            {
                sw.Restart();
                var result = service.SetAvatar(
                    player.ID,
                    new PictureData(Data.Base64ImageData)
                );
                results[AuthTest.SetAvatarByBase64] = new TestResult(result, sw);
            }

            // DELETE AVATAR
            {
                sw.Restart();
                var result = service.DeleteAvatar(player.ID);
                results[AuthTest.DeleteAvatar] = new TestResult(result, sw);
            }

            // DELETE PLAYER
            {
                sw.Restart();
                var result = service.DeletePlayer(player.ID);
                results[AuthTest.DeletePlayer] = new TestResult(result, sw);
            }
        }

        var tests = Extensions.ToList<AuthTest>();
        foreach (var test in tests.Where(test => !results.ContainsKey(test)))
        {
            results[test] = new TestResult();
        }
        return results
            .OrderBy(c=> (int)c.Key)
            .Select(c=> 
                new Tuple<string, TestResult>(c.Key.ToString(), c.Value)
            )
            .ToList();
    }
}