using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Leaderboards;

public abstract class LeaderboardServiceBase : BaseService
{
    internal Guid LeaderboardID { get; }

    internal LeaderboardServiceBase(Guid gameID, Guid leaderboardID) : base(gameID, Config.APIDomain)
    {
        LeaderboardID = leaderboardID;
    }
    internal LeaderboardServiceBase(Guid gameID, Guid leaderboardID, SecretAPIKey aPiKey, SessionKey sessionKey) : base(gameID, Config.APIDomain, aPiKey, sessionKey)
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
    internal void AddRequestPerspectiveFormData(RequestPerspective perspective, Dictionary<string, string> formData)
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
    public LeaderboardService(Guid gameID, Guid leaderboardID) : base(gameID, leaderboardID) { }
    public LeaderboardService(Guid gameID, Guid leaderboardID, SecretAPIKey aPIKey) : base(gameID, leaderboardID, aPIKey, null) { }
}

[UsedImplicitly]
public sealed class PlayerLeaderboardService(Guid gameID, Guid leaderboardID, SessionKey sessionKey)
    : LeaderboardServiceBase(gameID, leaderboardID, null, sessionKey);
