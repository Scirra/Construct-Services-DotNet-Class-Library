using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Broadcasts;

public abstract class BroadcastServiceBase : BaseService
{
    internal BroadcastServiceBase(Guid gameID, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, httpTimeout)
    {
    }
    internal BroadcastServiceBase(Guid gameID, SecretAPIKey aPiKey, SessionKey sessionKey, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, aPiKey, sessionKey, httpTimeout)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}

public sealed class BroadcastService : BroadcastServiceBase
{
    public BroadcastService(Guid gameID, TimeSpan? httpTimeout = null) : base(gameID, httpTimeout) { }

    [UsedImplicitly]
    public BroadcastService(Guid gameID, SecretAPIKey aPIKey, TimeSpan? httpTimeout = null) : base(gameID, aPIKey, null, httpTimeout) { }
}

[method: UsedImplicitly]
public sealed class PlayerBroadcastService(Guid gameID, SessionKey sessionKey, TimeSpan? httpTimeout = null) : BroadcastServiceBase(gameID, null, sessionKey, httpTimeout);