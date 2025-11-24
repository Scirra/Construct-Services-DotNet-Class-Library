using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards;

public sealed class LeaderboardService : BaseService
{
    internal Guid LeaderboardID { get; }
    private CultureInfo Culture { get; set; }

    /// <summary>
    /// Set the culture of responses
    /// </summary>
    [UsedImplicitly]
    public void SetCulture(CultureInfo culture)
    {
        Culture = culture;
    }

    /// <summary>
    /// Create a new instance of leaderboard service
    /// </summary>
    /// <param name="gameID">Game ID service is for</param>
    /// <param name="leaderboardID">Leaderboard ID service is for</param>
    /// <param name="aPIKey">Optional API key, may be required for some request types and should never be exposed client side.</param>
    public LeaderboardService(Guid gameID, Guid leaderboardID, string aPIKey = null) : base(gameID, Config.APIDomain, aPIKey)
    {
        LeaderboardID = leaderboardID;
    }

    /// <summary>
    /// Create a new instance of leaderboard service
    /// </summary>
    /// <param name="gameID">Game ID service is for</param>
    /// <param name="leaderboardID">Leaderboard ID service is for</param>
    /// <param name="culture">The culture of responses</param>
    /// <param name="aPIKey">Optional API key, may be required for some request types and should never be exposed client side.</param>
    public LeaderboardService(Guid gameID, Guid leaderboardID, CultureInfo culture, string aPIKey = null) : base(gameID, Config.APIDomain, aPIKey)
    {
        LeaderboardID = leaderboardID;
        Culture = culture;
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
        if (Culture != null && !formData.ContainsKey("culture"))
        {
            formData.Add("culture", Culture.ToString());
        }
    }
}