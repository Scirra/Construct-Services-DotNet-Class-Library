using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Ratings.Actions;

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
            Dimensions.UpdateCloudSaveBucketRatingDimensionOptions updateCloudSaveBucketRatingDimensionOptions)
        {
            return service.UpdateDimension(Config.EndPointPaths.Ratings.UpdateDimension, updateCloudSaveBucketRatingDimensionOptions);
        }

        /// <summary>
        /// Update an existing Rating Dimension on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/edit-dimension" />
        [UsedImplicitly]
        public async Task<DimensionResponse> UpdateRatingDimensionAsync(
            Dimensions.UpdateCloudSaveBucketRatingDimensionOptions updateCloudSaveBucketRatingDimensionOptions)
        {
            return await service.UpdateDimensionAsync(Config.EndPointPaths.Ratings.UpdateDimension, updateCloudSaveBucketRatingDimensionOptions);
        }
    }
}