using System.Threading.Tasks;
using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Ratings
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Rate a Broadcast Message object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/rate-message" />
        [UsedImplicitly]
        public RateResponse Rate(RateBroadcastMessageOptions rateBroadcastMessageOptions)
        {
            return global::ConstructServices.Ratings.Actions.Rating.Rate(service, Config.RateMessageAPIEndPoint, rateBroadcastMessageOptions);
        }

        /// <summary>
        /// Rate a Broadcast Message object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/rate-message" />
        [UsedImplicitly]
        public async Task<RateResponse> RateAsync(RateBroadcastMessageOptions rateBroadcastMessageOptions)
        {
            return await global::ConstructServices.Ratings.Actions.Rating.RateAsync(service, Config.RateMessageAPIEndPoint, rateBroadcastMessageOptions);
        }
    }
}