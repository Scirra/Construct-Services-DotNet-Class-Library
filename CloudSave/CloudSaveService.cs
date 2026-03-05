using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.CloudSave;

public abstract class CloudSaveServiceBase : BaseService
{
    internal CloudSaveServiceBase(Guid gameID) : base(gameID, Config.APIDomain)
    {
    }
    internal CloudSaveServiceBase(Guid gameID, SecretAPIKey aPiKey, SessionKey sessionKey) : base(gameID, Config.APIDomain, aPiKey, sessionKey)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}

public sealed class CloudSaveService : CloudSaveServiceBase
{
    [UsedImplicitly]
    public CloudSaveService(Guid gameID) : base(gameID) { }
    public CloudSaveService(Guid gameID, SecretAPIKey aPIKey) : base(gameID, aPIKey, null) { }
}

[UsedImplicitly]
public sealed class PlayerCloudSaveService(Guid gameID, SessionKey sessionKey)
    : CloudSaveServiceBase(gameID, null, sessionKey);
