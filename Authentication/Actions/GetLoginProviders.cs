using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string GetProvidersAPIPath = "/getconnectedloginproviders.json";

    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public GetConnectedLoginProvidersResponse GetLoginProviders(string sessionKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new GetConnectedLoginProvidersResponse(sessionKeyValidator.ErrorMessage, false);
            }

            return Common.Request.ExecuteSyncRequest<GetConnectedLoginProvidersResponse>(
                GetProvidersAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            );
        }

        [UsedImplicitly]
        public async Task<GetConnectedLoginProvidersResponse> GetLoginProvidersAsync(string sessionKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new GetConnectedLoginProvidersResponse(sessionKeyValidator.ErrorMessage, false);
            }

            return await Common.Request.ExecuteAsyncRequest<GetConnectedLoginProvidersResponse>(
                GetProvidersAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            );
        }
    }
}