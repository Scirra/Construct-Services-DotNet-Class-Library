using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Objects;

public sealed class EndSessionOptions(string sessionKey)
{
    [UsedImplicitly]
    public string SessionKey { get; private set; } = sessionKey;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}
public sealed class RefreshSessionOptions(string sessionKey)
{
    [UsedImplicitly]
    public string SessionKey { get; private set; } = sessionKey;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}
public sealed class GetSessionOptions(string sessionKey)
{
    [UsedImplicitly]
    public string SessionKey { get; private set; } = sessionKey;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}