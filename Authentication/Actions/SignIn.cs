using ConstructServices.Authentication.Objects;
using ConstructServices.Authentication.Responses;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static SignInResponse SignIn(
        this AuthenticationService service,
        LoginProvider provider,
        TimeSpan? sessionExpiry = null)
    {
        const string path = "/refreshsession.json";

        var formData = new Dictionary<string, string>
        {
            { "provider", provider.ToString() }
        };
        if (sessionExpiry.HasValue)
        {
            formData.Add("expiryMins", Convert.ToInt32(sessionExpiry.Value.TotalMinutes).ToString());
        }

        return Common.Request.ExecuteSyncRequest<SignInResponse>(
            path,
            service,
            formData
        );
    }
}