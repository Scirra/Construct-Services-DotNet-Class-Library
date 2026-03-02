using System;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace ConstructServices.Authentication.Objects;


[UsedImplicitly]
public sealed class DisconnectSignInProviderOptions(string sessionKey, LoginProvider provider)
{
    [UsedImplicitly]
    private string SessionKey { get; } = sessionKey;

    [UsedImplicitly]
    private LoginProvider Provider { get; } = provider;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", SessionKey },
            { "provider", Provider.ToString() }
        };
        return formData;
    }
}

[UsedImplicitly]
public sealed class ForceLinkOptions(string code)
{
    [UsedImplicitly]
    private string Code { get; } = code;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "code", Code }
        };
        return formData;
    }
}

[UsedImplicitly]
public sealed class LinkSignInProviderOptions(string sessionKey, LoginProvider provider)
{
    private string SessionKey { get; } = sessionKey;
    private LoginProvider Provider { get; } = provider;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", SessionKey },
            { "provider", Provider.ToString() }
        };
        return formData;
    }
}

[UsedImplicitly]
public sealed class SignInOptions(LoginProvider provider, TimeSpan? sessionExpiry = null)
{
    private LoginProvider Provider { get; } = provider;
    private TimeSpan? SessionExpiry { get; } = sessionExpiry;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "provider", Provider.ToString() }
        };
        if (SessionExpiry.HasValue)
        {
            formData.Add("expiryMins", Convert.ToInt32(SessionExpiry.Value.TotalMinutes).ToString());
        }
        return formData;
    }
}


[UsedImplicitly]
public sealed class SignInPollOptions(Guid token)
{
    private Guid Token { get; } = token;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "pollToken", Token.ToString() }
        };
        return formData;
    }
}

[UsedImplicitly]
public sealed class LinkPollOptions(Guid token)
{
    private Guid Token { get; } = token;
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "pollToken", Token.ToString() }
        };
        return formData;
    }
}