using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.Common.Validations;
using JetBrains.Annotations;
using Guid = System.Guid;

namespace ConstructServices.Authentication.Actions;

[UsedImplicitly]
public static partial class Players
{
    private const string ChangePasswordAPIPath = "/changepassword.json";

    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse ChangePassword(
            Guid playerID,
            string newPassword)
        {
            var passwordValidator = newPassword.ValidatePlayerPassword();
            if (!passwordValidator.Successfull)
            {
                return new BaseResponse(string.Format(passwordValidator.ErrorMessage, "New password"));
            }

            return Request.ExecuteSyncRequest<BaseResponse>(
                ChangePasswordAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "newPassword", newPassword }
                }
            );
        }

        [UsedImplicitly]
        public BaseResponse ChangePassword(
            string strPlayerID,
            string newPassword)
        {
            var playerIDValidator = strPlayerID.IsValidGuid();
            if (!playerIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"));
            }
            return service.ChangePassword(playerIDValidator.ReturnedObject, newPassword);
        }
        
        [UsedImplicitly]
        public async Task<BaseResponse> ChangePasswordAsync(
            Guid playerID,
            string newPassword)
        {
            var passwordValidator = newPassword.ValidatePlayerPassword();
            if (!passwordValidator.Successfull)
            {
                return new BaseResponse(string.Format(passwordValidator.ErrorMessage, "New password"));
            }

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                ChangePasswordAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "newPassword", newPassword }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> ChangePasswordAsync(
            string strPlayerID,
            string newPassword)
        {
            var validator = strPlayerID.IsValidGuid();
            if (!validator.Successfull)
            {
                return new BaseResponse(string.Format(validator.ErrorMessage, "Player ID"));
            }
            return await service.ChangePasswordAsync(validator.ReturnedObject, newPassword);
        }

        [UsedImplicitly]
        public BaseResponse ChangePassword(
            string sessionKey,
            string currentPassword,
            string newPassword)
        {
            var sessionKeyValidator = sessionKey.ValidatePlayerSessionKey();
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage);
            }

            var passwordValidations = PlayerPassword.ValidateChangePassword(currentPassword, newPassword);
            if (!passwordValidations.Successfull)
            {
                return new BaseResponse(passwordValidations.ErrorMessage);
            }

            return Request.ExecuteSyncRequest<BaseResponse>(
                ChangePasswordAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey },
                    { "password", currentPassword },
                    { "newPassword", newPassword }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> ChangePasswordAsync(string sessionKey,
            string currentPassword,
            string newPassword)
        {
            var validations = PlayerPassword.ValidateChangePassword(currentPassword, newPassword);
            if (!validations.Successfull)
            {
                return new BaseResponse(validations.ErrorMessage);
            }

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                ChangePasswordAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey },
                    { "password", currentPassword },
                    { "newPassword", newPassword }
                }
            );
        }
    }
}