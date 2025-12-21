using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common.Validations;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string SignInPollAPIPath = "/signinpoll.json";
    
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public SignInPollResponse SignIn(string pollToken)
        {
            var tokenValidator = pollToken.IsValidGuid();
            if (!tokenValidator.Successfull)
            {
                return new SignInPollResponse(string.Format(tokenValidator.ErrorMessage, "Poll token"));
            }
            return service.SignIn(tokenValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<SignInPollResponse> SignInAsync(string pollToken)
        {
            var tokenValidator = pollToken.IsValidGuid();
            if (!tokenValidator.Successfull)
            {
                return new SignInPollResponse(string.Format(tokenValidator.ErrorMessage, "Poll token"));
            }
            return await service.SignInAsync(tokenValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public SignInPollResponse SignIn(System.Guid pollToken)
        {
            return Common.Request.ExecuteSyncRequest<SignInPollResponse>(
                SignInPollAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "pollToken", pollToken.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public async Task<SignInPollResponse> SignInAsync(System.Guid pollToken)
        {
            return await Common.Request.ExecuteAsyncRequest<SignInPollResponse>(
                SignInPollAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "pollToken", pollToken.ToString() }
                }
            );
        }
    }
}