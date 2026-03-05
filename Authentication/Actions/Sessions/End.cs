using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Sessions
{
    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Ends current Session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/sessions/end-session" />
        [UsedImplicitly]
        public BaseResponse EndSession()
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Sessions.End,
                service
            );
        }

        /// <summary>
        /// Ends current Session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/sessions/end-session" />
        [UsedImplicitly]
        public async Task<BaseResponse> EndSessionAsync()
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Sessions.End,
                service
            );
        }
    }
}