using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Ratings.Objects;

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
        public DimensionResponse EditRatingDimension(
            UpdateCloudSaveBucketRatingDimensionOptions updateCloudSaveBucketRatingDimensionOptions)
        {
            return global::ConstructServices.Ratings.Actions.Dimensions.UpdateDimension(service, Config.EndPointPaths.Ratings.UpdateDimension, updateCloudSaveBucketRatingDimensionOptions);
        }

        /// <summary>
        /// Update an existing Rating Dimension on a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/edit-dimension" />
        [UsedImplicitly]
        public async Task<DimensionResponse> EditRatingDimensionAsync(
            UpdateCloudSaveBucketRatingDimensionOptions updateCloudSaveBucketRatingDimensionOptions)
        {
            return await global::ConstructServices.Ratings.Actions.Dimensions.UpdateDimensionAsync(service, Config.EndPointPaths.Ratings.UpdateDimension, updateCloudSaveBucketRatingDimensionOptions);
        }
    }
}