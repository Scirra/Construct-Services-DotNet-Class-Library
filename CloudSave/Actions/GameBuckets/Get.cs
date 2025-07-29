﻿using System;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    /// <summary>
    /// Get a bucket by its ID.  Doesn't return cloud saves in bucket, just the bucket itself.
    /// </summary>
    [UsedImplicitly]
    public static BucketResponse Get(
        this CloudSaveService service,
        Guid bucketID)
    {
        var formData = new Dictionary<string, string>
        {
            { "bucketID", bucketID.ToString() }
        };
        const string path = "/getbucket.json";
        return Task.Run(() => Request.ExecuteRequest<BucketResponse>(
            path,
            service,
            formData
        )).Result;
    }
}