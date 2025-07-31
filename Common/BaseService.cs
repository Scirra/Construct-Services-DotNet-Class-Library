using System;
using System.Collections.Generic;

namespace ConstructServices.Common;

public abstract class BaseService
{
    internal Guid GameID { get; private set; }
    /// <summary>
    /// EG. https://service.construct.net
    /// </summary>
    internal string APIHost { get; private set; }
    internal string APIKey { get; private set; }

    /// <summary>
    /// Some services have additional form params that need to be added,
    /// for example LeaderboardID
    /// </summary>
    internal abstract void AddServiceSpecificFormData(Dictionary<string, string> formData);

    protected BaseService(Guid gameID, string apiHost, string aPIKey = null)
    {
        GameID = gameID;
        APIHost = apiHost;
        APIKey = aPIKey;
    }
}