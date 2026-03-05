using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Broadcasts;

public abstract class BroadcastServiceBase : BaseService
{
    internal BroadcastServiceBase(Guid gameID) : base(gameID, Config.APIDomain)
    {
    }
    internal BroadcastServiceBase(Guid gameID, SecretAPIKey aPiKey, SessionKey sessionKey) : base(gameID, Config.APIDomain, aPiKey, sessionKey)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}

[UsedImplicitly]
public class BroadcastService : BroadcastServiceBase
{
    public BroadcastService(Guid gameID) : base(gameID) { }
    public BroadcastService(Guid gameID, SecretAPIKey aPIKey) : base(gameID, aPIKey, null) { }
}

[UsedImplicitly]
public class PlayerBroadcastService : BroadcastServiceBase
{
    public PlayerBroadcastService(Guid gameID, SessionKey sessionKey) : base(gameID, null, sessionKey) { }
}