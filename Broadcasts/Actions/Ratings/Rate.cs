using System.Threading.Tasks;
using ConstructServices.Ratings.Actions;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;

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
        public RateResponse Rate(Rating.RateBroadcastMessageOptions rateBroadcastMessageOptions)
        {
            return service.Rate(Config.EndPointPaths.Ratings.Rate, rateBroadcastMessageOptions);
        }

        /// <summary>
        /// Rate a Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/rate-message" />
        [UsedImplicitly]
        public async Task<RateResponse> RateAsync(Rating.RateBroadcastMessageOptions rateBroadcastMessageOptions)
        {
            return await service.RateAsync(Config.EndPointPaths.Ratings.Rate, rateBroadcastMessageOptions);
        }
    }
}