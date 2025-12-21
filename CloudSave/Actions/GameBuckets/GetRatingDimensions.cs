using ConstructServices.CloudSave.Objects;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
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
        public DimensionsResponse GetRatingDimensions(Guid bucketID)
        {
            return Ratings.Actions.Rating.GetDimensions(service, GetDimensionsAPIEndPoint, Thing.BroadcastChannel, bucketID);
        }

        /// <summary>
        /// Get rating dimensions for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(Guid bucketID)
        {
            return await Ratings.Actions.Rating.GetDimensionsAsync(service, GetDimensionsAPIEndPoint, Thing.BroadcastChannel, bucketID);
        }

        /// <summary>
        /// Get rating dimensions for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(string strBucketID)
        {
            var bucketIDValidator = Common.Validations.Guid.IsValidGuid(strBucketID);
            if (!bucketIDValidator.Successfull)
            {
                return new DimensionsResponse(string.Format(bucketIDValidator.ErrorMessage, "Bucket ID"));
            }
            return Ratings.Actions.Rating.GetDimensions(service, GetDimensionsAPIEndPoint, Thing.BroadcastChannel, bucketIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Get rating dimensions for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(string strBucketID)
        {
            var bucketIDValidator = Common.Validations.Guid.IsValidGuid(strBucketID);
            if (!bucketIDValidator.Successfull)
            {
                return new DimensionsResponse(string.Format(bucketIDValidator.ErrorMessage, "Bucket ID"));
            }
            return await Ratings.Actions.Rating.GetDimensionsAsync(service, GetDimensionsAPIEndPoint, Thing.BroadcastChannel, bucketIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Get rating dimensions for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(GameBucket bucket)
            => service.GetRatingDimensions(bucket.ID);

        /// <summary>
        /// Get rating dimensions for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(GameBucket bucket)
            => await service.GetRatingDimensionsAsync(bucket.ID);
    }
}