using System.Threading.Tasks;
using ConstructServices.Authentication.Objects;
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
        public LinkPollResponse LinkPoll(SignInPollOptions signInPollOptions)
        {
            return Common.Request.ExecuteSyncRequest<LinkPollResponse>(
                Config.EndPointPaths.SignIns.LinkPoll,
                service,
                signInPollOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Poll a link request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/link-poll" />
        [UsedImplicitly]
        public async Task<LinkPollResponse> LinkPollAsync(SignInPollOptions signInPollOptions)
        {
            return await Common.Request.ExecuteAsyncRequest<LinkPollResponse>(
                Config.EndPointPaths.SignIns.LinkPoll,
                service,
                signInPollOptions.BuildFormData()
            );
        }
    }
}