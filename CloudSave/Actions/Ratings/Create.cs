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
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(
            CreateCloudSaveBucketRatingDimensionOptions createCloudSaveBucketRatingDimensionOptions)
        {
            return global::ConstructServices.Ratings.Actions.Dimensions.CreateDimension(
                service, 
                Config.CreateDimensionAPIEndPoint,
                createCloudSaveBucketRatingDimensionOptions);
        }

        /// <summary>
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            CreateCloudSaveBucketRatingDimensionOptions createCloudSaveBucketRatingDimensionOptions)
        {
            return await global::ConstructServices.Ratings.Actions.Dimensions.CreateDimensionAsync(
                service, 
                Config.CreateDimensionAPIEndPoint,
                createCloudSaveBucketRatingDimensionOptions);
        }
    }
}