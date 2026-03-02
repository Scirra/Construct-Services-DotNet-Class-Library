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
        public SignInResponse LinkLoginProvider(LinkSignInProviderOptions linkSignInProviderOptions)
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
        public async Task<SignInResponse> LinkLoginProviderAsync(LinkSignInProviderOptions linkSignInProviderOptions)
        {
            return await Common.Request.ExecuteAsyncRequest<SignInResponse>(
                Config.EndPointPaths.SignIns.Link,
                service,
                linkSignInProviderOptions.BuildFormData()
            );
        }
    }
}