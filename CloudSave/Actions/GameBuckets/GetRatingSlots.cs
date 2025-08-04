using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    /// <summary>
    /// Edit a rating slot for a bucket
    /// </summary>
    [UsedImplicitly]
    public static DimensionsResponse GetRatingSlots(
        this CloudSaveService service,
        Guid bucketID)
    {
        const string path = "/bucketgetratingslots.json";
        return Ratings.Actions.Rating.GetSlots(service, path, Thing.CloudSaveBlob, bucketID);
    }

    /// <summary>
    /// Edit a rating slot for a bucket
    /// </summary>
    [UsedImplicitly]
    public static DimensionsResponse GetRatingSlots(
        this CloudSaveService service,
        GameBucket bucket)
        => GetRatingSlots(service, bucket.ID);
}