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
        public async Task<BaseResponse> DeletePlayerAsync(string sessionKey)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.DeletePlayer,
                service,
                DeletePlayerOptions.BuildSessionKeyFormData(sessionKey)
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
        internal static Dictionary<string, string> BuildSessionKeyFormData(string sessionKey)
        {
            var formData = new Dictionary<string, string> { { "sessionKey", sessionKey.ToString() } };
            return formData;
        }
    }
}