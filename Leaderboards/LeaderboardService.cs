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
    public LeaderboardService(Guid leaderboardID, string aPIKey = null) : base(aPIKey)
    {
        LeaderboardID = leaderboardID;
    }

    /// <summary>
    /// Create a new instance of leaderboard service
    /// </summary>
    /// <param name="leaderboardID">Leaderboard ID service is for</param>
    /// <param name="culture">The culture of responses</param>
    /// <param name="aPIKey">Optional API key, may be required for some request types and should never be exposed client side.</param>
    public LeaderboardService(Guid leaderboardID, CultureInfo culture, string aPIKey = null) : base(aPIKey)
    {
        LeaderboardID = leaderboardID;
        Culture = culture;
    }

    /// <summary>
    /// Create a new instance of leaderboard service
    /// </summary>
    /// <param name="strLeaderboardID">Leaderboard ID service is for.  Should be parsable as a GUID or will throw an exception.</param>
    /// <param name="aPIKey">Optional API key, may be required for some request types and should never be exposed client side.</param>
    public LeaderboardService(string strLeaderboardID, string aPIKey = null) : base(aPIKey)
    {
        if(!Guid.TryParse(strLeaderboardID, out var leaderboardID))
        {
            throw new Exception("Passed leaderboard ID not a valid GUID.");
        }
        LeaderboardID = leaderboardID;
    }
        
    /// <summary>
    /// Create a new instance of leaderboard service
    /// </summary>
    /// <param name="strLeaderboardID">Leaderboard ID service is for.  Should be parsable as a GUID or will throw an exception.</param>
    /// <param name="culture">The culture of responses</param>
    /// <param name="aPIKey">Optional API key, may be required for some request types and should never be exposed client side.</param>
    public LeaderboardService(string strLeaderboardID, CultureInfo culture, string aPIKey = null) : base(aPIKey)
    {
        if(!Guid.TryParse(strLeaderboardID, out var leaderboardID))
        {
            throw new Exception("Passed leaderboard ID not a valid GUID.");
        }
        LeaderboardID = leaderboardID;
        Culture = culture;
    }
}