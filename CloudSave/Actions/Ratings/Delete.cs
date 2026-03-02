using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Ratings.Actions;

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
            Dimensions.DeleteCloudSaveBucketRatingDimensionOptions deleteCloudSaveBucketRatingDimensionOptions)
            => service.DeleteDimension(Config.EndPointPaths.Ratings.DeleteDimension, deleteCloudSaveBucketRatingDimensionOptions);

        /// <summary>
        /// Delete an existing Rating Dimension on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/delete-dimension" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(
            Dimensions.DeleteCloudSaveBucketRatingDimensionOptions deleteCloudSaveBucketRatingDimensionOptions)
            => await service.DeleteDimensionAsync(Config.EndPointPaths.Ratings.DeleteDimension, deleteCloudSaveBucketRatingDimensionOptions);
    }
}