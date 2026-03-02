using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Authentication.Responses;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class SignIns
{
    
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Poll a link request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/link-poll" />
        [UsedImplicitly]
        public LinkPollResponse LinkPoll(LinkPollOptions linkPollOptions)
        {
            return Common.Request.ExecuteSyncRequest<LinkPollResponse>(
                Config.EndPointPaths.SignIns.LinkPoll,
                service,
                linkPollOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Poll a link request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/link-poll" />
        [UsedImplicitly]
        public async Task<LinkPollResponse> LinkPollAsync(LinkPollOptions linkPollOptions)
        {
            return await Common.Request.ExecuteAsyncRequest<LinkPollResponse>(
                Config.EndPointPaths.SignIns.LinkPoll,
                service,
                linkPollOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class LinkPollOptions(Guid token)
    {
        private Guid Token { get; } = token;
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "pollToken", Token.ToString() }
            };
            return formData;
        }
    }
}