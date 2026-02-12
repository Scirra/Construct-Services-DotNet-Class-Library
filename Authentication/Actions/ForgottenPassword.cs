using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string ForgottenPasswordAPIPath = "/forgottenpassword.json";
    
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
                ForgottenPasswordAPIPath,
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
                ForgottenPasswordAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "emailAddress", emailAddress }
                }
            );
        }
    }
}