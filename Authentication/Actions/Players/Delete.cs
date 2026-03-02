using System.Threading.Tasks;
using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{

    extension(AuthenticationService service)
    {
        /// <summary>
        /// Delete a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/delete-player" />
        [UsedImplicitly]
        public BaseResponse DeletePlayer(DeletePlayerOptions deletePlayerOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.DeletePlayer,
                service,
                deletePlayerOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Delete a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/delete-player" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeletePlayerAsync(DeletePlayerOptions deletePlayerOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.DeletePlayer,
                service,
                deletePlayerOptions.BuildFormData()
            );
        }
    }
}