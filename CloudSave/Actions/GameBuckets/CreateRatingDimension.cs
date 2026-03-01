using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class RatingDimensions
{
    private const string CreateDimensionAPIEndPoint = "/bucketcreateratingdimension.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(
            CreateCloudSaveBucketRatingDimensionOptions createCloudSaveBucketRatingDimensionOptions)
        {
            return Ratings.Actions.Rating.CreateDimension(
                service, 
                CreateDimensionAPIEndPoint,
                createCloudSaveBucketRatingDimensionOptions);
        }

        /// <summary>
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            CreateCloudSaveBucketRatingDimensionOptions createCloudSaveBucketRatingDimensionOptions)
        {
            return await Ratings.Actions.Rating.CreateDimensionAsync(
                service, 
                CreateDimensionAPIEndPoint,
                createCloudSaveBucketRatingDimensionOptions);
        }
    }
}