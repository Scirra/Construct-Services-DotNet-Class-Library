using System;
using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;
using ConstructServices.Ratings.Enums;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    /// <summary>
    /// Delete a rating slot for a bucket
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse DeleteRatingSlot(
        this CloudSaveService service,
        Guid bucketID,
        string slotID)
    {
        const string path = "/bucketdeleteratingslot.json";
        return Ratings.Actions.Rating.DeleteSlot(service, path, RatableThing.CloudSaveBlob, bucketID, slotID);
    }

    /// <summary>
    /// Delete a rating slot for a bucket
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse DeleteRatingSlot(
        this CloudSaveService service,
        GameBucket bucket,
        string slotID) 
        => DeleteRatingSlot(service, bucket.ID, slotID);
}