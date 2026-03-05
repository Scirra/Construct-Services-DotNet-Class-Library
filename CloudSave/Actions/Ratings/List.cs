using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Ratings.Actions;

namespace ConstructServices.CloudSave.Actions;

public static partial class Ratings
{
    extension(CloudSaveServiceBase service)
    {
        /// <summary>
        /// List all Rating Dimensions on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/get-dimensions" />
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(Dimensions.ListCloudSaveBucketDimensionOptions listCloudSaveBucketDimensionOptions)
        {
            return service.ListDimensions(Config.EndPointPaths.Ratings.ListDimensions, listCloudSaveBucketDimensionOptions);
        }

        /// <summary>
        /// List all Rating Dimensions on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/get-dimensions" />
        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(Dimensions.ListCloudSaveBucketDimensionOptions listCloudSaveBucketDimensionOptions)
        {
            return await service.ListDimensionsAsync(Config.EndPointPaths.Ratings.ListDimensions, listCloudSaveBucketDimensionOptions);
        }
    }
}