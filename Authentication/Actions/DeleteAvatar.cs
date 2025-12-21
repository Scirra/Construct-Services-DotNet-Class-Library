using ConstructServices.Common;
using ConstructServices.Common.Validations;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guid = System.Guid;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string DeleteAvatarAPIPath = "/deleteavatar.json";

    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse DeleteAvatar(Guid playerID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                DeleteAvatarAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> DeleteAvatarAsync(Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeleteAvatarAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public BaseResponse DeleteAvatar(string sessionKey)
        {
            var sessionKeyValidator = sessionKey.ValidatePlayerSessionKey();
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage);
            }

            return Request.ExecuteSyncRequest<BaseResponse>(
                DeleteAvatarAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> DeleteAvatarAsync(string sessionKey)
        {
            var sessionKeyValidator = sessionKey.ValidatePlayerSessionKey();
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage);
            }

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeleteAvatarAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            );
        }
    }
}