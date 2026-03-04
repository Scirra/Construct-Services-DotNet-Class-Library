using ConstructServices.Common;
using ConstructServices.Common.Tests;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ConstructServices.Authentication.Actions;
using ConstructServices.Authentication.Enums;

namespace ConstructServices.Authentication.Tests;

public static class Run
{
    private enum AuthTest
    {
        CreatePlayer,
        ChangePlayerName,
        SetUsernamePassword,
        ChangePassword,
        ChangeUsername,
        GetPlayer,
        ListPlayers,
        ForgottenPassword,
        SetEmailAddress,
        SetRestrictions,
        DeletePlayer,

        SetAvatar,
        DeleteAvatar
    }

    [UsedImplicitly]
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey)
    {
        var results = new Dictionary<string, TestResult>();
        var service = new AuthenticationService(gameID, apiKey);

        var sw = new Stopwatch();
        sw.Start();

        var createResult = service.CreatePlayer(new Players.CreatePlayerOptions("Test" + new Random().Next(0, 10000)));
        results[nameof(AuthTest.CreatePlayer)] = new TestResult(createResult, sw);

        if (createResult.Success)
        {
            var player = createResult.Player;
            {
                sw.Restart();
                var result = service.ListPlayers(new Players.GetPlayersOptions(PlayerOrdering.Newest), new PaginationOptions(1, 20));
                results[nameof(AuthTest.ListPlayers)] = new TestResult(result, sw);
                if (result.Success)
                {
                    if (result.Players.All(c => c.ID != player.ID))
                    {
                        results[nameof(AuthTest.ListPlayers)] =
                            new TestResult(TestResultStatus.Failed, sw, "Player ID not returned.");
                    }
                }
            }

            {
                sw.Restart();
                var result = service.ChangePlayerName(new Players.ChangePlayerNameOptions(player.ID, "Test" + new Random().Next(0, 10000)));
                results[nameof(AuthTest.ChangePlayerName)] = new TestResult(result, sw);
            }

            {
                sw.Restart();
                var result = service.SetUsernameAndPassword(new Players.SetUsernameAndPasswordOptions(player.ID, "Test" + new Random().Next(0, 10000), "abc123#AB£"));
                results[nameof(AuthTest.SetUsernamePassword)] = new TestResult(result, sw);
            }

            {
                sw.Restart();
                var result = service.ChangePassword(new Players.ChangePasswordOptions(player.ID, "abcdEE1234###£"));
                results[nameof(AuthTest.ChangePassword)] = new TestResult(result, sw);
            }

            {
                sw.Restart();
                var result = service.ChangeUsername(new Players.ChangeUsernameOptions(player.ID, "Test" + new Random().Next(0, 10000)));
                results[nameof(AuthTest.ChangeUsername)] = new TestResult(result, sw);
            }

            {
                sw.Restart();
                var result = service.GetPlayer(new Players.GetPlayerOptions(player.ID));
                results[nameof(AuthTest.GetPlayer)] = new TestResult(result, sw);
            }

            {
                sw.Restart();
                var result = service.RequestForgottenPasswordEmail(new Players.ForgottenPasswordOptions("testemail@construct.ner"));
                results[nameof(AuthTest.ForgottenPassword)] = new TestResult(result, sw);
            }

            {
                sw.Restart();
                var result = service.SetEmailAddress(new Players.SetEmailAddressOptions(player.ID, "test+email@construct.net"));
                results[nameof(AuthTest.SetEmailAddress)] = new TestResult(result, sw);
            }

            {
                sw.Restart();
                var result = service.SetPlayerRestrictions(new Players.SetPlayerRestrictionsOptions(player.ID, [PlayerRestriction.PlayerRateObjects]));
                results[nameof(AuthTest.SetRestrictions)] = new TestResult(result, sw);
            }

            {
                sw.Restart();
                var result = service.SetAvatar(new Avatars.SetAvatarOptions(player.ID,
                    new PictureData(new Uri(
                        "https://construct-static.com/images/v1746/r/uploads/user/15844/avatar/94145/avatar_v128.jpg",
                        UriKind.Absolute))));
                results[nameof(AuthTest.SetAvatar)] = new TestResult(result, sw);
            }

            {
                sw.Restart();
                var result = service.DeleteAvatar(new Avatars.DeleteAvatarOptions(player.ID));
                results[nameof(AuthTest.DeleteAvatar)] = new TestResult(result, sw);
            }

            {
                sw.Restart();
                var result = service.DeletePlayer(player.ID);
                results[nameof(AuthTest.DeletePlayer)] = new TestResult(result, sw);
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