using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Achievements;

public abstract class AchievementServiceBase : BaseService
{
    internal AchievementServiceBase(Guid gameID, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, httpTimeout)
    {
    }
    internal AchievementServiceBase(Guid gameID, SecretAPIKey aPiKey, SessionKey sessionKey, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, aPiKey, sessionKey, httpTimeout)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}

public sealed class AchievementService : AchievementServiceBase
{
    public AchievementService(Guid gameID, TimeSpan? httpTimeout = null) : base(gameID, httpTimeout) { }

    [UsedImplicitly]
    public AchievementService(Guid gameID, SecretAPIKey aPIKey, TimeSpan? httpTimeout = null) : base(gameID, aPIKey, null, httpTimeout) { }
}

[method: UsedImplicitly]
public sealed class PlayerAchievementService(Guid gameID, SessionKey sessionKey, TimeSpan? httpTimeout = null) : AchievementServiceBase(gameID, null, sessionKey, httpTimeout);