using ConstructServices.Authentication.Objects;
using ConstructServices.Authentication.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string SignInAPIPath = "/signin.json";

    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public SignInResponse SignIn(
            LoginProvider provider,
            TimeSpan? sessionExpiry = null)
        {
            var formData = new Dictionary<string, string>
            {
                { "provider", provider.ToString() }
            };
            if (sessionExpiry.HasValue)
            {
                formData.Add("expiryMins", Convert.ToInt32(sessionExpiry.Value.TotalMinutes).ToString());
            }

            return Common.Request.ExecuteSyncRequest<SignInResponse>(
                SignInAPIPath,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<SignInResponse> SignInAsync(
            LoginProvider provider,
            TimeSpan? sessionExpiry = null)
        {
            var formData = new Dictionary<string, string>
            {
                { "provider", provider.ToString() }
            };
            if (sessionExpiry.HasValue)
            {
                formData.Add("expiryMins", Convert.ToInt32(sessionExpiry.Value.TotalMinutes).ToString());
            }
            return await Common.Request.ExecuteAsyncRequest<SignInResponse>(
                SignInAPIPath,
                service,
                formData
            );
        }
    }
}