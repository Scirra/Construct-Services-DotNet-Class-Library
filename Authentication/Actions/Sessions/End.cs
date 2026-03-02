using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

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

    [UsedImplicitly]
    public sealed class EndSessionOptions(string sessionKey)
    {
        private string SessionKey { get; } = sessionKey;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }
            return formData;
        }
    }
}