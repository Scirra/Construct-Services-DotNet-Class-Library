using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

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
            CreateCloudSaveBucketRatingDimensionOptions createCloudSaveBucketRatingDimensionOptions)
        {
            return global::ConstructServices.Ratings.Actions.Dimensions.CreateDimension(
                service, 
                Config.EndPointPaths.Ratings.CreateDimension,
                createCloudSaveBucketRatingDimensionOptions);
        }

        /// <summary>
        /// Creates a new Rating Dimension for a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/create-dimension" />
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            CreateCloudSaveBucketRatingDimensionOptions createCloudSaveBucketRatingDimensionOptions)
        {
            return await global::ConstructServices.Ratings.Actions.Dimensions.CreateDimensionAsync(
                service, 
                Config.EndPointPaths.Ratings.CreateDimension,
                createCloudSaveBucketRatingDimensionOptions);
        }
    }
}