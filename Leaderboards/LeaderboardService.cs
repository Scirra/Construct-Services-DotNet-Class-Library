using ConstructServices.Common;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards;

[UsedImplicitly]
public sealed class LeaderboardService : BaseService
{
    internal Guid LeaderboardID { get; }

    /// <summary>
    /// Create new service instance for requests that do not require any authentication
    /// </summary>
    /// <param name="gameID">ID of the game to run requests against</param>
    /// <param name="leaderboardID">ID of the leaderboard to run requests against</param>
    public LeaderboardService(Guid gameID, Guid leaderboardID) : base(gameID, Config.APIDomain)
    {
        LeaderboardID = leaderboardID;
    }
    
    /// <summary>
    /// Create a new service instance for requests authenticated with a secret API key
    /// </summary>
    /// <param name="gameID">ID of the game to run requests against</param>
    /// <param name="leaderboardID">ID of the leaderboard to run requests against</param>
    /// <param name="aPIKey">Your games secret API key</param>
    public LeaderboardService(Guid gameID, Guid leaderboardID, SecretAPIKey aPIKey) : base(gameID, Config.APIDomain, aPIKey)
    {
        LeaderboardID = leaderboardID;
    }
    
    /// <summary>
    /// Create a new service instance for requests authenticated with a players session key
    /// </summary>
    /// <param name="gameID">ID of the game to run requests against</param>
    /// <param name="leaderboardID">ID of the leaderboard to run requests against</param>
    /// <param name="sessionKey">The players session key</param>
    public LeaderboardService(Guid gameID, Guid leaderboardID, SessionKey sessionKey) : base(gameID, Config.APIDomain, sessionKey)
    {
        LeaderboardID = leaderboardID;
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

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
        if (!formData.ContainsKey("leaderboardID"))
        {
            formData.Add("leaderboardID", LeaderboardID.ToString());
        }
    }
}