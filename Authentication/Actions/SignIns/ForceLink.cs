using ConstructServices.Authentication.Objects;
using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class SignIns
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Force link a login provider with another Player to current Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/force-link" />
        [UsedImplicitly]
        public LinkLoginProviderResponse ForceLinkLoginProvider(ForceLinkOptions forceLinkOptions)
        {
            return Request.ExecuteSyncRequest<LinkLoginProviderResponse>(
                Config.EndPointPaths.SignIns.ForceLink,
                service,
                forceLinkOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Force link a login provider with another Player to current Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/force-link" />
        [UsedImplicitly]
        public async Task<LinkLoginProviderResponse> ForceLinkLoginProviderAsync(ForceLinkOptions forceLinkOptions)
        {
            return await Request.ExecuteAsyncRequest<LinkLoginProviderResponse>(
                Config.EndPointPaths.SignIns.ForceLink,
                service,
                forceLinkOptions.BuildFormData()
            );
        }
    }
}