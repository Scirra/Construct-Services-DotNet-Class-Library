using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Ratings.Objects;

namespace ConstructServices.CloudSave.Actions;

public static partial class Ratings
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(
            UpdateCloudSaveBucketRatingDimensionOptions updateCloudSaveBucketRatingDimensionOptions)
        {
            return global::ConstructServices.Ratings.Actions.Dimensions.UpdateDimension(service, Config.EditDimensionAPIEndPoint, updateCloudSaveBucketRatingDimensionOptions);
        }

        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> EditRatingDimensionAsync(
            UpdateCloudSaveBucketRatingDimensionOptions updateCloudSaveBucketRatingDimensionOptions)
        {
            return await global::ConstructServices.Ratings.Actions.Dimensions.UpdateDimensionAsync(service, Config.EditDimensionAPIEndPoint, updateCloudSaveBucketRatingDimensionOptions);
        }
    }
}