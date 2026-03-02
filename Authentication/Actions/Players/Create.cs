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
        public RegisterPlayerResponse CreatePlayer(CreatePlayerOptions createPlayerOptions)
        {
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
        public async Task<RegisterPlayerResponse> CreatePlayerAsync(CreatePlayerOptions createPlayerOptions)
        {
            return await Request.ExecuteAsyncRequest<RegisterPlayerResponse>(
                Config.EndPointPaths.Players.Register,
                service,
                createPlayerOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class CreatePlayerOptions(
        string playerName,
        string emailAddress,
        string username,
        string password,
        TimeSpan? sessionExpiry = null)
    {
        private string PlayerName { get; } = playerName;
        private string Username { get; } = username;
        private string Password { get; } = password;
        private string EmailAddress { get; } = emailAddress;
        private TimeSpan? SessionExpiry { get; } = sessionExpiry;

        public CreatePlayerOptions(string playerName, TimeSpan? sessionExpiry = null) : this(playerName, null, null, null, null)
        {
        }
        public CreatePlayerOptions(string playerName, string emailAddress, TimeSpan? sessionExpiry = null) : this(playerName, emailAddress, null, null, null)
        {
        }
        public CreatePlayerOptions(string playerName, string username, string password, TimeSpan? sessionExpiry = null) : this(playerName, null, username, password)
        {
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