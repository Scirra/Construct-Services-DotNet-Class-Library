using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;

namespace ConstructServices.Common;

[UsedImplicitly]
public sealed class SecretAPIKey(string key)
{
    internal string Key { get; private set; } = key;
}
[UsedImplicitly]
public sealed class SessionKey(string key)
{
    internal string Key { get; private set; } = key;
}
public abstract class BaseService
{
    internal Guid GameID { get; private set; }
    internal string APIHost { get; private set; }
    internal SecretAPIKey APIKey { get; private set; }
    internal string RequestedLanguage { get; private set; }
    internal CultureInfo Culture { get; private set; }
    internal SessionKey SessionKey { get; private set; }
    
    internal BaseService(
        Guid gameID,
        string apiHost)
    {
        GameID = gameID;
        APIHost = apiHost;
    }

    internal BaseService(
        Guid gameID,
        string apiHost,
        SecretAPIKey aPiKey,
        SessionKey sessionKey)
    {
        GameID = gameID;
        APIHost = apiHost;
        APIKey = aPiKey;
        SessionKey = sessionKey;
    }

    /// <summary>
    /// Allows change of requested language without needing to create new service object
    /// </summary>
    [UsedImplicitly]
    public void SetRequestedLanguage(string requestedLanguage)
    {
        RequestedLanguage = requestedLanguage;
    }

    /// <summary>
    /// Allows change of culture without needing to create new service object
    /// </summary>
    [UsedImplicitly]
    public void SetCulture(CultureInfo culture)
    {
        Culture = culture;
    }

    /// <summary>
    /// Some services have additional form params that need to be added,
    /// for example LeaderboardID
    /// </summary>
    internal abstract void AddServiceSpecificFormData(Dictionary<string, string> formData);
}