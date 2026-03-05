using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

[UsedImplicitly]
public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Change a Players password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public BaseResponse ChangePassword(Guid playerID, string newPassword)
        {
            if (!playerID.IsValidGuid()) return new BaseResponse(Validations.InvalidGuidError);

            var passwordValidation = Validations.IsPasswordValid(newPassword);
            if (!passwordValidation.Valid) return new BaseResponse(passwordValidation.ErrorMessage);

            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                ChangePasswordOptions.BuildFormData(playerID, newPassword)
            );
        }

        /// <summary>
        /// Change a Players password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public async Task<BaseResponse> ChangePasswordAsync(Guid playerID, string newPassword)
        {
            if (!playerID.IsValidGuid()) return new BaseResponse(Validations.InvalidGuidError);

            var passwordValidation = Validations.IsPasswordValid(newPassword);
            if (!passwordValidation.Valid) return new BaseResponse(passwordValidation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                ChangePasswordOptions.BuildFormData(playerID, newPassword)
            );
        }
    }

    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Change password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public BaseResponse ChangePassword(string newPassword)
        {
            var passwordValidation = Validations.IsPasswordValid(newPassword);
            if (!passwordValidation.Valid) return new BaseResponse(passwordValidation.ErrorMessage);

            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                ChangePasswordOptions.BuildFormData(newPassword)
            );
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public async Task<BaseResponse> ChangePasswordAsync(string newPassword)
        {
            var passwordValidation = Validations.IsPasswordValid(newPassword);
            if (!passwordValidation.Valid) return new BaseResponse(passwordValidation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                ChangePasswordOptions.BuildFormData(newPassword)
            );
        }
    }

    private static class ChangePasswordOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid playerID, string newPassword)
        {
            var formData = new Dictionary<string, string>
            {
                { "password", newPassword },
                { "playerID", playerID.ToString() }
            };
            return formData;
        }
        internal static Dictionary<string, string> BuildFormData(string password)
        {
            var formData = new Dictionary<string, string>
            {
                { "password", password }
            };
            return formData;
        }
    }
}