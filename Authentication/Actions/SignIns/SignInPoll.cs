using ConstructServices.Authentication.Responses;
using System.Threading.Tasks;
using ConstructServices.Authentication.Objects;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class SignIns
{
    
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Poll a sign in request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in-poll" />
        [UsedImplicitly]
        public SignInPollResponse SignInPoll(SignInPollOptions signInPollOptions)
        {
            return Common.Request.ExecuteSyncRequest<SignInPollResponse>(
                Config.EndPointPaths.SignIns.SignInPoll,
                service,
                signInPollOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Poll a sign in request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in-poll" />
        [UsedImplicitly]
        public async Task<SignInPollResponse> SignInPollAsync(SignInPollOptions signInPollOptions)
        {
            return await Common.Request.ExecuteAsyncRequest<SignInPollResponse>(
                Config.EndPointPaths.SignIns.SignInPoll,
                service,
                signInPollOptions.BuildFormData()
            );
        }
    }
}