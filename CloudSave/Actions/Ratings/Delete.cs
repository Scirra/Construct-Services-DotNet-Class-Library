using ConstructServices.Common;
using ConstructServices.Ratings.Actions;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

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
        public BaseResponse DeleteRatingDimension(Guid bucketID, string dimensionID)
            => service.DeleteDimension(Thing.CloudSaveBucket, bucketID, dimensionID, Config.EndPointPaths.Ratings.DeleteDimension);

        /// <summary>
        /// Delete an existing Rating Dimension on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/delete-dimension" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(Guid bucketID, string dimensionID)
            => await service.DeleteDimensionAsync(Thing.CloudSaveBucket, bucketID, dimensionID, Config.EndPointPaths.Ratings.DeleteDimension);
    }
}