using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Ratings
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Rate a CloudSave
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/rate-cloud-save" />
        [UsedImplicitly]
        public RateResponse Rate(RateCloudSaveOptions rateCloudSaveOptions)
        {
            return global::ConstructServices.Ratings.Actions.Rating.Rate(service, Config.EndPointPaths.Ratings.Rate, rateCloudSaveOptions);
        }

        /// <summary>
        /// Rate a CloudSave
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/rate-cloud-save" />
        [UsedImplicitly]
        public async Task<RateResponse> RateAsync(RateCloudSaveOptions rateCloudSaveOptions)
        {
            return await global::ConstructServices.Ratings.Actions.Rating.RateAsync(service, Config.EndPointPaths.Ratings.Rate, rateCloudSaveOptions);
        }
    }
}