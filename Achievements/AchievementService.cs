using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Broadcasts;

public abstract class AchievementServiceBase : BaseService
{
    internal AchievementServiceBase(Guid gameID) : base(gameID, Config.APIDomain)
    {
    }
    internal AchievementServiceBase(Guid gameID, SecretAPIKey aPiKey, SessionKey sessionKey) : base(gameID, Config.APIDomain, aPiKey, sessionKey)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}

public sealed class AchievementService : AchievementServiceBase
{
    public AchievementService(Guid gameID) : base(gameID) { }

    [UsedImplicitly]
    public AchievementService(Guid gameID, SecretAPIKey aPIKey) : base(gameID, aPIKey, null) { }
}

[method: UsedImplicitly]
public sealed class PlayerAchievementService(Guid gameID, SessionKey sessionKey) : AchievementServiceBase(gameID, null, sessionKey);