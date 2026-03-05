using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    private enum XPTest
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
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey, Action<string> logger = null)
    {
        var results = new Dictionary<string, TestResult>();
        var service = new XPService(gameID, apiKey);

        var sw = new Stopwatch();
        sw.Start();

        // Create bonus
        {
            var createResult = service.CreateBonus(
                new Bonuses.CreateXPBonusOptions
                {
                    Start = DateTime.UtcNow.AddDays(1),
                    End = DateTime.UtcNow.AddDays(7),
                    Modifier = (decimal)2.5,
                    Title = "Test Bonus",
                    Description = "Test Description"
                }
            );
            results[nameof(XPTest.CreateBonus)] = new TestResult(createResult, sw);
            
            // Edit
            if (createResult.Success)
            {
                sw.Restart();
                var bonus = createResult.Bonus;
                var editResult = service.UpdateBonus(bonus.ID, new Bonuses.UpdateXPBonusOptions
                {
                    Title = "New title",
                    Description = "New description"
                });
                results[nameof(XPTest.EditBonus)] = new TestResult(editResult, sw);
                
                if (editResult.Success)
                {
                    sw.Restart();
                    var getResult = service.GetBonus(bonus.ID);
                    results[nameof(XPTest.GetBonus)] = new TestResult(getResult, sw);

                    if (getResult.Success)
                    {
                        bonus = getResult.Bonus;
                        
                        sw.Restart();
                        var deleteResult = service.DeleteBonus(bonus.ID);
                        results[nameof(XPTest.DeleteBonus)] = new TestResult(deleteResult, sw);
                    }
                }
            }
        }

        // List bonuses
        {
            sw.Restart();
            var listResult = service.ListBonuses(new Bonuses.ListBonusesOptions
            {
                Start = null,
                End = DateTime.UtcNow.AddDays(30)
            });
            results[nameof(XPTest.ListBonuses)] = new TestResult(listResult, sw);
        }
        
        // List active bonuses
        {
            sw.Restart();
            var listResult = service.ListActiveBonuses();
            results[nameof(XPTest.ListActiveBonuses)] = new TestResult(listResult, sw);
        }

        // Create rank
        {
            sw.Restart();
            var atXp = new Random().Next(0, int.MaxValue);
            var createResult = service.CreateRank(new Rankings.CreateXPRankOptions
            {
                Title = "Test",
                AtXP = atXp,
                Description = "My test description"
            });
            results[nameof(XPTest.CreateRank)] = new TestResult(createResult, sw);

            if (createResult.Success)
            {
                var rank = createResult.Rank;
                
                sw.Restart();
                var getResult = service.ListAllRanks();
                results[nameof(XPTest.ListRanks)] = new TestResult(getResult, sw);
                if (getResult.Success)
                {
                    if (getResult.Ranks.All(c => c.ID != rank.ID))
                    {
                        results[nameof(XPTest.ListRanks)] = new TestResult(TestResultStatus.Failed, sw, "Rank not found.");
                    }
                    else
                    {
                        sw.Restart();
                        var updateResult = service.UpdateRank(rank.ID, new Rankings.UpdateXPRankOptions { Title = "Updated" });
                        results[nameof(XPTest.UpdateRank)] = new TestResult(updateResult, sw);

                        if (updateResult.Success)
                        {
                            sw.Restart();
                            var deleteResult = service.DeleteRank(rank.ID);
                            results[nameof(XPTest.DeleteRank)] = new TestResult(deleteResult, sw);
                        }
                    }
                }
            }
        }

        // XP
        {
            // Get player
            var authService = new AuthenticationService(gameID, apiKey);
            var player = authService.ListPlayers(new Players.ListPlayersOptions
            {
                Ordering = PlayerOrdering.Newest
            }, new PaginationOptions(1, 20)).Players.FirstOrDefault();
            if (player != null)
            {
                sw.Restart();
                var addResult = service.AddXP(player.ID, new ModifyXPOptions(new Random().Next(1, 10)));
                results[nameof(XPTest.AddXP)] = new TestResult(addResult, sw);

                if (addResult.Success)
                {
                    sw.Restart();
                    var deductResult = service.RemoveXP(player.ID, new ModifyXPOptions(new Random().Next(1, 10)));
                    results[nameof(XPTest.RemoveXP)] = new TestResult(deductResult, sw);

                    if (deductResult.Success)
                    {
                        sw.Restart();
                        var setResult = service.SetXP(player.ID, new ModifyXPOptions(new Random().Next(1, 10000)));
                        results[nameof(XPTest.SetXP)] = new TestResult(setResult, sw);

                        if (setResult.Success)
                        {
                            sw.Restart();
                            var getResult = service.GetXP(player.ID);
                            results[nameof(XPTest.GetXP)] = new TestResult(getResult, sw);
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