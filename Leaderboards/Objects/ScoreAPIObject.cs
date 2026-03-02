using ConstructServices.Common;
using ConstructServices.Leaderboards.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Leaderboards.Objects;

public sealed class CreateScoreOptions
{
    private string SessionKey { get; }
    private Guid? PlayerID { get; }
    private long Score { get; }
    private short? OptValue1 { get; }
    private short? OptValue2 { get; }
    private short? OptValue3 { get; }
    
    public CreateScoreOptions(
        Guid playerID, 
        long score,
        short? optValue1,
        short? optValue2,
        short? optValue3)
    {
        PlayerID = playerID;
        Score = score;
        OptValue1 = optValue1;
        OptValue2 = optValue2;
        OptValue3 = optValue3;
    }
    public CreateScoreOptions(
        string sessionKey, 
        long score,
        short? optValue1,
        short? optValue2,
        short? optValue3)
    {
        SessionKey = sessionKey;
        PlayerID = null;
        Score = score;
        OptValue1 = optValue1;
        OptValue2 = optValue2;
        OptValue3 = optValue3;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData(Guid leaderboardID)
    {            
        var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
        var hash = Functions.GetSHA256Hash(leaderboardID + "." + Score + "." + timestamp + "." + PlayerID);

        var formData = new Dictionary<string, string>
        {
            { "hash", hash },
            { "timestamp", timestamp.ToString() },
            { "score", Score.ToString() }
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
    Guid? playerID,
    Guid? scoreID,
    long adjustment,
    short? optValue1,
    short? optValue2,
    short? optValue3)
{
    private string SessionKey { get; } = sessionKey;
    private Guid? ScoreID { get; } = scoreID;
    private Guid? PlayerID { get; } = playerID;
    private long Adjustment { get; } = adjustment;
    private short? OptValue1 { get; } = optValue1;
    private short? OptValue2 { get; } = optValue2;
    private short? OptValue3 { get; } = optValue3;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData(Guid leaderboardID)
    {            
        var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
        var hash = Functions.GetSHA256Hash(leaderboardID + "." + Adjustment + "." + ScoreID + "." + timestamp + ".");

        var formData = new Dictionary<string, string>
        {
            { "hash", hash },
            { "timestamp", timestamp.ToString() },
            { "adjustment", Adjustment.ToString() }
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
public sealed class AdjustScoreByIDOptions(
    Guid scoreID,
    long adjustment,
    short? optValue1,
    short? optValue2,
    short? optValue3)
    : AdjustScoreBase(null, null, scoreID, adjustment, optValue1, optValue2, optValue3);

[UsedImplicitly]
public sealed class AdjustPlayersScoreOptions : AdjustScoreBase
{    public AdjustPlayersScoreOptions(
        string sessionKey,
        Guid playerID,
        Guid scoreID,
        long adjustment,
        short? optValue1,
        short? optValue2,
        short? optValue3) :
        base(sessionKey, playerID, scoreID, adjustment, optValue1, optValue2, optValue3) { }
    public AdjustPlayersScoreOptions(
        string sessionKey,
        Guid playerID,
        long adjustment,
        short? optValue1,
        short? optValue2,
        short? optValue3) :
        base(sessionKey, playerID, null, adjustment, optValue1, optValue2, optValue3) { }
    public AdjustPlayersScoreOptions(
        Guid playerID,
        Guid scoreID,
        long adjustment,
        short? optValue1,
        short? optValue2,
        short? optValue3) :
        base(null, playerID, scoreID, adjustment, optValue1, optValue2, optValue3) { }
    public AdjustPlayersScoreOptions(
        Guid playerID,
        long adjustment,
        short? optValue1,
        short? optValue2,
        short? optValue3) :
        base(null, playerID, null, adjustment, optValue1, optValue2, optValue3) { }
}

public abstract class DeleteScoreBase(Guid? scoreID, Guid? playerID)
{
    private Guid? ScoreID { get; } = scoreID;
    private Guid? PlayerID { get; } = playerID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
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
public sealed class DeleteScoreOptions(Guid scoreID) : DeleteScoreBase(scoreID, null);

[UsedImplicitly]
public sealed class DeletePlayerScoresOptions(Guid playerID) : DeleteScoreBase(null, playerID);


[UsedImplicitly]
public sealed class ListNewestScoresOptions(string countryISO = null)
{
    private string CountryISO { get; } = countryISO;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(CountryISO))
        {
            formData.Add("country", CountryISO);
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class ListPlayerScoresOptions(Guid playerID)
{
    private Guid PlayerID { get; } = playerID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "playerID", PlayerID.ToString() }
        };
        return formData;
    }
}

public abstract class ListScoreHistoryBase(Guid? playerID, Guid? scoreID)
{
    private Guid? PlayerID { get; } = playerID;
    private Guid? ScoreID { get; } = scoreID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.ToString());
        }
        if (ScoreID.HasValue)
        {
            formData.Add("scoreID", ScoreID.ToString());
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class ListPlayerScoreHistoryOptions(Guid playerID)
    : ListScoreHistoryBase(playerID, null);

[UsedImplicitly]
public sealed class ListScoreHistoryOptions(Guid scoreID)
    : ListScoreHistoryBase(null, scoreID);


public abstract class ListNeighbourScoresBase(Guid? playerID, Guid? scoreID, short? range, short? compareRanks)
{
    private Guid? PlayerID { get; } = playerID;
    private Guid? ScoreID { get; } = scoreID;
    private short? Range { get; } = range;
    private short? CompareRanks { get; } = compareRanks;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (ScoreID.HasValue)
        {
            formData.Add("scoreID", ScoreID.Value.ToString());
        }
        if (Range.HasValue)
        {
            formData.Add("range", Range.Value.ToString());
        }
        if (CompareRanks.HasValue)
        {
            formData.Add("compareRanks", CompareRanks.Value.ToString());
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class ListPlayerScoreNeighboursOptions(
    Guid playerID,
    short? range,
    short? compareRanks)
    : ListNeighbourScoresBase(playerID, null, range, compareRanks);

[UsedImplicitly]
public sealed class ListScoreNeighboursOptions(
    Guid scoreID, 
    short? range, 
    short? compareRanks)
    : ListNeighbourScoresBase(null, scoreID, range, compareRanks);


public sealed class ListScoreOptions(
    string countryISO = null,
    short? compareRanks = null,
    ScoreRange? range = null,
    short? rangeOffset = null)
{
    [UsedImplicitly]
    public string CountryISO { get; set; } = countryISO;

    [UsedImplicitly]
    public short? CompareRanks { get; set; } = compareRanks;
    
    [UsedImplicitly]
    public ScoreRange? Range { get; set; } = range;

    [UsedImplicitly]
    public short? RangeOffset { get; set; } = rangeOffset;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(CountryISO))
        {
            formData.Add("country", CountryISO);
        }
        if (CompareRanks.HasValue)
        {
            formData.Add("compareRanks", CompareRanks.Value.ToString());
        }
        if (Range.HasValue)
        {
            formData.Add("range", Range.Value.ToString());
        }
        if (RangeOffset.HasValue)
        {
            formData.Add("rangeOffset", RangeOffset.Value.ToString());
        }
        return formData;
    }
}
