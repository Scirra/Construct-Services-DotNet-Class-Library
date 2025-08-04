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
    public static DimensionResponse EditRatingDimension(
        this CloudSaveService service,
        Guid bucketID,
        string dimensionID,
        string newTitle = null,
        string newDescription = null,
        byte? newMaxRating = null)
    {
        const string path = "/bucketeditratingdimension.json";
        return Ratings.Actions.Rating.EditDimension(service, path, Thing.CloudSaveBlob, bucketID, dimensionID, newTitle, newDescription, newMaxRating);
    }

    /// <summary>
    /// Edit a rating dimension for a bucket
    /// </summary>
    [UsedImplicitly]
    public static DimensionResponse EditRatingDimension(
        this CloudSaveService service,
        GameBucket bucket,
        string dimensionID,
        string newTitle = null,
        string newDescription = null,
        byte? newMaxRating = null)
        => EditRatingDimension(service, bucket.ID, dimensionID, newTitle, newDescription, newMaxRating);
}