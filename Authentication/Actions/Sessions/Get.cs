using ConstructServices.Authentication.Responses;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Sessions
{
    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Get current Session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/sessions/get-session" />
        [UsedImplicitly]
        public GetSessionResponse GetSession()
        {
            return Common.Request.ExecuteSyncRequest<GetSessionResponse>(
                Config.EndPointPaths.Sessions.Get,
                service
            );
        }

        /// <summary>
        /// Get current Session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/sessions/get-session" />
        [UsedImplicitly]
        public async Task<GetSessionResponse> GetSessionAsync()
        {
            return await Common.Request.ExecuteAsyncRequest<GetSessionResponse>(
                Config.EndPointPaths.Sessions.Get,
                service
            );
        }
    }
}