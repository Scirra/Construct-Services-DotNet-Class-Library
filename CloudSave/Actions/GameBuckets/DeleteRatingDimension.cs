using System;
using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
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
            return Ratings.Actions.Rating.DeleteDimension(service, path, Thing.CloudSaveBucket, bucketID, dimensionID);
        }

        /// <summary>
        /// Delete a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(GameBucket bucket,
            string dimensionID) 
            => DeleteRatingDimension(service, bucket.ID, dimensionID);
    }
}