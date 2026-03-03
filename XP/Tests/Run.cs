using System;
using System.Collections.Generic;
using System.Linq;
using ConstructServices.Authentication;
using ConstructServices.Authentication.Actions;
using ConstructServices.Authentication.Enums;
using ConstructServices.Common;
using ConstructServices.Common.Tests;
using ConstructServices.XP.Actions;
using JetBrains.Annotations;

namespace ConstructServices.XP.Tests;

[UsedImplicitly]
public static class Run
{
    public enum XPTest
    {
        CreateBonus,
        EditBonus,
        GetBonus,
        DeleteBonus,
        ListBonuses,
        ListActiveBonuses,

        CreateRank,
        UpdateRank,
        ListRanks,
        DeleteRank,

        AddXP,
        GetXP,
        RemoveXP,
        SetXP
    }
    
    [UsedImplicitly]
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey)
    {
        var results = new Dictionary<string, TestResult>();
        var service = new XPService(gameID, apiKey);

        // Create bonus
        {
            var createResult = service.CreateBonus(
                new Bonuses.CreateXPBonusOptions(
                    DateTime.UtcNow.AddDays(1),
                    DateTime.UtcNow.AddDays(7),
                    (decimal)2.5,
                    "Test Bonus",
                    "Test bonus description")
            );
            results[nameof(XPTest.CreateBonus)] = new TestResult(createResult);
            
            // Edit
            if (createResult.Success)
            {
                var bonus = createResult.Bonus;
                var editResult = service.UpdateBonus(bonus.ID, new Bonuses.UpdateXPBonusOptions
                {
                    Title = "New title",
                    Description = "New description"
                });
                results[nameof(XPTest.EditBonus)] = new TestResult(editResult);
                
                if (editResult.Success)
                {
                    var getResult = service.GetBonus(bonus.ID);
                    results[nameof(XPTest.GetBonus)] = new TestResult(getResult);

                    if (getResult.Success)
                    {
                        bonus = getResult.Bonus;

                        var deleteResult = service.DeleteBonus(bonus.ID);
                        results[nameof(XPTest.DeleteBonus)] = new TestResult(deleteResult);
                    }
                }
            }
        }

        // List bonuses
        {
            var listResult = service.ListBonuses(new Bonuses.ListBonusesOptions(DateTime.UtcNow, DateTime.UtcNow.AddDays(30)));
            results[nameof(XPTest.ListBonuses)] = new TestResult(listResult);
        }
        
        // List active bonuses
        {
            var listResult = service.ListActiveBonuses();
            results[nameof(XPTest.ListActiveBonuses)] = new TestResult(listResult);
        }

        // Create rank
        {
            var atXp = new Random().Next(0, int.MaxValue);
            var createResult = service.CreateRank(new Rankings.CreateXPRankOptions(atXp, "Test", "My rank"));
            results[nameof(XPTest.CreateRank)] = new TestResult(createResult);

            if (createResult.Success)
            {
                var rank = createResult.Rank;

                var getResult = service.ListAllRanks();
                results[nameof(XPTest.ListRanks)] = new TestResult(getResult);
                if (getResult.Success)
                {
                    if (getResult.Ranks.All(c => c.ID != rank.ID))
                    {
                        results[nameof(XPTest.ListRanks)] = new TestResult(TestResultStatus.Failed, "Rank not found.");
                    }
                    else
                    {
                        var updateResult = service.UpdateRank(rank.ID, new Rankings.UpdateXPRankOptions { Title = "Updated" });
                        results[nameof(XPTest.UpdateRank)] = new TestResult(updateResult);

                        if (updateResult.Success)
                        {
                            var deleteResult = service.DeleteRank(rank.ID);
                            results[nameof(XPTest.DeleteRank)] = new TestResult(deleteResult);
                        }
                    }
                }
            }
        }

        // XP
        {
            // Get player
            var authService = new AuthenticationService(gameID, apiKey);
            var player = authService.GetPlayers(new Players.GetPlayersOptions(PlayerOrdering.Newest)).Players.FirstOrDefault();
            if (player != null)
            {
                var addResult = service.AddXP(player.ID, new ModifyXPOptions(new Random().Next(1, 10)));
                results[nameof(XPTest.AddXP)] = new TestResult(addResult);

                if (addResult.Success)
                {
                    var deductResult = service.RemoveXP(player.ID, new ModifyXPOptions(new Random().Next(1, 10)));
                    results[nameof(XPTest.RemoveXP)] = new TestResult(deductResult);

                    if (deductResult.Success)
                    {
                        var setResult = service.SetXP(player.ID, new ModifyXPOptions(new Random().Next(1, 10000)));
                        results[nameof(XPTest.SetXP)] = new TestResult(setResult);

                        if (setResult.Success)
                        {
                            var getResult = service.GetXP(player.ID);
                            results[nameof(XPTest.GetXP)] = new TestResult(getResult);
                        }
                    }
                }
            }
        }

        var testNames = Enum.GetNames(typeof(XPTest));
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