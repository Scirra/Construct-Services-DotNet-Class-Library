using System;
using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    /// <summary>
    /// Delete a rating dimension for a bucket
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse DeleteRatingDimension(
        this CloudSaveService service,
        Guid bucketID,
        string dimensionID)
    {
        const string path = "/bucketdeleteratingsdimension.json";
        return Ratings.Actions.Rating.DeleteDimension(service, path, Thing.CloudSaveBlob, bucketID, dimensionID);
    }

    /// <summary>
    /// Delete a rating dimension for a bucket
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse DeleteRatingDimension(
        this CloudSaveService service,
        GameBucket bucket,
        string dimensionID) 
        => DeleteRatingDimension(service, bucket.ID, dimensionID);
}