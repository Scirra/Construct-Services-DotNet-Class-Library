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
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey)
    {
        var results = new Dictionary<string, TestResult>();
        var service = new CloudSaveService(gameID, apiKey);

        var sw = new Stopwatch();
        sw.Start();

        {
            var createResult = service.CreateBucket(new Buckets.CreateBucketOptions("test", CloudSaveBucketAccessMode.PublicReadWrite));
            results[nameof(CloudSaveTest.CreateBucket)] = new TestResult(createResult, sw);

            if (createResult.Success)
            {
                var bucket = createResult.Bucket;
                
                {
                    sw.Restart();
                    var result = service.GetBucket(bucket.ID);
                    results[nameof(CloudSaveTest.GetBucket)] = new TestResult(result, sw);
                }

                {
                    sw.Restart();
                    var result = service.ListBuckets(new Buckets.ListBucketOptions(GetBucketsSortMethod.LeastBlobs), new PaginationOptions(1, 50));
                    results[nameof(CloudSaveTest.ListBuckets)] = new TestResult(result, sw);
                    if (result.Success)
                    {
                        if (result.Buckets.All(c => c.ID != bucket.ID))
                        {
                            results[nameof(CloudSaveTest.ListBuckets)] = new TestResult(TestResultStatus.Failed, sw, "Bucket not found.");
                        }
                    }
                }

                {
                    sw.Restart();
                    var result = service.UpdateBucket(bucket.ID, new Buckets.UpdateBucketOptions { AllowRatings = true, Name = "testupdate" });
                    results[nameof(CloudSaveTest.UpdateBucket)] = new TestResult(result, sw);
                }

                {
                    sw.Restart();
                    var result = service.ListCloudSaves(bucket.ID, new Buckets.ListBucketSavesOptions(GetBucketCloudSaveSortMethod.NameAZ), new PaginationOptions(1, 10));
                    results[nameof(CloudSaveTest.ListBucketSaves)] = new TestResult(result, sw);
                }
                /*
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
                    var saveResult = service.CreateCloudSave(new Saves.CreateCloudSaveOptions(bucket.ID, data, "my-save-1", testSaveKey));
                    results[nameof(CloudSaveTest.CreateSave)] = new TestResult(saveResult, sw);

                    if (saveResult.Success)
                    {
                        var save = saveResult.Blob;
                        {
                            sw.Restart();
                            var result = service.GetByID(new Saves.GetCloudSaveByIDOptions(save.ID));
                            results[nameof(CloudSaveTest.GetByID)] = new TestResult(result, sw);
                        }
                        {
                            sw.Restart();
                            var result = service.GetByKey(new Saves.GetCloudSaveByKeyOptions(testSaveKey, bucket.ID));
                            results[nameof(CloudSaveTest.GetByKey)] = new TestResult(result, sw);
                        }
                        {
                            sw.Restart();
                            var result = service.GetCloudSaveBytes(save);
                            if (result.Length == data.Length)
                            {
                                results[nameof(CloudSaveTest.GetBytes)] = new TestResult(TestResultStatus.Passed, sw);
                            }
                            else
                            {
                                results[nameof(CloudSaveTest.GetBytes)] = new TestResult(TestResultStatus.Failed, sw);
                            }
                        }
                        {
                            sw.Restart();
                            var result = service.SetPicture(new Saves.SetCloudSavePictureOptions(save.ID, new PictureData(new Uri("https://construct-static.com/images/v1746/r/global/construct-3-logo_v64.png", UriKind.Absolute))));
                            results[nameof(CloudSaveTest.SetPicture)] = new TestResult(result, sw);
                        }
                        {
                            sw.Restart();
                            var result = service.DeletePicture(new Saves.DeleteCloudSavePictureOptions(save.ID));
                            results[nameof(CloudSaveTest.DeletePicture)] = new TestResult(result, sw);
                        }
                        {
                            sw.Restart();
                            var result = service.DeleteCloudSave(new Saves.DeleteCloudSaveOptions(save.ID));
                            results[nameof(CloudSaveTest.DeleteSave)] = new TestResult(result, sw);
                        }
                    }

                    var authService = new AuthenticationService(gameID, apiKey);
                    var playerResult = authService.ListPlayers(new Players.GetPlayersOptions(PlayerOrdering.Newest), new PaginationOptions(1, 20));
                    if (playerResult.Success)
                    {
                        var player = playerResult.Players.FirstOrDefault();
                        if (player != null)
                        {
                            sw.Restart();
                            var result = service.ListPlayersCloudSaves(new Saves.ListPlayersSavesOptions(player.ID), new PaginationOptions(1, 10));
                            results[nameof(CloudSaveTest.ListPlayerSaves)] = new TestResult(result, sw);
                        }
                    }
                }
                */

                {
                    sw.Restart();
                    var result = service.DeleteBucket(bucket.ID);
                    results[nameof(CloudSaveTest.DeleteBucket)] = new TestResult(result, sw);
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