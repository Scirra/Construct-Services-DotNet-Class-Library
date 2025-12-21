using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class RatingDimensions
{
    private const string CreateDimensionAPIEndPoint = "/bucketcreateratingdimension.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(
            Guid bucketID,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
        {
            return Ratings.Actions.Rating.CreateDimension(service, CreateDimensionAPIEndPoint, Thing.BroadcastChannel, bucketID, dimensionID, title, description, maxRating, languageISO);
        }

        /// <summary>
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            Guid bucketID,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
        {
            return await Ratings.Actions.Rating.CreateDimensionAsync(service, CreateDimensionAPIEndPoint, Thing.BroadcastChannel, bucketID, dimensionID, title, description, maxRating, languageISO);
        }

        /// <summary>
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(GameBucket bucket,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
            =>
                service.CreateRatingDimension(bucket.ID, dimensionID, title, description, maxRating, languageISO);

        /// <summary>
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            GameBucket bucket,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
            =>
                await service.CreateRatingDimensionAsync(bucket.ID, dimensionID, title, description, maxRating, languageISO);
    }
}