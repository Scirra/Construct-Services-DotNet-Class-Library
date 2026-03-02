using System.Collections.Generic;
using ConstructServices.Authentication.Objects;
using ConstructServices.Authentication.Responses;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class SignIns
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Link a login provider to a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/link-login-provider" />
        [UsedImplicitly]
        public SignInResponse LinkSignInProvider(LinkSignInProviderOptions linkSignInProviderOptions)
        {
            return Common.Request.ExecuteSyncRequest<SignInResponse>(
                Config.EndPointPaths.SignIns.Link,
                service,
                linkSignInProviderOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Link a login provider to a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/link-login-provider" />
        [UsedImplicitly]
        public async Task<SignInResponse> LinkSignInProviderAsync(LinkSignInProviderOptions linkSignInProviderOptions)
        {
            return await Common.Request.ExecuteAsyncRequest<SignInResponse>(
                Config.EndPointPaths.SignIns.Link,
                service,
                linkSignInProviderOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class LinkSignInProviderOptions(string sessionKey, LoginProvider provider)
    {
        private string SessionKey { get; } = sessionKey;
        private LoginProvider Provider { get; } = provider;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "sessionKey", SessionKey },
                { "provider", Provider.ToString() }
            };
            return formData;
        }
    }
}