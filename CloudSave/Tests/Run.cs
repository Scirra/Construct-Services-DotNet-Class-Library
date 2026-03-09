using ConstructServices.Common;
using ConstructServices.Common.Tests;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ConstructServices.Authentication;
using ConstructServices.Authentication.Actions;
using ConstructServices.Authentication.Enums;
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
        DeleteBucket,

        CreateSave,
        GetByID,
        GetByKey,
        GetBytes,
        SetPicture,
        DeletePicture,
        ListPlayerSaves,
        DeleteSave
    }

    [UsedImplicitly]
    public static List<Tuple<string, TestResult>> RunTests(Guid gameID, SecretAPIKey apiKey, Action<string> logger = null)
    {
        var results = new Dictionary<CloudSaveTest, TestResult>();
        var service = new CloudSaveService(gameID, apiKey)
        {
            Logger = logger
        };
        var sw = new Stopwatch();
        sw.Start();

        {
            var createResult = service.CreateBucket(new Buckets.CreateBucketOptions
            {
                AccessMode = CloudSaveBucketAccessMode.PublicReadWrite,
                Name = "Test Bucket"
            });
            results[CloudSaveTest.CreateBucket] = new TestResult(createResult, sw);

            if (createResult.Success)
            {
                var bucket = createResult.Bucket;
                
                {
                    sw.Restart();
                    var result = service.GetBucket(bucket.ID);
                    results[CloudSaveTest.GetBucket] = new TestResult(result, sw);
                }

                {
                    sw.Restart();
                    var result = service.ListBuckets(new Buckets.ListBucketOptions
                    {
                        SortBy = GetBucketsSortMethod.LeastBlobs
                    }, new PaginationOptions(1, 50));
                    results[CloudSaveTest.ListBuckets] = new TestResult(result, sw);
                    if (result.Success)
                    {
                        if (result.Buckets.All(c => c.ID != bucket.ID))
                        {
                            results[CloudSaveTest.ListBuckets] = new TestResult(TestResultStatus.Failed, sw, "Bucket not found.");
                        }
                    }
                }

                {
                    sw.Restart();
                    var result = service.UpdateBucket(bucket.ID, new Buckets.UpdateBucketOptions { AllowRatings = true, Name = "testupdate" });
                    results[CloudSaveTest.UpdateBucket] = new TestResult(result, sw);
                }

                {
                    sw.Restart();
                    var result = service.ListCloudSaves(bucket.ID, new Buckets.ListBucketSavesOptions
                    {
                        SortBy = ListBucketCloudSaveSortMethod.NameAZ
                    }, new PaginationOptions(1, 10));
                    results[CloudSaveTest.ListBucketSaves] = new TestResult(result, sw);
                }

                // Saves
                {
                    byte[] data;
                    {
                        var rnd = new Random();
                        data = new byte[8 * 1024];
                        rnd.NextBytes(data);
                    }
                    const string testSaveKey = "my.save.key.1";
                    sw.Restart();

                    var saveResult = service.CreateCloudSave(new Saves.CreateCloudSaveOptions
                    {
                        BucketID = bucket.ID,
                        Key = testSaveKey,
                        Data = data
                    });
                    results[CloudSaveTest.CreateSave] = new TestResult(saveResult, sw);

                    if (saveResult.Success)
                    {
                        var save = saveResult.CloudSave;
                        {
                            sw.Restart();
                            var result = service.GetCloudSave(save.ID);
                            results[CloudSaveTest.GetByID] = new TestResult(result, sw);
                        }

                        {
                            sw.Restart();
                            var result = service.GetBucketSaveByKey(bucket.ID, testSaveKey);
                            results[CloudSaveTest.GetByKey] = new TestResult(result, sw);
                        }

                        {
                            sw.Restart();
                            var result = service.GetCloudSaveBytes(save);
                            if (result.Length == data.Length)
                            {
                                results[CloudSaveTest.GetBytes] = new TestResult(TestResultStatus.Passed, sw);
                            }
                            else
                            {
                                results[CloudSaveTest.GetBytes] = new TestResult(TestResultStatus.Failed, sw);
                            }
                        }

                        {
                            sw.Restart();
                            var result = service.SetPicture(save.ID, new PictureData(new Uri("https://construct-static.com/images/v1746/r/global/construct-3-logo_v64.png", UriKind.Absolute)));
                            results[CloudSaveTest.SetPicture] = new TestResult(result, sw);
                        }

                        {
                            sw.Restart();
                            var result = service.DeletePicture(save.ID);
                            results[CloudSaveTest.DeletePicture] = new TestResult(result, sw);
                        }

                        {
                            sw.Restart();
                            var result = service.DeleteCloudSave(save.ID);
                            results[CloudSaveTest.DeleteSave] = new TestResult(result, sw);
                        }
                    }

                    var authService = new AuthenticationService(gameID, apiKey);
                    var playerResult = authService.ListPlayers(new Players.ListPlayersOptions
                    {
                        Ordering = PlayerOrdering.Newest
                    }, new PaginationOptions(1, 20));
                    
                    if (playerResult.Success)
                    {
                        var player = playerResult.Players.FirstOrDefault();
                        if (player != null)
                        {
                            sw.Restart();
                            var result = service.ListPlayersCloudSaves(player.ID, new Saves.ListPlayersSavesOptions(), new PaginationOptions(1, 10));
                            results[CloudSaveTest.ListPlayerSaves] = new TestResult(result, sw);
                        }
                    }
                }

                {
                    sw.Restart();
                    var result = service.DeleteBucket(bucket.ID);
                    results[CloudSaveTest.DeleteBucket] = new TestResult(result, sw);
                }
            }
        }

        var tests = Extensions.ToList<CloudSaveTest>();
        foreach (var test in tests.Where(test => !results.ContainsKey(test)))
        {
            results[test] = new TestResult();
        }
        return results
            .Select(c=> 
                new Tuple<string, TestResult>(c.Key.ToString(), c.Value)
            )
            .ToList();
    }
}