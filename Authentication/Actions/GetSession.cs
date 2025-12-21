using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string GetSessionAPIPath = "/getsession.json";
    
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public GetSessionResponse GetSession(string sessionKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new GetSessionResponse(sessionKeyValidator.ErrorMessage, false);
            }

            return Common.Request.ExecuteSyncRequest<GetSessionResponse>(
                GetSessionAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            );
        }

        [UsedImplicitly]
        public async Task<GetSessionResponse> GetSessionAsync(string sessionKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new GetSessionResponse(sessionKeyValidator.ErrorMessage, false);
            }

            return await Common.Request.ExecuteAsyncRequest<GetSessionResponse>(
                GetSessionAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            );
        }
    }
}