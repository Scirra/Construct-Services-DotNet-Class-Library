using System.Collections.Generic;
using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationServiceBase service)
    {        
        /// <summary>
        /// Request a forgotten password email
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/forgotten-password" />
        [UsedImplicitly]
        public BaseResponse RequestForgottenPasswordEmail(string emailAddress)
        {
            return Request.ExecuteSyncRequest<LinkLoginProviderResponse>(
                Config.EndPointPaths.Players.ForgottenPassword,
                service,
                new Dictionary<string, string>
                {
                    { "emailAddress", emailAddress }
                }
            );
        }
    }
}