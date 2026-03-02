using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    
    extension(AuthenticationService service)
    {        
        /// <summary>
        /// Request a forgotten password email
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/forgotten-password" />
        [UsedImplicitly]
        public BaseResponse RequestForgottenPasswordEmail(ForgottenPasswordOptions forgottenPasswordOptions)
        {
            return Request.ExecuteSyncRequest<LinkLoginProviderResponse>(
                Config.EndPointPaths.Players.ForgottenPassword,
                service,
                forgottenPasswordOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Request a forgotten password email
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/forgotten-password" />
        [UsedImplicitly]
        public async Task<BaseResponse> RequestForgottenPasswordEmailAsync(ForgottenPasswordOptions forgottenPasswordOptions)
        {
            return await Request.ExecuteAsyncRequest<LinkLoginProviderResponse>(
                Config.EndPointPaths.Players.ForgottenPassword,
                service,
                forgottenPasswordOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class ForgottenPasswordOptions(string emailAddress)
    {
        private string EmailAddress { get; } = emailAddress;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "emailAddress", EmailAddress }
            };
            return formData;
        }
    }
}