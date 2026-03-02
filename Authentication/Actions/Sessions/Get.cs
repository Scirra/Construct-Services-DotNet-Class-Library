using ConstructServices.Authentication.Responses;
using System.Threading.Tasks;
using ConstructServices.Authentication.Objects;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Sessions
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Get a Session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/sessions/get-session" />
        [UsedImplicitly]
        public GetSessionResponse GetSession(GetSessionOptions getSessionOptions)
        {
            return Common.Request.ExecuteSyncRequest<GetSessionResponse>(
                Config.EndPointPaths.Sessions.Get,
                service,
                getSessionOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get a Session
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/sessions/get-session" />
        [UsedImplicitly]
        public async Task<GetSessionResponse> GetSessionAsync(GetSessionOptions getSessionOptions)
        {
            return await Common.Request.ExecuteAsyncRequest<GetSessionResponse>(
                Config.EndPointPaths.Sessions.Get,
                service,
                getSessionOptions.BuildFormData()
            );
        }
    }
}