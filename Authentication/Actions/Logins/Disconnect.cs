using System.Collections.Generic;
using ConstructServices.Authentication.Objects;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Logins
{
    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Disconnect a login provider
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/disconnect" />
        [UsedImplicitly]
        public BaseResponse DisconnectLoginProvider(LoginProvider provider)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Logins.Disconnect,
                service,
                DisconnectLoginProviderOptions.BuildFormData(provider)
            );
        }

        /// <summary>
        /// Disconnect a login provider
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/disconnect" />
        [UsedImplicitly]
        public async Task<BaseResponse> DisconnectLoginProviderAsync(LoginProvider provider)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Logins.Disconnect,
                service,
                DisconnectLoginProviderOptions.BuildFormData(provider)
            );
        }
    }
    
    private static class DisconnectLoginProviderOptions
    {
        internal static Dictionary<string, string> BuildFormData(LoginProvider provider)
        {
            return new Dictionary<string, string>
            {
                { "provider", provider.ToString() }
            };
        }
    }
}