using ConstructServices.Authentication.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

            return Task.Run(() => Common.Request.ExecuteRequest<RegisterPlayerResponse>(
                path,
                service,
                formData
            )).Result;
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

            return Task.Run(() => Common.Request.ExecuteRequest<RegisterPlayerResponse>(
                path,
                service,
                formData
            )).Result;
        }
    }
}