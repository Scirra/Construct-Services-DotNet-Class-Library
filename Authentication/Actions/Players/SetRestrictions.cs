using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Authentication.Objects;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Set restrictions for a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-player-restrictions" />
        [UsedImplicitly]
        public BaseResponse SetPlayerRestrictions(SetPlayerRestrictionsOptions setPlayerRestrictionsOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetRestrictions,
                service,
                setPlayerRestrictionsOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Set restrictions for a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-player-restrictions" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetPlayerRestrictionsAsync(SetPlayerRestrictionsOptions setPlayerRestrictionsOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetRestrictions,
                service,
                setPlayerRestrictionsOptions.BuildFormData()
            );
        }
    }
}
