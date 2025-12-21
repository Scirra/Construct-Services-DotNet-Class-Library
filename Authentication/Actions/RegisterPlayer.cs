using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;
public static partial class Players
{
    private const string RegisterAPIPath = "/registerplayer.json";

    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public RegisterPlayerResponse RegisterPlayer(
            string playerName,
            TimeSpan? sessionExpiry = null)
        {
            var playerNameValidator = Common.Validations.PlayerName.ValidatePlayerName(playerName);
            if (!playerNameValidator.Successfull)
            {
                return new RegisterPlayerResponse(playerNameValidator.ErrorMessage, false);
            }

            var formData = new Dictionary<string, string>
            {
                { "playerName", playerName }
            };
            if (sessionExpiry.HasValue)
            {
                formData.Add("expiryMins", Convert.ToInt32(sessionExpiry.Value.TotalMinutes).ToString());
            }

            return Request.ExecuteSyncRequest<RegisterPlayerResponse>(
                RegisterAPIPath,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<RegisterPlayerResponse> RegisterPlayerAsync(
            string playerName,
            TimeSpan? sessionExpiry = null)
        {
            var playerNameValidator = Common.Validations.PlayerName.ValidatePlayerName(playerName);
            if (!playerNameValidator.Successfull)
            {
                return new RegisterPlayerResponse(playerNameValidator.ErrorMessage, false);
            }

            var formData = new Dictionary<string, string>
            {
                { "playerName", playerName }
            };
            if (sessionExpiry.HasValue)
            {
                formData.Add("expiryMins", Convert.ToInt32(sessionExpiry.Value.TotalMinutes).ToString());
            }

            return await Request.ExecuteAsyncRequest<RegisterPlayerResponse>(
                RegisterAPIPath,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public RegisterPlayerResponse RegisterPlayer(
            string playerName,
            string username,
            string password,
            TimeSpan? sessionExpiry = null)
        {
            var playerNameValidator = Common.Validations.PlayerName.ValidatePlayerName(playerName);
            if (!playerNameValidator.Successfull)
            {
                return new RegisterPlayerResponse(playerNameValidator.ErrorMessage, false);
            }
            var playerUsernameValidator = Common.Validations.PlayerUsername.ValidatePlayerUsername(playerName);
            if (!playerUsernameValidator.Successfull)
            {
                return new RegisterPlayerResponse(playerUsernameValidator.ErrorMessage, false);
            }
            var playerPasswordValidator = Common.Validations.PlayerPassword.ValidatePlayerPassword(playerName);
            if (!playerPasswordValidator.Successfull)
            {
                return new RegisterPlayerResponse(string.Format(playerPasswordValidator.ErrorMessage, "Password"), false);
            }

            var formData = new Dictionary<string, string>
            {
                { "playerName", playerName },
                { "username", username },
                { "password", password }
            };
            if (sessionExpiry.HasValue)
            {
                formData.Add("expiryMins", Convert.ToInt32(sessionExpiry.Value.TotalMinutes).ToString());
            }

            return Request.ExecuteSyncRequest<RegisterPlayerResponse>(
                RegisterAPIPath,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<RegisterPlayerResponse> RegisterPlayerAsync(
            string playerName,
            string username,
            string password,
            TimeSpan? sessionExpiry = null)
        {
            var playerNameValidator = Common.Validations.PlayerName.ValidatePlayerName(playerName);
            if (!playerNameValidator.Successfull)
            {
                return new RegisterPlayerResponse(playerNameValidator.ErrorMessage, false);
            }
            var playerUsernameValidator = Common.Validations.PlayerUsername.ValidatePlayerUsername(playerName);
            if (!playerUsernameValidator.Successfull)
            {
                return new RegisterPlayerResponse(playerUsernameValidator.ErrorMessage, false);
            }
            var playerPasswordValidator = Common.Validations.PlayerPassword.ValidatePlayerPassword(playerName);
            if (!playerPasswordValidator.Successfull)
            {
                return new RegisterPlayerResponse(string.Format(playerPasswordValidator.ErrorMessage, "Password"), false);
            }

            var formData = new Dictionary<string, string>
            {
                { "playerName", playerName },
                { "username", username },
                { "password", password }
            };
            if (sessionExpiry.HasValue)
            {
                formData.Add("expiryMins", Convert.ToInt32(sessionExpiry.Value.TotalMinutes).ToString());
            }

            return await Request.ExecuteAsyncRequest<RegisterPlayerResponse>(
                RegisterAPIPath,
                service,
                formData
            );
        }
    }
}