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
        /// Delete an existing Rating Dimension on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/delete-dimension" />
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(
            DeleteCloudSaveBucketRatingDimensionOptions deleteCloudSaveBucketRatingDimensionOptions)
            => global::ConstructServices.Ratings.Actions.Dimensions.DeleteDimension(service, Config.EndPointPaths.Ratings.DeleteDimension, deleteCloudSaveBucketRatingDimensionOptions);

        /// <summary>
        /// Delete an existing Rating Dimension on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/delete-dimension" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(
            DeleteCloudSaveBucketRatingDimensionOptions deleteCloudSaveBucketRatingDimensionOptions)
            => await global::ConstructServices.Ratings.Actions.Dimensions.DeleteDimensionAsync(service, Config.EndPointPaths.Ratings.DeleteDimension, deleteCloudSaveBucketRatingDimensionOptions);
    }
}