using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConstructServices.Leaderboards;

public sealed class LeaderboardService : BaseService
{
    internal Guid LeaderboardID { get; }

    /// <summary>
    /// Create a new instance of leaderboard service
    /// </summary>
    /// <param name="gameID">Game ID service is for</param>
    /// <param name="leaderboardID">Leaderboard ID service is for</param>
    /// <param name="aPIKey">Optional API key, may be required for some request types and should never be exposed client side.</param>
    /// <param name="requestedLanguage">ISO Alpha 2 language to return translatable strings to</param>
    /// <param name="culture">Culture to return formatted values in</param>
    public LeaderboardService(Guid gameID, Guid leaderboardID, SecretAPIKey aPIKey, string requestedLanguage = null, CultureInfo culture = null) 
        : base(gameID, Config.APIDomain, aPIKey, requestedLanguage, culture)
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
        if (Culture != null && !formData.ContainsKey("culture"))
        {
            formData.Add("culture", Culture.ToString());
        }
    }
}