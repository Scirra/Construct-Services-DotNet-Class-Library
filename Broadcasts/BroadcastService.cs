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

public sealed class BroadcastService : BroadcastServiceBase
{
    public BroadcastService(Guid gameID) : base(gameID) { }

    [UsedImplicitly]
    public BroadcastService(Guid gameID, SecretAPIKey aPIKey) : base(gameID, aPIKey, null) { }
}

[method: UsedImplicitly]
public sealed class PlayerBroadcastService(Guid gameID, SessionKey sessionKey) : BroadcastServiceBase(gameID, null, sessionKey);