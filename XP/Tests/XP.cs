using System;
using System.Collections.Generic;
using System.Linq;
using ConstructServices.Common;
using ConstructServices.XP.Actions;
using JetBrains.Annotations;

namespace ConstructServices.XP.Tests;

[UsedImplicitly]
public static class XP
{
    public enum XPTest
    {
        CreateBonus,
        EditBonus,
        GetBonus,
        DeleteBonus,
        ListBonuses,
        ListActiveBonuses
    }
    
    [UsedImplicitly]
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey)
    {
        var results = ((XPTest[])Enum.GetValues(typeof(XPTest)))
            .ToDictionary(XPTest => XPTest.ToString(), _ => new TestResult());

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
            var listResult =service.ListBonuses(new Bonuses.ListBonusesOptions(DateTime.UtcNow, DateTime.UtcNow.AddDays(30)));
            results[nameof(XPTest.ListBonuses)] = new TestResult(listResult);
        }

        // List active bonuses
        {
            var listResult = service.ListActiveBonuses();
            results[nameof(XPTest.ListActiveBonuses)] = new TestResult(listResult);
        }

        return results;
    }
}