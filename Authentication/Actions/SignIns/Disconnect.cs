using System.Collections.Generic;
using ConstructServices.Authentication.Objects;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class SignIns
{
    
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Disconnect a login provider from a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/disconnect" />
        [UsedImplicitly]
        public BaseResponse DisconnectLoginProvider(DisconnectSignInProviderOptions disconnectSignInProviderOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.SignIns.Disconnect,
                service,
                disconnectSignInProviderOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Disconnect a login provider from a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/disconnect" />
        [UsedImplicitly]
        public async Task<BaseResponse> DisconnectLoginProviderAsync(DisconnectSignInProviderOptions disconnectSignInProviderOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.SignIns.Disconnect,
                service,
                disconnectSignInProviderOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class DisconnectSignInProviderOptions(string sessionKey, LoginProvider provider)
    {
        [UsedImplicitly]
        private string SessionKey { get; } = sessionKey;

        [UsedImplicitly]
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