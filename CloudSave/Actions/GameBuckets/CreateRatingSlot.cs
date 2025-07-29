using ConstructServices.CloudSave.Objects;
using ConstructServices.Ratings.Enums;
using JetBrains.Annotations;
using System;
using ConstructServices.Ratings.Responses;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    /// <summary>
    /// Create a rating slot for a bucket
    /// </summary>
    [UsedImplicitly]
    public static SlotResponse CreateRatingSlot(
        this CloudSaveService service,
        Guid bucketID,
        string slotID,
        string title,
        string description,
        byte maxRating)
    {
        const string path = "/bucketcreateratingslot.json";
        return Ratings.Actions.Rating.CreateSlot(service, path, RatableThing.CloudSaveBlob, bucketID, slotID, title, description, maxRating);
    }

    /// <summary>
    /// Create a rating slot for a bucket
    /// </summary>
    [UsedImplicitly]
    public static SlotResponse CreateRatingSlot(
        this CloudSaveService service,
        GameBucket bucket,
        string slotID,
        string title,
        string description,
        byte maxRating)
        => CreateRatingSlot(service, bucket.ID, slotID, title, description, maxRating);
}