using ConstructServices.Ratings.Actions;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using ConstructServices.Common;
using static ConstructServices.Ratings.Actions.Dimensions;

namespace ConstructServices.CloudSave.Actions;

public static partial class Ratings
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Update an existing Rating Dimension on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/edit-dimension" />
        [UsedImplicitly]
        public DimensionResponse UpdateRatingDimension(
            Guid bucketID,
            string dimensionID,
            UpdateRatingDimensionOptions updateRatingDimensionOptions)
        {
            return service.UpdateDimension(
                Thing.CloudSaveBucket,
                bucketID,
                dimensionID,
                Config.EndPointPaths.Ratings.UpdateDimension, 
                updateRatingDimensionOptions);
        }

        /// <summary>
        /// Update an existing Rating Dimension on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/edit-dimension" />
        [UsedImplicitly]
        public async Task<DimensionResponse> UpdateRatingDimensionAsync(
            Guid bucketID,
            string dimensionID,
            UpdateRatingDimensionOptions updateRatingDimensionOptions)
        {
            return await service.UpdateDimensionAsync(
                Thing.CloudSaveBucket,
                bucketID,
                dimensionID,
                Config.EndPointPaths.Ratings.UpdateDimension, 
                updateRatingDimensionOptions);
        }
    }
}