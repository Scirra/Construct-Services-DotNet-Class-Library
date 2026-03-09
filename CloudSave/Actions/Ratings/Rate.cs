using ConstructServices.Ratings.Actions;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using ConstructServices.Common;
using static ConstructServices.Ratings.Actions.Rating;

namespace ConstructServices.CloudSave.Actions;

public static partial class Ratings
{
    extension(PlayerCloudSaveService service)
    {
        /// <summary>
        /// Rate a CloudSave
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/rate-cloud-save" />
        [UsedImplicitly]
        public RateResponse Rate(Guid cloudSaveID, RateObjectOptions rateObjectOptions)
        {
            return service.Rate(Thing.CloudSave, cloudSaveID, Config.EndPointPaths.Ratings.Rate, rateObjectOptions);
        }

        /// <summary>
        /// Rate a CloudSave
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/ratings/rate-cloud-save" />
        [UsedImplicitly]
        public async Task<RateResponse> RateAsync(Guid cloudSaveID, RateObjectOptions rateObjectOptions)
        {
            return await service.RateAsync(Thing.CloudSave, cloudSaveID, Config.EndPointPaths.Ratings.Rate, rateObjectOptions);
        }
    }
}