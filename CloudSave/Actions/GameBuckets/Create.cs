using ConstructServices.CloudSave.Enums;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    /// <summary>
    /// Delete a bucket and all it's contained data
    /// </summary>
    [UsedImplicitly]
    public static BucketResponse Create(
        this CloudSaveService service,
        CloudSaveGameBucketAccessMode accessMode,
        string bucketName,
        bool allowRatings = true,
        uint? maxBlobs = null,
        uint? maxBlobSizeBytes = null,
        uint? maxBlobsPerPlayer = null)
    {
        var formData = new Dictionary<string, string>
        {
            { "bucketName", bucketName },
            { "accessMode", accessMode.ToString() },
            { "allowRatings", allowRatings.ToInt().ToString() }
        };
        if (maxBlobs.HasValue)
        {
            formData.Add("maxBlobs", maxBlobs.Value.ToString());
        }
        if (maxBlobSizeBytes.HasValue)
        {
            formData.Add("maxBlobSize", maxBlobSizeBytes.Value.ToString());
        }
        if (maxBlobsPerPlayer.HasValue)
        {
            formData.Add("maxBlobsPerPlayer", maxBlobsPerPlayer.Value.ToString());
        }

        const string path = "/createbucket.json";
        return Task.Run(() => Request.ExecuteRequest<BucketResponse>(
            path,
            service,
            formData
        )).Result;
    }
}