using ConstructServices.Authentication.Objects;
using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;
public static partial class Players
{
    private const string LinkProviderAPIPath = "/link.json";
    
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public SignInResponse LinkLoginProvider(LoginProvider provider,
            string sessionKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new SignInResponse(sessionKeyValidator.ErrorMessage, false);
            }

            return Common.Request.ExecuteSyncRequest<SignInResponse>(
                LinkProviderAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "provider", provider.ToString() },
                    { "sessionKey", sessionKey }
                }
            );
        }

        [UsedImplicitly]
        public async Task<SignInResponse> LinkLoginProviderAsync(LoginProvider provider,
            string sessionKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new SignInResponse(sessionKeyValidator.ErrorMessage, false);
            }

            return await Common.Request.ExecuteAsyncRequest<SignInResponse>(
                LinkProviderAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "provider", provider.ToString() },
                    { "sessionKey", sessionKey }
                }
            );
        }
    }
}