using ConstructServices.Common;
using ConstructServices.Ratings.Actions;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using static ConstructServices.Ratings.Actions.Rating;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Ratings
{
    extension(PlayerBroadcastService service)
    {
        /// <summary>
        /// Rate a Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/rate-message" />
        [UsedImplicitly]
        public RateResponse Rate(Guid messageID, RateObjectOptions rateObjectOptions)
        {
            return service.Rate(Thing.BroadcastMessage, messageID, Config.EndPointPaths.Ratings.Rate, rateObjectOptions);
        }

        /// <summary>
        /// Rate a Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/rate-message" />
        [UsedImplicitly]
        public async Task<RateResponse> RateAsync(Guid messageID, RateObjectOptions rateObjectOptions)
        {
            return await service.RateAsync(Thing.BroadcastMessage, messageID, Config.EndPointPaths.Ratings.Rate, rateObjectOptions);
        }
    }
}