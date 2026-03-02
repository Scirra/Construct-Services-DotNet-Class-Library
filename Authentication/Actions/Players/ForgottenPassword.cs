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
        [UsedImplicitly]
        public BaseResponse RequestForgottenPasswordEmail(string emailAddress)
        {
            var validator = Common.Validations.EmailAddress.ValidateEmailAddress(emailAddress);
            if (!validator.Successfull)
            {
                return new BaseResponse(validator.ErrorMessage);
            }

            return Request.ExecuteSyncRequest<LinkLoginProviderResponse>(
                Config.EndPointPaths.Players.ForgottenPassword,
                service,
                new Dictionary<string, string>
                {
                    { "emailAddress", emailAddress }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> RequestForgottenPasswordEmailAsync(string emailAddress)
        {
            var validator = Common.Validations.EmailAddress.ValidateEmailAddress(emailAddress);
            if (!validator.Successfull)
            {
                return new BaseResponse(validator.ErrorMessage);
            }

            return await Request.ExecuteAsyncRequest<LinkLoginProviderResponse>(
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