using ConstructServices.Authentication.Responses;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{

    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// List connected login providers
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/get-login-providers" />
        [UsedImplicitly]
        public GetConnectedLoginProvidersResponse ListLoginProviders()
        {
            return Common.Request.ExecuteSyncRequest<GetConnectedLoginProvidersResponse>(
                Config.EndPointPaths.Players.ListProviders,
                service
            );
        }

        /// <summary>
        /// List connected login providers
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/get-login-providers" />
        [UsedImplicitly]
        public async Task<GetConnectedLoginProvidersResponse> ListLoginProvidersAsync()
        {
            return await Common.Request.ExecuteAsyncRequest<GetConnectedLoginProvidersResponse>(
                Config.EndPointPaths.Players.ListProviders,
                service
            );
        }
    }
}