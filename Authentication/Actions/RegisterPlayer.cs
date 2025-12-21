using ConstructServices.Authentication.Responses;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;
public static partial class Players
{
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public RegisterPlayerResponse RegisterPlayer(string playerName,
            TimeSpan? sessionExpiry = null)
        {
            const string path = "/registerplayer.json";

            var formData = new Dictionary<string, string>
            {
                { "playerName", playerName }
            };
            if (sessionExpiry.HasValue)
            {
                formData.Add("expiryMins", Convert.ToInt32(sessionExpiry.Value.TotalMinutes).ToString());
            }

            return Common.Request.ExecuteSyncRequest<RegisterPlayerResponse>(
                path,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public RegisterPlayerResponse RegisterPlayer(string playerName,
            string username,
            string password,
            TimeSpan? sessionExpiry = null)
        {
            const string path = "/registerplayer.json";

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

            return Common.Request.ExecuteSyncRequest<RegisterPlayerResponse>(
                path,
                service,
                formData
            );
        }
    }
}