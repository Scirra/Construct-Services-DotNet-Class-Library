using ConstructServices.Common;
using System;
using System.Globalization;

namespace ConstructServices.Leaderboards;

public class LeaderboardService : BaseService
{
    internal Guid LeaderboardID { get; private set; }
    internal CultureInfo Culture { get; private set; }

    /// <summary>
    /// Set the culture of responses
    /// </summary>
    public void SetCulture(CultureInfo culture)
    {
        Culture = culture;
    }

    /// <summary>
    /// Create a new instance of leaderboard service
    /// </summary>
    /// <param name="leaderboardID">Leaderboard ID service is for</param>
    /// <param name="aPIKey">Optional API key, may be required for some request types and should never be exposed client side.</param>
    public LeaderboardService(Guid gameID, Guid leaderboardID, string aPIKey = null) : base(gameID, Config.APIDomain, aPIKey)
    {
        LeaderboardID = leaderboardID;
    }

    /// <summary>
    /// Create a new instance of leaderboard service
    /// </summary>
    /// <param name="leaderboardID">Leaderboard ID service is for</param>
    /// <param name="culture">The culture of responses</param>
    /// <param name="aPIKey">Optional API key, may be required for some request types and should never be exposed client side.</param>
    public LeaderboardService(Guid gameID, Guid leaderboardID, CultureInfo culture, string aPIKey = null) : base(gameID, Config.APIDomain, aPIKey)
    {
        LeaderboardID = leaderboardID;
        Culture = culture;
    }
}