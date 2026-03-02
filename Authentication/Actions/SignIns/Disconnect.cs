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
}