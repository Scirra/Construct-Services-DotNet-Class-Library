using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.XP;


public abstract class XPServiceBase : BaseService
{
    internal XPServiceBase(Guid gameID) : base(gameID, Config.APIDomain)
    {
    }
    internal XPServiceBase(Guid gameID, SecretAPIKey aPiKey, SessionKey sessionKey) : base(gameID, Config.APIDomain, aPiKey, sessionKey)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}

public sealed class XPService : XPServiceBase
{
    [UsedImplicitly]
    public XPService(Guid gameID) : base(gameID) { }
    public XPService(Guid gameID, SecretAPIKey aPIKey) : base(gameID, aPIKey, null) { }
}

[UsedImplicitly]
public sealed class PlayerXPService(Guid gameID, SessionKey sessionKey) : XPServiceBase(gameID, null, sessionKey);
