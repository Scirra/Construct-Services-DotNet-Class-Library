using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    /// <summary>
    /// Edit a rating dimension for a bucket
    /// </summary>
    [UsedImplicitly]
    public static DimensionsResponse GetRatingDimensions(
        this CloudSaveService service,
        Guid bucketID)
    {
        const string path = "/bucketgetratingdimensions.json";
        return Ratings.Actions.Rating.GetDimensions(service, path, Thing.CloudSaveBlob, bucketID);
    }

    /// <summary>
    /// Edit a rating dimension for a bucket
    /// </summary>
    [UsedImplicitly]
    public static DimensionsResponse GetRatingDimensions(
        this CloudSaveService service,
        GameBucket bucket)
        => GetRatingDimensions(service, bucket.ID);
}