using ConstructServices.Common;
using ConstructServices.Ratings.Objects;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class RatingDimensions
{
    private const string DeleteDimensionAPIEndPoint = "/bucketdeleteratingsdimension.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(
            DeleteCloudSaveBucketRatingDimensionOptions deleteCloudSaveBucketRatingDimensionOptions)
            => Ratings.Actions.Dimensions.DeleteDimension(service, DeleteDimensionAPIEndPoint, deleteCloudSaveBucketRatingDimensionOptions);

        /// <summary>
        /// Delete a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(
            DeleteCloudSaveBucketRatingDimensionOptions deleteCloudSaveBucketRatingDimensionOptions)
            => await Ratings.Actions.Dimensions.DeleteDimensionAsync(service, DeleteDimensionAPIEndPoint, deleteCloudSaveBucketRatingDimensionOptions);
    }
}