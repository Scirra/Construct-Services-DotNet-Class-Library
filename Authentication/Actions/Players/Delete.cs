using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public BaseResponse DeletePlayer(Guid playerID)
        {
            if (!playerID.IsValidGuid()) return new BaseResponse(Validations.InvalidGuidError);

            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.DeletePlayer,
                service,
                DeletePlayerOptions.BuildPlayerIDFormData(playerID)
            );
        }
        /// <summary>
        /// Delete a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/delete-player" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeletePlayerAsync(Guid playerID)
        {
            if (!playerID.IsValidGuid()) return new BaseResponse(Validations.InvalidGuidError);

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.DeletePlayer,
                service,
                DeletePlayerOptions.BuildPlayerIDFormData(playerID)
            );
        }
    }

    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Delete player account
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/delete-player" />
        [UsedImplicitly]
        public BaseResponse DeletePlayer()
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.DeletePlayer,
                service
            );
        }
        /// <summary>
        /// Delete player account
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/delete-player" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeletePlayerAsync()
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.DeletePlayer,
                service
            );
        }
    }

    private static class DeletePlayerOptions
    {
        internal static Dictionary<string, string> BuildPlayerIDFormData(Guid playerID)
        {
            var formData = new Dictionary<string, string> { { "playerID", playerID.ToString() } };
            return formData;
        }
    }
}