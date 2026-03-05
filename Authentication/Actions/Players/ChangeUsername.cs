using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Change a Players login username
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public BaseResponse ChangeUsername(Guid playerID, string newUsername)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                ChangeUsernameOptions.BuildFormData(playerID, newUsername)
            );
        }

        /// <summary>
        /// Change a Players login username
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public async Task<BaseResponse> ChangeUsernameAsync(Guid playerID, string newUsername)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                ChangeUsernameOptions.BuildFormData(playerID, newUsername)
            );
        }
    }

    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Change login username
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public BaseResponse ChangeUsername(string newUsername)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                ChangeUsernameOptions.BuildFormData(newUsername)
            );
        }

        /// <summary>
        /// Change login username
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public async Task<BaseResponse> ChangeUsernameAsync(string newUsername)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                ChangeUsernameOptions.BuildFormData(newUsername)
            );
        }
    }
    
    private static class ChangeUsernameOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid playerID, string newUsername)
        {
            return new Dictionary<string, string>
            {
                { "username", newUsername },
                { "playerID", playerID.ToString() }
            };
        }
        internal static Dictionary<string, string> BuildFormData(string newUsername)
        {
            return new Dictionary<string, string>
            {
                { "username", newUsername }
            };
        }
    }
}