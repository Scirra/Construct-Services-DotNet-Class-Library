using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string RefreshAPIPath = "/link.json";
    
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse RefreshSession(string sessionKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage, false);
            }

            return Request.ExecuteSyncRequest<BaseResponse>(
                RefreshAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> RefreshSessionAsync(string sessionKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage, false);
            }

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                RefreshAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            );
        }
    }
}