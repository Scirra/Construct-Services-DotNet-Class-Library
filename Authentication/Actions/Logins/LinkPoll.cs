using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Logins
{
    extension(AuthenticationServiceBase service)
    {
        /// <summary>
        /// Poll a link request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/link-poll" />
        [UsedImplicitly]
        public LinkPollResponse LinkPoll(Guid token)
        {
            return Request.ExecuteSyncRequest<LinkPollResponse>(
                Config.EndPointPaths.Logins.LinkPoll,
                service,
                LinkPollOptions.BuildFormData(token)
            );
        }

        /// <summary>
        /// Poll a link request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/link-poll" />
        [UsedImplicitly]
        public async Task<LinkPollResponse> LinkPollAsync(Guid token)
        {
            return await Request.ExecuteAsyncRequest<LinkPollResponse>(
                Config.EndPointPaths.Logins.LinkPoll,
                service,
                LinkPollOptions.BuildFormData(token)
            );
        }
    }
    
    private static class LinkPollOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid token)
        {
            return new Dictionary<string, string>
            {
                { "pollToken", token.ToString() }
            };
        }
    }
}