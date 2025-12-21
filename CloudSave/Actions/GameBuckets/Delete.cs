using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

[UsedImplicitly]
public static partial class GameBuckets
{
    /// <summary>
    /// Delete a bucket and all it's contained data
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse DeleteBucket(
        this CloudSaveService service,
        Guid bucketID)
    {
        var formData = new Dictionary<string, string>
        {
            { "bucketID", bucketID.ToString() }
        };

        const string path = "/deletebucket.json";
        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            formData
        )).Result;
    }
}