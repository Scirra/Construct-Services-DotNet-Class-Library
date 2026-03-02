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
        /// Ends a players Session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/sessions/end-session" />
        [UsedImplicitly]
        public BaseResponse EndSession(EndSessionOptions endSessionOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Sessions.End,
                service,
                endSessionOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Ends a players Session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/sessions/end-session" />
        [UsedImplicitly]
        public async Task<BaseResponse> EndSessionAsync(EndSessionOptions endSessionOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Sessions.End,
                service,
                endSessionOptions.BuildFormData()
            );
        }
    }
}