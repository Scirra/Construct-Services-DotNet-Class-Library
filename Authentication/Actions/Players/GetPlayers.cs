using ConstructServices.Authentication.Objects;
using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Get multiple Players
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-players" />
        [UsedImplicitly]
        public GetPlayersResponse GetPlayers(GetPlayersOptions getPlayersOptions, PaginationOptions pagination = null)
        {
            return Request.ExecuteSyncRequest<GetPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                getPlayersOptions.BuildFormData(),
                pagination
            );
        }

        /// <summary>
        /// Get multiple Players
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-players" />
        [UsedImplicitly]
        public async Task<GetPlayersResponse> GetPlayersAsync(GetPlayersOptions getPlayersOptions, PaginationOptions pagination = null)
        {
            return await Request.ExecuteAsyncRequest<GetPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                getPlayersOptions.BuildFormData(),
                pagination
            );
        }
    }
}