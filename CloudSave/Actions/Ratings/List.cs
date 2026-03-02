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
        /// List all Rating Dimensions on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/get-dimensions" />
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(ListCloudSaveBucketDimensionOptions listCloudSaveBucketDimensionOptions)
        {
            return global::ConstructServices.Ratings.Actions.Dimensions.ListDimensions(service, Config.EndPointPaths.Ratings.ListDimensions, listCloudSaveBucketDimensionOptions);
        }

        /// <summary>
        /// List all Rating Dimensions on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/get-dimensions" />
        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(ListCloudSaveBucketDimensionOptions listCloudSaveBucketDimensionOptions)
        {
            return await global::ConstructServices.Ratings.Actions.Dimensions.ListDimensionsAsync(service, Config.EndPointPaths.Ratings.ListDimensions, listCloudSaveBucketDimensionOptions);
        }
    }
}