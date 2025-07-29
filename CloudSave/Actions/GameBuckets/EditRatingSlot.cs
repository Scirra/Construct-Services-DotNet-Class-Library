using ConstructServices.CloudSave.Objects;
using ConstructServices.Ratings.Enums;
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
    public static SlotResponse EditRatingSlot(
        this CloudSaveService service,
        Guid bucketID,
        string slotID,
        string newTitle = null,
        string newDescription = null,
        byte? newMaxRating = null)
    {
        const string path = "/bucketeditratingslot.json";
        return Ratings.Actions.Rating.EditSlot(service, path, RatableThing.CloudSaveBlob, bucketID, slotID, newTitle, newDescription, newMaxRating);
    }

    /// <summary>
    /// Edit a rating slot for a bucket
    /// </summary>
    [UsedImplicitly]
    public static SlotResponse EditRatingSlot(
        this CloudSaveService service,
        GameBucket bucket,
        string slotID,
        string newTitle = null,
        string newDescription = null,
        byte? newMaxRating = null)
        => EditRatingSlot(service, bucket.ID, slotID, newTitle, newDescription, newMaxRating);
}