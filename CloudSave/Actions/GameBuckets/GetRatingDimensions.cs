using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class RatingDimensions
{
    private const string GetDimensionsAPIEndPoint = "/bucketgetratingdimensions.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Get rating dimensions for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(ListCloudSaveBucketDimensionOptions listCloudSaveBucketDimensionOptions)
        {
            return Ratings.Actions.Rating.GetDimensions(service, GetDimensionsAPIEndPoint, listCloudSaveBucketDimensionOptions);
        }

        /// <summary>
        /// Get rating dimensions for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(ListCloudSaveBucketDimensionOptions listCloudSaveBucketDimensionOptions)
        {
            return await Ratings.Actions.Rating.GetDimensionsAsync(service, GetDimensionsAPIEndPoint, listCloudSaveBucketDimensionOptions);
        }
    }
}