using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Authentication.Objects;

namespace ConstructServices.Authentication.Actions;

public static partial class Sessions
{
    
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Refresh a Players Session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/set-avatar" />
        [UsedImplicitly]
        public BaseResponse RefreshSession(RefreshSessionOptions refreshSessionOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Sessions.Refresh,
                service,
                refreshSessionOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Refresh a Players Session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/set-avatar" />
        [UsedImplicitly]
        public async Task<BaseResponse> RefreshSessionAsync(RefreshSessionOptions refreshSessionOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Sessions.Refresh,
                service,
                refreshSessionOptions.BuildFormData()
            );
        }
    }
}