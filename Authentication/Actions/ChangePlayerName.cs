using ConstructServices.Common;
using ConstructServices.Common.Validations;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guid = System.Guid;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string changePlayerNameAPIPath = "/changeplayername.json";

    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse ChangePlayerName(
            Guid playerID,
            string newPlayerName)
        {
            var playerNameValidator = newPlayerName.ValidatePlayerName();
            if (!playerNameValidator.Successfull)
            {
                return new BaseResponse(playerNameValidator.ErrorMessage);
            }
            
            return Request.ExecuteSyncRequest<BaseResponse>(
                changePlayerNameAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "playerName", newPlayerName }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> ChangePlayerNameAsync(
            Guid playerID,
            string newPlayerName)
        {
            var playerNameValidator = newPlayerName.ValidatePlayerName();
            if (!playerNameValidator.Successfull)
            {
                return new BaseResponse(playerNameValidator.ErrorMessage);
            }

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                changePlayerNameAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "playerName", newPlayerName }
                }
            );
        }

        [UsedImplicitly]
        public BaseResponse ChangePlayerName(
            string sessionKey,
            string newPlayerName)
        {
            var sessionKeyValidator = sessionKey.ValidatePlayerSessionKey();
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage);
            }
            var playerNameValidator = newPlayerName.ValidatePlayerName();
            if (!playerNameValidator.Successfull)
            {
                return new BaseResponse(playerNameValidator.ErrorMessage);
            }

            return Request.ExecuteSyncRequest<BaseResponse>(
                changePlayerNameAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey },
                    { "playerName", newPlayerName }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> ChangePlayerNameAsync(
            string sessionKey,
            string newPlayerName)
        {
            var sessionKeyValidator = sessionKey.ValidatePlayerSessionKey();
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage);
            }
            var playerNameValidator = newPlayerName.ValidatePlayerName();
            if (!playerNameValidator.Successfull)
            {
                return new BaseResponse(playerNameValidator.ErrorMessage);
            }

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                changePlayerNameAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey },
                    { "playerName", newPlayerName }
                }
            );
        }
    }
}