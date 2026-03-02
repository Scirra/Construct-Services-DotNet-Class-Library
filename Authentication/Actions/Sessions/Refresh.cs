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

    [UsedImplicitly]
    public sealed class RefreshSessionOptions(string sessionKey)
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