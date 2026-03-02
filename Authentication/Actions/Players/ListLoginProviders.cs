using System.Collections.Generic;
using ConstructServices.Authentication.Responses;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{

    extension(AuthenticationService service)
    {
        /// <summary>
        /// List connected sign in providers
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/get-login-providers" />
        [UsedImplicitly]
        public GetConnectedLoginProvidersResponse ListLoginProviders(ListLoginProviderOptions listLoginProviderOptions)
        {
            return Common.Request.ExecuteSyncRequest<GetConnectedLoginProvidersResponse>(
                Config.EndPointPaths.Players.ListProviders,
                service,
                listLoginProviderOptions.BuildFormData()
            );
        }

        /// <summary>
        /// List connected sign in providers
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/get-login-providers" />
        [UsedImplicitly]
        public async Task<GetConnectedLoginProvidersResponse> GetLoginProvidersAsync(ListLoginProviderOptions listLoginProviderOptions)
        {
            return await Common.Request.ExecuteAsyncRequest<GetConnectedLoginProvidersResponse>(
                Config.EndPointPaths.Players.ListProviders,
                service,
                listLoginProviderOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class ListLoginProviderOptions(string sessionKey)
    {
        private string SessionKey { get; } = sessionKey;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "sessionKey", SessionKey }
            };
            return formData;
        }
    }
}