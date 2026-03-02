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
        /// Rate a CloudSave
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/rate-cloud-save" />
        [UsedImplicitly]
        public RateResponse Rate(Rating.RateCloudSaveOptions rateCloudSaveOptions)
        {
            return service.Rate(Config.EndPointPaths.Ratings.Rate, rateCloudSaveOptions);
        }

        /// <summary>
        /// Rate a CloudSave
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/rate-cloud-save" />
        [UsedImplicitly]
        public async Task<RateResponse> RateAsync(Rating.RateCloudSaveOptions rateCloudSaveOptions)
        {
            return await service.RateAsync(Config.EndPointPaths.Ratings.Rate, rateCloudSaveOptions);
        }
    }
}