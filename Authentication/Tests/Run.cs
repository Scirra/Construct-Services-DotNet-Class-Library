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
        GetPlayerByID,
        GetPlayerByPlayerName,
        ChangePlayerName,
        GetPlayerByUpdatedName,
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
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey, Action<string> logger = null)
    {
        var results = new Dictionary<string, TestResult>();
        var service = new AuthenticationService(gameID, apiKey);

        var sw = new Stopwatch();
        sw.Start();

        // CREATE NEW PLAYER
        var playerName = "Test" + new Random().Next(0, 10000);
        var createResult = service.RegisterPlayer(new Players.RegisterPlayerOptions
        {
            PlayerName = playerName
        });
        results[nameof(AuthTest.CreatePlayer)] = new TestResult(createResult, sw);

        if (createResult.Success)
        {
            var player = createResult.Player;

            var playerService = new PlayerAuthenticationService(gameID, new SessionKey(createResult.Session.Key));
            
            // LOGIN
            {
                const string testName = nameof(AuthTest.Login);
                sw.Restart();
                var result = playerService.Login(LoginProvider.Discord);
                results[testName] = new TestResult(result, sw);
                if (result.Success)
                {
                    var pollToken = result.PollToken;

                    // LOGIN POLL
                    {
                        const string pollTestName = nameof(AuthTest.LoginPoll);
                        sw.Restart();
                        var pollResult = playerService.LoginPoll(pollToken);
                        results[pollTestName] = new TestResult(pollResult, sw);
                    }
                }
            }
            
            // LINK
            {
                const string testName = nameof(AuthTest.Link);
                sw.Restart();
                var result = playerService.LinkLoginProvider(LoginProvider.Apple);
                results[testName] = new TestResult(result, sw);
                if (result.Success)
                {
                    var pollToken = result.PollToken;

                    // LINK POLL
                    {
                        const string pollTestName = nameof(AuthTest.LinkPoll);
                        sw.Restart();
                        var pollResult = playerService.LinkPoll(pollToken);
                        results[pollTestName] = new TestResult(pollResult, sw);
                    }
                }
            }

            // GET SESSION
            {
                const string testName = nameof(AuthTest.GetSession);
                sw.Restart();
                var result = playerService.GetSession();
                results[testName] = new TestResult(result, sw);
            }

            // REFRESH SESSION
            {
                const string testName = nameof(AuthTest.RefreshSession);
                sw.Restart();
                var result = playerService.RefreshSession();
                results[testName] = new TestResult(result, sw);
            }

            // END SESSION
            {
                const string testName = nameof(AuthTest.EndSession);
                sw.Restart();
                var result = playerService.EndSession();
                results[testName] = new TestResult(result, sw);
            }

            // LIST NEWEST PLAYERS
            {
                const string testName = nameof(AuthTest.ListNewestPlayers);
                sw.Restart();
                var result = service.ListPlayers(
                    new Players.ListPlayersOptions
                    {
                        Ordering = PlayerOrdering.Newest
                    },
                    new PaginationOptions(1, 20)
                );
                results[testName] = new TestResult(result, sw);
                if (result.Success && result.Players.All(c => c.ID != player.ID))
                {
                    results[testName] = new TestResult(TestResultStatus.Failed, sw, "New player ID not found.");
                }
            }

            // LIST RECENTLY ACTIVE PLAYERS
            {
                const string testName = nameof(AuthTest.ListMostRecentlyActivePlayers);
                sw.Restart();
                var result = service.ListPlayers(
                    new Players.ListPlayersOptions
                    {
                        Ordering = PlayerOrdering.MostRecentlyActive
                    },
                    new PaginationOptions(1, 20)
                );
                results[testName] = new TestResult(result, sw);
                if (result.Success && result.Players.All(c => c.ID != player.ID))
                {
                    results[testName] = new TestResult(TestResultStatus.Failed, sw, "New player ID not found.");
                }
            }

            // GET PLAYER BY ID
            {
                const string testName = nameof(AuthTest.GetPlayerByID);
                sw.Restart();
                var result = service.GetPlayer(player.ID);
                results[testName] = new TestResult(result, sw);
                if (result.Success && result.Player == null)
                {
                    results[testName] = new TestResult(TestResultStatus.Failed, sw);
                }
            }

            // GET PLAYER BY PLAYER NAME
            {
                const string testName = nameof(AuthTest.GetPlayerByPlayerName);
                sw.Restart();
                var result = service.GetPlayer(playerName);
                results[testName] = new TestResult(result, sw);
                if (result.Success && result.Player == null)
                {
                    results[testName] = new TestResult(TestResultStatus.Failed, sw);
                }
            }

            // CHANGE PLAYER NAME
            var newPlayerName = "Test" + new Random().Next(0, 10000);
            {
                const string testName = nameof(AuthTest.ChangePlayerName);
                sw.Restart();
                var result = service.ChangePlayerName(player.ID, newPlayerName);
                results[testName] = new TestResult(result, sw);
            }

            // GET PLAYER BY PLAYER NAME
            {
                const string testName = nameof(AuthTest.GetPlayerByUpdatedName);
                sw.Restart();
                var result = service.GetPlayer(newPlayerName);
                results[testName] = new TestResult(result, sw);
                if (result.Success && result.Player == null)
                {
                    results[testName] = new TestResult(TestResultStatus.Failed, sw);
                }
            }

            // SET USERNAME/PASSWORD
            {
                const string testName = nameof(AuthTest.SetUsernamePassword);
                sw.Restart();
                var result = service.SetUsernameAndPassword(player.ID, "Test" + new Random().Next(0, 10000), "abc123#AB£");
                results[testName] = new TestResult(result, sw);
            }

            // SET PASSWORD
            {
                const string testName = nameof(AuthTest.SetPassword);
                sw.Restart();
                var result = service.ChangePassword(player.ID, "abcdEE1234###£");
                results[testName] = new TestResult(result, sw);
            }

            // SET USERNAME
            {
                const string testName = nameof(AuthTest.SetUsername);
                sw.Restart();
                var result = service.ChangeUsername(player.ID, "Test" + new Random().Next(0, 10000));
                results[testName] = new TestResult(result, sw);
            }
            
            // FORGOTTEN PASSWORD
            {
                const string testName = nameof(AuthTest.ForgottenPassword);
                sw.Restart();
                var result = service.RequestForgottenPasswordEmail("testemail@construct.ner");
                results[testName] = new TestResult(result, sw);
            }

            // SET EMAIL ADDRESS
            {
                const string testName = nameof(AuthTest.SetEmailAddress);
                sw.Restart();
                var result = service.SetEmailAddress(player.ID, "test+email@construct.net");
                results[testName] = new TestResult(result, sw);
            }

            // SET RESTRICTIONS
            {
                const string testName = nameof(AuthTest.SetRestrictions);
                sw.Restart();
                var result = service.SetPlayerRestrictions(player.ID, [PlayerRestriction.PlayerRateObjects]);
                results[testName] = new TestResult(result, sw);
            }

            // SET AVATAR BY URL
            {
                const string testName = nameof(AuthTest.SetAvatarByURL);
                sw.Restart();
                var result = service.SetAvatar(
                    player.ID,
                    new PictureData(
                        new Uri("https://construct-static.com/images/v1746/r/uploads/user/15844/avatar/94145/avatar_v128.jpg", UriKind.Absolute)
                    )
                );
                results[testName] = new TestResult(result, sw);
            }

            // SET AVATAR BY BASE 64
            {
                const string testName = nameof(AuthTest.SetAvatarByBase64);
                sw.Restart();
                var result = service.SetAvatar(
                    player.ID,
                    new PictureData(Data.Base64ImageData)
                );
                results[testName] = new TestResult(result, sw);
            }

            // DELETE AVATAR
            {
                const string testName = nameof(AuthTest.DeleteAvatar);
                sw.Restart();
                var result = service.DeleteAvatar(player.ID);
                results[testName] = new TestResult(result, sw);
            }

            // DELETE PLAYER
            {
                const string testName = nameof(AuthTest.DeletePlayer);
                sw.Restart();
                var result = service.DeletePlayer(player.ID);
                results[testName] = new TestResult(result, sw);
            }
        }

        var testNames = Enum.GetNames(typeof(AuthTest));
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