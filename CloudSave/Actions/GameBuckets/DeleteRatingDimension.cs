using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;

namespace ConstructServices.CloudSave.Actions;

public static partial class RatingDimensions
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(Guid bucketID,
            string dimensionID)
        {
            const string path = "/bucketdeleteratingsdimension.json";
            return Ratings.Actions.Rating.DeleteDimension(service, path, Thing.BroadcastChannel, bucketID, dimensionID);
        }

        /// <summary>
        /// Delete a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(GameBucket bucket,
            string dimensionID) 
            =>
                service.DeleteRatingDimension(bucket.ID, dimensionID);
    }
}