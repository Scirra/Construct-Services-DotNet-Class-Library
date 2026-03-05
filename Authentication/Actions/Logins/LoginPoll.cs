using System;
using System.Collections.Generic;
using ConstructServices.Authentication.Responses;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Logins
{
    extension(AuthenticationServiceBase service)
    {
        /// <summary>
        /// Poll a login request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in-poll" />
        [UsedImplicitly]
        public LoginPollResponse LoginPoll(Guid token)
        {
            if (!token.IsValidGuid()) return new LoginPollResponse(Validations.InvalidGuidError);

            return Request.ExecuteSyncRequest<LoginPollResponse>(
                Config.EndPointPaths.Logins.LoginPoll,
                service,
                LoginPollOptions.BuildFormData(token)
            );
        }

        /// <summary>
        /// Poll a login request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in-poll" />
        [UsedImplicitly]
        public async Task<LoginPollResponse> LoginPollAsync(Guid token)
        {
            if (!token.IsValidGuid()) return new LoginPollResponse(Validations.InvalidGuidError);

            return await Request.ExecuteAsyncRequest<LoginPollResponse>(
                Config.EndPointPaths.Logins.LoginPoll,
                service,
                LoginPollOptions.BuildFormData(token)
            );
        }
    }
    
    [UsedImplicitly]
    private static class LoginPollOptions
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