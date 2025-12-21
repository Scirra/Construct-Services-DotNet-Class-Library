using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class RatingDimensions
{
    private const string DeleteDimensionAPIEndPoint = "/bucketdeleteratingsdimension";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(Guid bucketID,
            string dimensionID)
        {
            return Ratings.Actions.Rating.DeleteDimension(service, DeleteDimensionAPIEndPoint, Thing.BroadcastChannel, bucketID, dimensionID);
        }

        /// <summary>
        /// Delete a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(Guid bucketID,
            string dimensionID)
        {
            return await Ratings.Actions.Rating.DeleteDimensionAsync(service, DeleteDimensionAPIEndPoint, Thing.BroadcastChannel, bucketID, dimensionID);
        }

        /// <summary>
        /// Delete a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(GameBucket bucket,
            string dimensionID) 
            =>
                service.DeleteRatingDimension(bucket.ID, dimensionID);

        /// <summary>
        /// Delete a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(GameBucket bucket,
            string dimensionID) 
            =>
                await service.DeleteRatingDimensionAsync(bucket.ID, dimensionID);
    }
}