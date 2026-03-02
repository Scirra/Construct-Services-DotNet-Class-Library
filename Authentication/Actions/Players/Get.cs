using ConstructServices.Authentication.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Authentication.Objects;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Get a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-player" />
        [UsedImplicitly]
        public GetPlayerResponse GetPlayer(GetPlayerOptions getPlayerOptions)
        {
            return Common.Request.ExecuteSyncRequest<GetPlayerResponse>(
                Config.EndPointPaths.Players.GetPlayer,
                service,
                getPlayerOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-player" />
        [UsedImplicitly]
        public async Task<GetPlayerResponse> GetPlayerAsync(GetPlayerOptions getPlayerOptions)
        {
            return await Common.Request.ExecuteAsyncRequest<GetPlayerResponse>(
                Config.EndPointPaths.Players.GetPlayer,
                service,
                getPlayerOptions.BuildFormData()
            );
        }
    }
}