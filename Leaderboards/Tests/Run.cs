using ConstructServices.Common;
using ConstructServices.Common.Tests;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Leaderboards.Tests;

public static class Run
{
    private enum LeaderboardTest
    {
    }

    [UsedImplicitly]
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey, Guid leaderboardID)
    {
        var results = new Dictionary<string, TestResult>();
        var service = new LeaderboardService(gameID, leaderboardID, apiKey);
        

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