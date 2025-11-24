using System;
using System.Collections.Generic;

namespace ConstructServices.Common;

public abstract class BaseService(Guid gameID, string apiHost, string aPiKey = null)
{
    internal Guid GameID { get; private set; } = gameID;

    /// <summary>
    /// EG. https://service.construct.net
    /// </summary>
    internal string APIHost { get; private set; } = apiHost;

    internal string APIKey { get; private set; } = aPiKey;

    /// <summary>
    /// Some services have additional form params that need to be added,
    /// for example LeaderboardID
    /// </summary>
    internal abstract void AddServiceSpecificFormData(Dictionary<string, string> formData);
}