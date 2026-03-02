using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Ratings.Actions;

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
            Dimensions.CreateCloudSaveBucketRatingDimensionOptions createCloudSaveBucketRatingDimensionOptions)
        {
            return service.CreateDimension(Config.EndPointPaths.Ratings.CreateDimension,
                createCloudSaveBucketRatingDimensionOptions);
        }

        /// <summary>
        /// Creates a new Rating Dimension for a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/create-dimension" />
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            Dimensions.CreateCloudSaveBucketRatingDimensionOptions createCloudSaveBucketRatingDimensionOptions)
        {
            return await service.CreateDimensionAsync(Config.EndPointPaths.Ratings.CreateDimension,
                createCloudSaveBucketRatingDimensionOptions);
        }
    }
}