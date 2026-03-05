using System;
using System.Collections.Generic;
using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationServiceBase service)
    {
        /// <summary>
        /// Create a new Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/register-player" />
        [UsedImplicitly]
        public RegisterPlayerResponse RegisterPlayer(RegisterPlayerOptions createPlayerOptions)
        {
            var validation = createPlayerOptions.Validate();
            if (!validation.Valid) return new RegisterPlayerResponse(validation.ErrorMessage);

            return Request.ExecuteSyncRequest<RegisterPlayerResponse>(
                Config.EndPointPaths.Players.Register,
                service,
                createPlayerOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Create a new Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/register-player" />
        [UsedImplicitly]
        public async Task<RegisterPlayerResponse> RegisterPlayerAsync(RegisterPlayerOptions createPlayerOptions)
        {
            var validation = createPlayerOptions.Validate();
            if (!validation.Valid) return new RegisterPlayerResponse(validation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<RegisterPlayerResponse>(
                Config.EndPointPaths.Players.Register,
                service,
                createPlayerOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class RegisterPlayerOptions
    {
        [UsedImplicitly]
        public string PlayerName { private get; set; }

        [UsedImplicitly]
        public string Username { private get; set; }

        [UsedImplicitly]
        public string Password { private get; set; }

        [UsedImplicitly]
        public string EmailAddress { private get; set; }

        [UsedImplicitly]
        public TimeSpan? SessionExpiry { private get; set; }

        internal Validations.ValidationResponseBase Validate()
        {
            var playerNameValidation = Validations.IsPlayerNameValid(PlayerName);
            if (!playerNameValidation.Valid) return playerNameValidation;
            
            if (!string.IsNullOrWhiteSpace(Username))
            {
                var usernameValidation = Validations.IsUsernameValid(Username);
                if (!usernameValidation.Valid) return usernameValidation;
            }

            if (!string.IsNullOrWhiteSpace(Password))
            {
                var passwordValidation = Validations.IsPasswordValid(Password);
                if (!passwordValidation.Valid) return passwordValidation;
            }
            
            if (!string.IsNullOrWhiteSpace(Password) && string.IsNullOrWhiteSpace(Username))
            {
                return new Validations.FailedValidation("If password specified, username is required.");
            }

            if (!string.IsNullOrWhiteSpace(Username) && string.IsNullOrWhiteSpace(Password))
            {
                return new Validations.FailedValidation("If username specified, password is required.");
            }

            if (!string.IsNullOrWhiteSpace(EmailAddress))
            {
                var emailValidation = Validations.IsEmailAddressValid(EmailAddress);
                if (!emailValidation.Valid) return emailValidation;
            }
            
            return new Validations.SuccessfullValidation();
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "playerName", PlayerName }
            };
            if (!string.IsNullOrWhiteSpace(EmailAddress))
            {
                formData.Add("emailAddress", EmailAddress);
            }
            if (!string.IsNullOrWhiteSpace(Username))
            {
                formData.Add("username", Username);
            }
            if (!string.IsNullOrWhiteSpace(Password))
            {
                formData.Add("password", Password);
            }
            if (SessionExpiry.HasValue)
            {
                formData.Add("expiryMins", Convert.ToInt32(SessionExpiry.Value.TotalMinutes).ToString());
            }
            return formData;
        }
    }
}