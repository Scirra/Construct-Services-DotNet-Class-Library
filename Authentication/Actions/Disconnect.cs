using ConstructServices.Authentication.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string DisconnectAPIPath = "/disconnect.json";
    
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse DisconnectLoginProvider(
            string sessionKey,
            LoginProvider provider)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage, false);
            }

            return Request.ExecuteSyncRequest<BaseResponse>(
                DisconnectAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey },
                    { "provider", provider.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> DisconnectLoginProviderAsync(
            string sessionKey,
            LoginProvider provider)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage, false);
            }

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DisconnectAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey },
                    { "provider", provider.ToString() }
                }
            );
        }
    }
}