using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Sessions
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Refresh current session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/set-avatar" />
        [UsedImplicitly]
        public BaseResponse RefreshSession()
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Sessions.Refresh,
                service
            );
        }

        /// <summary>
        /// Refresh current session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/set-avatar" />
        [UsedImplicitly]
        public async Task<BaseResponse> RefreshSessionAsync()
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Sessions.Refresh,
                service
            );
        }
    }
}