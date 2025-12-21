using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string SetUsernamePasswordAPIPath = "/setusernamepassword.json";
    
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse SetUsernameAndPassword(
            string strPlayerID,
            string username,
            string password)
        {
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(strPlayerID);
            if (!playerIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"));
            }
            return service.SetUsernameAndPassword(playerIDValidator.ReturnedObject, username, password);
        }

        [UsedImplicitly]
        public async Task<BaseResponse> SetUsernameAndPasswordAsync(
            string strPlayerID,
            string username,
            string password)
        {
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(strPlayerID);
            if (!playerIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"));
            }
            return await service.SetUsernameAndPasswordAsync(playerIDValidator.ReturnedObject, username, password);
        }

        [UsedImplicitly]
        public BaseResponse SetUsernameAndPassword(
            Guid playerID,
            string username,
            string password)
        {
            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
            {
                return new BaseResponse();
            }

            return Request.ExecuteSyncRequest<BaseResponse>(
                SetUsernamePasswordAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "username", username },
                    { "password", password }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> SetUsernameAndPasswordAsync(
            Guid playerID,
            string username,
            string password)
        {
            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
            {
                return new BaseResponse();
            }

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                SetUsernamePasswordAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "username", username },
                    { "password", password }
                }
            );
        }
    }
}
