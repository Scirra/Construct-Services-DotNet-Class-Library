using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Leaderboards;

public abstract class LeaderboardServiceBase : BaseService
{
    internal Guid LeaderboardID { get; }

    internal LeaderboardServiceBase(Guid gameID, Guid leaderboardID, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, httpTimeout)
    {
        LeaderboardID = leaderboardID;
    }
    internal LeaderboardServiceBase(Guid gameID, Guid leaderboardID, SecretAPIKey aPiKey, SessionKey sessionKey, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, aPiKey, sessionKey, httpTimeout)
    {
        LeaderboardID = leaderboardID;
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
        if (!formData.ContainsKey("leaderboardID"))
        {
            formData.Add("leaderboardID", LeaderboardID.ToString());
        }
    }
    internal static void AddRequestPerspectiveFormData(RequestPerspective perspective, Dictionary<string, string> formData)
    {
        if (perspective == null) return;
        formData.Add("requesterIP", perspective.RequesterIP);
        if (perspective.RequesterPlayerID.HasValue)
        {
            formData.Add("requesterPlayerID", perspective.RequesterPlayerID.Value.ToString());
        }
    }
}

public sealed class LeaderboardService : LeaderboardServiceBase
{
    [UsedImplicitly]
    public LeaderboardService(Guid gameID, Guid leaderboardID, TimeSpan? httpTimeout = null) : base(gameID, leaderboardID, httpTimeout) { }
    public LeaderboardService(Guid gameID, Guid leaderboardID, SecretAPIKey aPIKey, TimeSpan? httpTimeout = null) : base(gameID, leaderboardID, aPIKey, null, httpTimeout) { }
}

[UsedImplicitly]
public sealed class PlayerLeaderboardService(Guid gameID, Guid leaderboardID, SessionKey sessionKey, TimeSpan? httpTimeout = null)
    : LeaderboardServiceBase(gameID, leaderboardID, null, sessionKey, httpTimeout);
