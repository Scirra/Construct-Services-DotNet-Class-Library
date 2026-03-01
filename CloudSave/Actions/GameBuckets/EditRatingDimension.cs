using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Ratings.Objects;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    private const string EditDimensionAPIEndPoint = "/bucketeditratingdimension.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(
            UpdateCloudSaveBucketRatingDimensionOptions updateCloudSaveBucketRatingDimensionOptions)
        {
            return Ratings.Actions.Rating.UpdateDimension(service, EditDimensionAPIEndPoint, updateCloudSaveBucketRatingDimensionOptions);
        }

        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> EditRatingDimensionAsync(
            UpdateCloudSaveBucketRatingDimensionOptions updateCloudSaveBucketRatingDimensionOptions)
        {
            return await Ratings.Actions.Rating.UpdateDimensionAsync(service, EditDimensionAPIEndPoint, updateCloudSaveBucketRatingDimensionOptions);
        }
    }
}