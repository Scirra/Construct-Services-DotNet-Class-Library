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
        /// Get rating dimensions for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(ListCloudSaveBucketDimensionOptions listCloudSaveBucketDimensionOptions)
        {
            return global::ConstructServices.Ratings.Actions.Dimensions.ListDimensions(service, Config.GetDimensionsAPIEndPoint, listCloudSaveBucketDimensionOptions);
        }

        /// <summary>
        /// Get rating dimensions for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(ListCloudSaveBucketDimensionOptions listCloudSaveBucketDimensionOptions)
        {
            return await global::ConstructServices.Ratings.Actions.Dimensions.ListDimensionsAsync(service, Config.GetDimensionsAPIEndPoint, listCloudSaveBucketDimensionOptions);
        }
    }
}