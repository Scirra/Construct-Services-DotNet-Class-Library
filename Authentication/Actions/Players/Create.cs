using System;
using System.Collections.Generic;
using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;
public static partial class Players
{

    extension(AuthenticationService service)
    {
        /// <summary>
        /// Create a new Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/register-player" />
        [UsedImplicitly]
        public CreatePlayerResponse CreatePlayer(CreatePlayerOptions createPlayerOptions)
        {
            return Request.ExecuteSyncRequest<CreatePlayerResponse>(
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
        public async Task<CreatePlayerResponse> CreatePlayerAsync(CreatePlayerOptions createPlayerOptions)
        {
            return await Request.ExecuteAsyncRequest<CreatePlayerResponse>(
                Config.EndPointPaths.Players.Register,
                service,
                createPlayerOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class CreatePlayerOptions
    {
        private string PlayerName { get; }

        [UsedImplicitly]
        public string Username { private get; set; }

        [UsedImplicitly]
        public string Password { private get; set; }

        [UsedImplicitly]
        public string EmailAddress { private get; set; }

        [UsedImplicitly]
        public TimeSpan? SessionExpiry { private get; set; }

        public CreatePlayerOptions(string playerName)
        {
            PlayerName = playerName;
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