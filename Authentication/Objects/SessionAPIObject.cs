using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Objects;

[UsedImplicitly]
public sealed class EndSessionOptions(string sessionKey)
{
    private string SessionKey { get; } = sessionKey;

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

[UsedImplicitly]
public sealed class RefreshSessionOptions(string sessionKey)
{
    private string SessionKey { get; } = sessionKey;

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

[UsedImplicitly]
public sealed class GetSessionOptions(string sessionKey)
{
    private string SessionKey { get; } = sessionKey;

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