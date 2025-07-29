using System;

namespace ConstructServices.Common;

public abstract class BaseService
{
    internal Guid GameID { get; private set; }
    /// <summary>
    /// EG. https://service.construct.net
    /// </summary>
    internal string APIHost { get; private set; }
    internal string APIKey { get; private set; }


    protected BaseService(Guid gameID, string apiHost, string aPIKey = null)
    {
        GameID = gameID;
        APIHost = apiHost;
        APIKey = aPIKey;
    }
}