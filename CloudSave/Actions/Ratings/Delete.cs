using ConstructServices.Common;
using ConstructServices.Ratings.Objects;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Ratings
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(
            DeleteCloudSaveBucketRatingDimensionOptions deleteCloudSaveBucketRatingDimensionOptions)
            => global::ConstructServices.Ratings.Actions.Dimensions.DeleteDimension(service, Config.DeleteDimensionAPIEndPoint, deleteCloudSaveBucketRatingDimensionOptions);

        /// <summary>
        /// Delete a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(
            DeleteCloudSaveBucketRatingDimensionOptions deleteCloudSaveBucketRatingDimensionOptions)
            => await global::ConstructServices.Ratings.Actions.Dimensions.DeleteDimensionAsync(service, Config.DeleteDimensionAPIEndPoint, deleteCloudSaveBucketRatingDimensionOptions);
    }
}