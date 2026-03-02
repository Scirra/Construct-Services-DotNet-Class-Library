using System;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace ConstructServices.Authentication.Objects;

public sealed class DisconnectSignInProviderOptions
{
    [UsedImplicitly]
    public string SessionKey { get; private set; }    
        
    [UsedImplicitly]
    public LoginProvider Provider { get; private set; }
        
    public DisconnectSignInProviderOptions(string sessionKey, LoginProvider provider)
    {
        SessionKey = sessionKey;
        Provider = provider;
    }
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
public sealed class ForceLinkOptions
{
    [UsedImplicitly]
    public string Code { get; private set; }    
        
    public ForceLinkOptions(string code)
    {
        Code = code;
    }
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "code", Code }
        };
        return formData;
    }
}
public sealed class LinkSignInProviderOptions
{
    [UsedImplicitly]
    public string SessionKey { get; private set; }    
        
    [UsedImplicitly]
    public LoginProvider Provider { get; private set; }
        
    public LinkSignInProviderOptions(string sessionKey, LoginProvider provider)
    {
        SessionKey = sessionKey;
        Provider = provider;
    }
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
public sealed class SignInOptions
{
    [UsedImplicitly]
    public LoginProvider Provider { get; private set; }
    
    [UsedImplicitly]
    public TimeSpan? SessionExpiry { get; private set; }
        
    public SignInOptions(LoginProvider provider, TimeSpan? sessionExpiry = null)
    {
        Provider = provider;
        SessionExpiry = sessionExpiry;
    }
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

public sealed class SignInPollOptions
{
    [UsedImplicitly]
    public Guid Token { get; private set; }    
        
    public SignInPollOptions(Guid token)
    {
        Token = token;
    }
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "pollToken", Token.ToString() }
        };
        return formData;
    }
}
public sealed class LinkPollOptions
{
    [UsedImplicitly]
    public Guid Token { get; private set; }    
        
    public LinkPollOptions(Guid token)
    {
        Token = token;
    }
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "pollToken", Token.ToString() }
        };
        return formData;
    }
}