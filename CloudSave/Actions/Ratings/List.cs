using System;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.Ratings.Actions;

namespace ConstructServices.CloudSave.Actions;

public static partial class Ratings
{
    extension(CloudSaveServiceBase service)
    {
        /// <summary>
        /// List all Rating Dimensions on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/get-dimensions" />
        [UsedImplicitly]
        public DimensionsResponse ListRatingDimensions(Guid bucketID)
        {
            return service.ListDimensions(Thing.CloudSaveBucket, bucketID, Config.EndPointPaths.Ratings.ListDimensions);
        }

        /// <summary>
        /// List all Rating Dimensions on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/get-dimensions" />
        [UsedImplicitly]
        public async Task<DimensionsResponse> ListRatingDimensionsAsync(Guid bucketID)
        {
            return await service.ListDimensionsAsync(Thing.CloudSaveBucket, bucketID, Config.EndPointPaths.Ratings.ListDimensions);
        }
    }
}