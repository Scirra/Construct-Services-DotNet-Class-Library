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

public abstract class BaseService(
    Guid gameID, 
    string apiHost, 
    SecretAPIKey aPiKey = null, 
    string requestedLanguage = null, 
    CultureInfo culture = null)
{
    /// <summary>
    /// If a response returned valid JSON, the raw JSON string is returned here.
    /// Should only be used for debugging.
    /// </summary>
    public string RawJson { get; internal set; }

    /// <summary>
    /// If a response returned valid JSON, the raw object.  Shouldn't be needed, but
    /// can be useful if the API returns properties not implemented in this library.
    /// </summary>
    public dynamic RawObject { get; internal set; }

    internal Guid GameID { get; private set; } = gameID;

    /// <summary>
    /// EG. https://service.construct.net
    /// </summary>
    internal string APIHost { get; private set; } = apiHost;
    internal SecretAPIKey APIKey { get; private set; } = aPiKey;
    internal string RequestedLanguage { get; private set; } = requestedLanguage;
    internal CultureInfo Culture { get; private set; } = culture;
    
    /// <summary>
    /// Allows change of requested language without needing to create new service object
    /// </summary>
    public void SetRequestedLanguage(string requestedLanguage)
    {
        RequestedLanguage = requestedLanguage;
    }

    /// <summary>
    /// Allows change of culture without needing to create new service object
    /// </summary>
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