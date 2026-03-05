using System.Collections.Generic;
using ConstructServices.Authentication.Objects;
using ConstructServices.Authentication.Responses;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Logins
{
    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Link a login provider to a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/link-login-provider" />
        [UsedImplicitly]
        public LoginResponse LinkLoginProvider(LoginProvider provider)
        {
            return Common.Request.ExecuteSyncRequest<LoginResponse>(
                Config.EndPointPaths.Logins.Link,
                service,
                LinkLoginProviderOptions.BuildFormData(provider)
            );
        }

        /// <summary>
        /// Link a login provider to a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/link-login-provider" />
        [UsedImplicitly]
        public async Task<LoginResponse> LinkLoginProviderAsync(LoginProvider provider)
        {
            return await Common.Request.ExecuteAsyncRequest<LoginResponse>(
                Config.EndPointPaths.Logins.Link,
                service,
                LinkLoginProviderOptions.BuildFormData(provider)
            );
        }
    }
    
    private static class LinkLoginProviderOptions
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