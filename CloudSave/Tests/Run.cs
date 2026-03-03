using ConstructServices.Common;
using ConstructServices.Common.Tests;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.CloudSave.Tests;

public static class Run
{
    private enum CloudSaveTest
    {
    }

    [UsedImplicitly]
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey)
    {
        var results = new Dictionary<string, TestResult>();
        var service = new CloudSaveService(gameID, apiKey);
        

        var testNames = Enum.GetNames(typeof(CloudSaveTest));
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