using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.XP;


public abstract class XPServiceBase : BaseService
{
    internal XPServiceBase(Guid gameID, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, httpTimeout)
    {
    }
    internal XPServiceBase(Guid gameID, SecretAPIKey aPiKey, SessionKey sessionKey, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, aPiKey, sessionKey, httpTimeout)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}

public sealed class XPService : XPServiceBase
{
    [UsedImplicitly]
    public XPService(Guid gameID, TimeSpan? httpTimeout = null) : base(gameID, httpTimeout) { }
    public XPService(Guid gameID, SecretAPIKey aPIKey, TimeSpan? httpTimeout = null) : base(gameID, aPIKey, null, httpTimeout) { }
}

[UsedImplicitly]
public sealed class PlayerXPService(Guid gameID, SessionKey sessionKey, TimeSpan? httpTimeout = null) : XPServiceBase(gameID, null, sessionKey, httpTimeout);
