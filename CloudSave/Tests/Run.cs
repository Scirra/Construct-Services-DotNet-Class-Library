using ConstructServices.Common;
using ConstructServices.Common.Tests;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using ConstructServices.CloudSave.Actions;
using ConstructServices.CloudSave.Enums;

namespace ConstructServices.CloudSave.Tests;

public static class Run
{
    private enum CloudSaveTest
    {
        CreateBucket,
        GetBucket,
        ListBuckets,
        UpdateBucket,
        ListBucketSaves,
        DeleteBucket
    }

    [UsedImplicitly]
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey)
    {
        var results = new Dictionary<string, TestResult>();
        var service = new CloudSaveService(gameID, apiKey);

        {
            var createResult = service.CreateBucket(new Buckets.CreateBucketOptions("test", CloudSaveBucketAccessMode.PublicReadWrite));
            results[nameof(CloudSaveTest.CreateBucket)] = new TestResult(createResult);

            if (createResult.Success)
            {
                var bucket = createResult.Bucket;
                
                {
                    var result = service.GetBucket(bucket.ID);
                    results[nameof(CloudSaveTest.GetBucket)] = new TestResult(result);
                }

                {
                    var result = service.ListBuckets(new Buckets.ListBucketOptions(GetBucketsSortMethod.LeastBlobs), new PaginationOptions(1, 50));
                    results[nameof(CloudSaveTest.ListBuckets)] = new TestResult(result);
                    if (result.Success)
                    {
                        if (result.Buckets.All(c => c.ID != bucket.ID))
                        {
                            results[nameof(CloudSaveTest.ListBuckets)] = new TestResult(TestResultStatus.Failed, "Bucket not found.");
                        }
                    }
                }

                {
                    var result = service.UpdateBucket(bucket.ID, new Buckets.UpdateBucketOptions { AllowRatings = true, Name = "testupdate" });
                    results[nameof(CloudSaveTest.UpdateBucket)] = new TestResult(result);
                }

                {
                    var result = service.ListCloudSaves(bucket.ID, new Buckets.ListBucketSavesOptions(GetBucketCloudSaveSortMethod.NameAZ), new PaginationOptions(1, 10));
                    results[nameof(CloudSaveTest.ListBucketSaves)] = new TestResult(result);
                }

                {
                    var result = service.DeleteBucket(bucket.ID);
                    results[nameof(CloudSaveTest.DeleteBucket)] = new TestResult(result);
                }
            }
        }

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