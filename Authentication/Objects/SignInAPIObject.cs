using System;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace ConstructServices.Authentication.Objects;

public sealed class DisconnectSignInProviderOptions(string sessionKey, LoginProvider provider)
{
    [UsedImplicitly]
    public string SessionKey { get; private set; } = sessionKey;

    [UsedImplicitly]
    public LoginProvider Provider { get; private set; } = provider;

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
public sealed class ForceLinkOptions(string code)
{
    [UsedImplicitly]
    public string Code { get; private set; } = code;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "code", Code }
        };
        return formData;
    }
}
public sealed class LinkSignInProviderOptions(string sessionKey, LoginProvider provider)
{
    [UsedImplicitly]
    public string SessionKey { get; private set; } = sessionKey;

    [UsedImplicitly]
    public LoginProvider Provider { get; private set; } = provider;

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
public sealed class SignInOptions(LoginProvider provider, TimeSpan? sessionExpiry = null)
{
    [UsedImplicitly]
    public LoginProvider Provider { get; private set; } = provider;

    [UsedImplicitly]
    public TimeSpan? SessionExpiry { get; private set; } = sessionExpiry;

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

public sealed class SignInPollOptions(Guid token)
{
    [UsedImplicitly]
    public Guid Token { get; private set; } = token;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "pollToken", Token.ToString() }
        };
        return formData;
    }
}
public sealed class LinkPollOptions(Guid token)
{
    [UsedImplicitly]
    public Guid Token { get; private set; } = token;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "pollToken", Token.ToString() }
        };
        return formData;
    }
}