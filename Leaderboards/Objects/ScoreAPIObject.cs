using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using ConstructServices.Common;

namespace ConstructServices.Leaderboards.Objects;

public sealed class CreateScoreOptions
{
    private string SessionKey { get; }
    private Guid LeaderboardID { get; }
    private Guid? PlayerID { get; }
    private long Score { get; }
    private short? OptValue1 { get; }
    private short? OptValue2 { get; }
    private short? OptValue3 { get; }
    
    public CreateScoreOptions(
        Guid leaderboardID, 
        Guid playerID, 
        long score,
        short? optValue1,
        short? optValue2,
        short? optValue3)
    {
        LeaderboardID = leaderboardID;
        PlayerID = playerID;
        Score = score;
        OptValue1 = optValue1;
        OptValue2 = optValue2;
        OptValue3 = optValue3;
    }
    public CreateScoreOptions(
        string sessionKey, 
        Guid leaderboardID, 
        long score,
        short? optValue1,
        short? optValue2,
        short? optValue3)
    {
        SessionKey = sessionKey;
        LeaderboardID = leaderboardID;
        PlayerID = null;
        Score = score;
        OptValue1 = optValue1;
        OptValue2 = optValue2;
        OptValue3 = optValue3;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {            
        var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
        var hash = Functions.GetSHA256Hash(LeaderboardID + "." + Score + "." + timestamp + "." + PlayerID);

        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() },
            { "hash", hash },
            { "timestamp", timestamp.ToString() },
            { "score", Score.ToString() },
        };
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (OptValue1.HasValue)
        {
            formData.Add("opt1", OptValue1.Value.ToString());
        }
        if (OptValue2.HasValue)
        {
            formData.Add("opt2", OptValue2.Value.ToString());
        }
        if (OptValue3.HasValue)
        {
            formData.Add("opt3", OptValue3.Value.ToString());
        }
        return formData;
    }
}

public abstract class AdjustScoreBase(
    string sessionKey,
    Guid leaderboardID,
    Guid? playerID,
    Guid? scoreID,
    long adjustment,
    short? optValue1,
    short? optValue2,
    short? optValue3)
{
    private string SessionKey { get; } = sessionKey;
    private Guid LeaderboardID { get; } = leaderboardID;
    private Guid? ScoreID { get; } = scoreID;
    private Guid? PlayerID { get; } = playerID;
    private long Adjustment { get; } = adjustment;
    private short? OptValue1 { get; } = optValue1;
    private short? OptValue2 { get; } = optValue2;
    private short? OptValue3 { get; } = optValue3;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {            
        var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
        var hash = Functions.GetSHA256Hash(LeaderboardID + "." + Adjustment + "." + ScoreID + "." + timestamp + ".");

        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() },
            { "hash", hash },
            { "timestamp", timestamp.ToString() },
            { "adjustment", Adjustment.ToString() },
        };
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (OptValue1.HasValue)
        {
            formData.Add("opt1", OptValue1.Value.ToString());
        }
        if (OptValue2.HasValue)
        {
            formData.Add("opt2", OptValue2.Value.ToString());
        }
        if (OptValue3.HasValue)
        {
            formData.Add("opt3", OptValue3.Value.ToString());
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class AdjustScoreByIDOptions : AdjustScoreBase
{
    public AdjustScoreByIDOptions(
        Guid leaderboardID,
        Guid scoreID,
        long adjustment,
        short? optValue1,
        short? optValue2,
        short? optValue3) :
        base(null, leaderboardID, null, scoreID, adjustment, optValue1, optValue2, optValue3)
    {

    }
}

[UsedImplicitly]
public sealed class AdjustPlayersScoreOptions : AdjustScoreBase
{    public AdjustPlayersScoreOptions(
        string sessionKey,
        Guid leaderboardID,
        Guid playerID,
        Guid scoreID,
        long adjustment,
        short? optValue1,
        short? optValue2,
        short? optValue3) :
        base(sessionKey, leaderboardID, playerID, scoreID, adjustment, optValue1, optValue2, optValue3) { }
    public AdjustPlayersScoreOptions(
        string sessionKey,
        Guid leaderboardID,
        Guid playerID,
        long adjustment,
        short? optValue1,
        short? optValue2,
        short? optValue3) :
        base(sessionKey, leaderboardID, playerID, null, adjustment, optValue1, optValue2, optValue3) { }
    public AdjustPlayersScoreOptions(
        Guid leaderboardID,
        Guid playerID,
        Guid scoreID,
        long adjustment,
        short? optValue1,
        short? optValue2,
        short? optValue3) :
        base(null, leaderboardID, playerID, scoreID, adjustment, optValue1, optValue2, optValue3) { }
    public AdjustPlayersScoreOptions(
        Guid leaderboardID,
        Guid playerID,
        long adjustment,
        short? optValue1,
        short? optValue2,
        short? optValue3) :
        base(null, leaderboardID, playerID, null, adjustment, optValue1, optValue2, optValue3) { }
}

public abstract class DeleteScoreBase(Guid leaderboardID, Guid? scoreID, Guid? playerID)
{
    private Guid LeaderboardID { get; } = leaderboardID;
    private Guid? ScoreID { get; } = scoreID;
    private Guid? PlayerID { get; } = playerID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() }
        };
        if (ScoreID.HasValue)
        {
            formData.Add("scoreID", ScoreID.Value.ToString());
        }
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class DeleteScoreOptions(Guid leaderboardID, Guid scoreID) : DeleteScoreBase(leaderboardID, scoreID, null);

[UsedImplicitly]
public sealed class DeletePlayerScoresOptions(Guid leaderboardID, Guid playerID) : DeleteScoreBase(leaderboardID, null, playerID);