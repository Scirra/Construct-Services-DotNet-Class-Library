using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConstructServices.Common;

public abstract class BaseService(
    Guid gameID, 
    string apiHost, 
    string aPiKey = null, 
    string requestedLanguage = null, 
    CultureInfo culture = null)
{
    internal Guid GameID { get; private set; } = gameID;

    /// <summary>
    /// EG. https://service.construct.net
    /// </summary>
    internal string APIHost { get; private set; } = apiHost;
    internal string APIKey { get; private set; } = aPiKey;
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