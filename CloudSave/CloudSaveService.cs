using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.CloudSave;

public abstract class CloudSaveServiceBase : BaseService
{
    internal CloudSaveServiceBase(Guid gameID, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, httpTimeout)
    {
    }
    internal CloudSaveServiceBase(Guid gameID, SecretAPIKey aPiKey, SessionKey sessionKey, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, aPiKey, sessionKey, httpTimeout)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}

public sealed class CloudSaveService : CloudSaveServiceBase
{
    [UsedImplicitly]
    public CloudSaveService(Guid gameID, TimeSpan? httpTimeout = null) : base(gameID, httpTimeout) { }
    public CloudSaveService(Guid gameID, SecretAPIKey aPIKey, TimeSpan? httpTimeout = null) : base(gameID, aPIKey, null, httpTimeout) { }
}

[UsedImplicitly]
public sealed class PlayerCloudSaveService(Guid gameID, SessionKey sessionKey, TimeSpan? httpTimeout = null)
    : CloudSaveServiceBase(gameID, null, sessionKey, httpTimeout);
