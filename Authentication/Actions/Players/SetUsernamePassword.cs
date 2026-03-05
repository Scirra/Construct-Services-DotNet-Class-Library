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
        /// Sets a Players username and password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public BaseResponse SetUsernameAndPassword(Guid playerID, string username, string password)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                SetUsernameAndPasswordOptions.BuildFormData(playerID, username, password)
            );
        }

        /// <summary>
        /// Sets a Players username and password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetUsernameAndPasswordAsync(Guid playerID, string username, string password)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                SetUsernameAndPasswordOptions.BuildFormData(playerID, username, password)
            );
        }
    }

    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Set login username and password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public BaseResponse SetUsernameAndPassword(string username, string password)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                SetUsernameAndPasswordOptions.BuildFormData(username, password)
            );
        }

        /// <summary>
        /// Sets login username and password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetUsernameAndPasswordAsync(string username, string password)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                SetUsernameAndPasswordOptions.BuildFormData(username, password)
            );
        }
    }

    private static class SetUsernameAndPasswordOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid playerID, string username, string password)
        {
            return new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() },
                { "username", username },
                { "password", password }
            };
        }
        internal static Dictionary<string, string> BuildFormData(string username, string password)
        {
            return new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };
        }
    }
}
