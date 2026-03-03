using System;
using System.Collections.Generic;
using ConstructServices.Common;
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
        ListActiveBonuses
    }
    
    [UsedImplicitly]
    public static Dictionary<XPTest, bool?> RunTests(Guid gameID, SecretAPIKey apiKey)
    {
        var results = new Dictionary<XPTest, bool?>();
        foreach (var XPTest in (XPTest[])Enum.GetValues(typeof(XPTest)))
        {
            results.Add(XPTest, null);
        }

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
            results[XPTest.CreateBonus] = createResult.Success;

            // Edit
            if (createResult.Success)
            {
                var bonus = createResult.Bonus;
                var editResult = service.UpdateBonus(bonus.ID, new Bonuses.UpdateXPBonusOptions
                {
                    Title = "New title",
                    Description = "New description"
                });
                results[XPTest.EditBonus] = editResult.Success;

                if (editResult.Success)
                {
                    var getResult = service.GetBonus(bonus.ID);
                    results[XPTest.GetBonus] = getResult.Success;

                    if (getResult.Success)
                    {
                        bonus = getResult.Bonus;

                        var deleteResult = service.DeleteBonus(bonus.ID);
                        results[XPTest.DeleteBonus] = deleteResult.Success;
                    }
                }
            }
        }
        
        // List bonuses
        {
            var listResult =service.ListBonuses(new Bonuses.ListBonusesOptions(DateTime.UtcNow, DateTime.UtcNow.AddDays(30)));
            results[XPTest.ListBonuses] = listResult.Success;
        }

        // List active bonuses
        {
            var listResult = service.ListActiveBonuses();
            results[XPTest.ListActiveBonuses] = listResult.Success;
        }

        return results;
    }
}