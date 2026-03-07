using ConstructServices.Ratings.Actions;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using ConstructServices.Common;
using static ConstructServices.Ratings.Actions.Dimensions;

namespace ConstructServices.CloudSave.Actions;

public static partial class Ratings
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Creates a new Rating Dimension for a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/create-dimension" />
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(
            Guid bucketID,
            CreateRatingDimensionOptions createRatingDimensionOptions)
        {
            return service.CreateDimension(
                Thing.CloudSaveBucket,
                bucketID,
                Config.EndPointPaths.Ratings.CreateDimension,
                createRatingDimensionOptions);
        }

        /// <summary>
        /// Creates a new Rating Dimension for a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/create-dimension" />
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            Guid bucketID,
            CreateRatingDimensionOptions createRatingDimensionOptions)
        {
            return await service.CreateDimensionAsync(
                Thing.CloudSaveBucket,
                bucketID,
                Config.EndPointPaths.Ratings.CreateDimension,
                createRatingDimensionOptions);
        }
    }
}