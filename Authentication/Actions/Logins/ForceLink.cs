using System.Collections.Generic;
using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Logins
{
    extension(AuthenticationServiceBase service)
    {
        /// <summary>
        /// Force link a login provider with another Player to current Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/force-link" />
        [UsedImplicitly]
        public LinkLoginProviderResponse ForceLinkLoginProvider(string code)
        {
            return Request.ExecuteSyncRequest<LinkLoginProviderResponse>(
                Config.EndPointPaths.Logins.ForceLink,
                service,
                ForceLinkOptions.BuildFormData(code)
            );
        }

        /// <summary>
        /// Force link a login provider with another Player to current Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/force-link" />
        [UsedImplicitly]
        public async Task<LinkLoginProviderResponse> ForceLinkLoginProviderAsync(string code)
        {
            return await Request.ExecuteAsyncRequest<LinkLoginProviderResponse>(
                Config.EndPointPaths.Logins.ForceLink,
                service,
                ForceLinkOptions.BuildFormData(code)
            );
        }
    }
    
    private static class ForceLinkOptions
    {
        internal static Dictionary<string, string> BuildFormData(string code)
        {
            var formData = new Dictionary<string, string>
            {
                { "code", code }
            };
            return formData;
        }
    }
}