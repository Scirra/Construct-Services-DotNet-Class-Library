using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;

namespace ConstructServices.Authentication.Actions;

[UsedImplicitly]
public static partial class Players
{
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse ChangePassword(
            Guid playerID,
            string newPassword)
        {
            const string path = "/changepassword.json";
            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
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
            var validator = strPlayerID.IsValidGuid();
            if (!validator.Successfull)
            {
                return new BaseResponse(string.Format(validator.ErrorMessage, "Player ID"), false);
            }
            return service.ChangePassword(validator.ReturnedObject, newPassword);
        }
        
        [UsedImplicitly]
        public async Task<BaseResponse> ChangePasswordAsync(
            Guid playerID,
            string newPassword)
        {
            const string path = "/changepassword.json";
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                path,
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
                return new BaseResponse(string.Format(validator.ErrorMessage, "Player ID"), false);
            }
            return await service.ChangePasswordAsync(validator.ReturnedObject, newPassword);
        }

        [UsedImplicitly]
        public BaseResponse ChangePassword(string sessionKey,
            string currentPassword,
            string newPassword)
        {
            var validations = AuthenticationService.ValidateChangePassword(currentPassword, newPassword);
            if (!validations.Successfull)
            {
                return new BaseResponse(validations.ErrorMessage, false);
            }
            const string path = "/changepassword.json";

            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
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
            var validations = AuthenticationService.ValidateChangePassword(currentPassword, newPassword);
            if (!validations.Successfull)
            {
                return new BaseResponse(validations.ErrorMessage, false);
            }
            const string path = "/changepassword.json";

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey },
                    { "password", currentPassword },
                    { "newPassword", newPassword }
                }
            );
        }

        private static ValidationResponse ValidateChangePassword(string currentPassword, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                return new InvalidResponse("Current password cannot be empty string.");
            }
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                return new InvalidResponse("New password cannot be empty string.");
            }
            if (currentPassword.Equals(newPassword, StringComparison.CurrentCulture))
            {
                return new InvalidResponse("New password must be different from current password.");
            }
            return new ValidResponse();
        }
    }
}