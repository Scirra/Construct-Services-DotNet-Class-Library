using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string DeletePlayerAPIPath = "/deleteplayer.json";

    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse DeletePlayer(Guid playerID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                DeletePlayerAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> DeletePlayerAsync(Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeletePlayerAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public BaseResponse DeletePlayer(string sessionKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage);
            }

            return Request.ExecuteSyncRequest<BaseResponse>(
                DeletePlayerAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> DeletePlayerAsync(string sessionKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage);
            }

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeletePlayerAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            );
        }
    }
}