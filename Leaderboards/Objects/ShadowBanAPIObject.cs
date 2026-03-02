using System.Collections.Generic;
using System.Net;
using JetBrains.Annotations;
using Guid = System.Guid;

namespace ConstructServices.Leaderboards.Objects;

public abstract class CreateShadowBanBase(
    Guid leaderboardID,
    Guid? scoreID = null,
    Guid? playerID = null,
    string ipAddress = null,
    int? ipHash = null)
{
    private Guid LeaderboardID { get; } = leaderboardID;
    private Guid? ScoreID { get; } = scoreID;
    private Guid? PlayerID { get; } = playerID;
    private string IPAddress { get; } = ipAddress;
    private int? IPHash { get; } = ipHash;

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
        if (!string.IsNullOrWhiteSpace(IPAddress))
        {
            formData.Add("ipAddress", IPAddress);
        }
        if (IPHash.HasValue)
        {
            formData.Add("ipHash", IPHash.Value.ToString());
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class CreateIPShadowBanOptions : CreateShadowBanBase
{
    public CreateIPShadowBanOptions(Guid leaderboardID, string ipAddress) 
        : base(leaderboardID, null, null, ipAddress) { }
    public CreateIPShadowBanOptions(Guid leaderboardID, IPAddress ipAddress) 
        : base(leaderboardID, null, null, ipAddress.ToString()) { }
    public CreateIPShadowBanOptions(Guid leaderboardID, int ipHash) 
        : base(leaderboardID, null, null, null, ipHash) { }
}

[UsedImplicitly]
public sealed class CreatePlayerShadowBanOptions(Guid leaderboardID, Guid playerID)
    : CreateShadowBanBase(leaderboardID, null, playerID);

[UsedImplicitly]
public sealed class CreateScoreShadowBanOptions(Guid leaderboardID, Guid scoreID)
    : CreateShadowBanBase(leaderboardID, scoreID);
public abstract class DeleteShadowBanBase(
    Guid leaderboardID,
    Guid? scoreID = null,
    Guid? playerID = null,
    string ipAddress = null,
    int? ipHash = null)
{
    private Guid LeaderboardID { get; } = leaderboardID;
    private Guid? ScoreID { get; } = scoreID;
    private Guid? PlayerID { get; } = playerID;
    private string IPAddress { get; } = ipAddress;
    private int? IPHash { get; } = ipHash;

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
        if (!string.IsNullOrWhiteSpace(IPAddress))
        {
            formData.Add("ipAddress", IPAddress);
        }
        if (IPHash.HasValue)
        {
            formData.Add("ipHash", IPHash.Value.ToString());
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class DeleteIPShadowBanOptions : DeleteShadowBanBase
{
    public DeleteIPShadowBanOptions(Guid leaderboardID, string ipAddress) 
        : base(leaderboardID, null, null, ipAddress) { }
    public DeleteIPShadowBanOptions(Guid leaderboardID, IPAddress ipAddress) 
        : base(leaderboardID, null, null, ipAddress.ToString()) { }
    public DeleteIPShadowBanOptions(Guid leaderboardID, int ipHash) 
        : base(leaderboardID, null, null, null, ipHash) { }
}

[UsedImplicitly]
public sealed class DeletePlayerShadowBanOptions(Guid leaderboardID, Guid playerID)
    : DeleteShadowBanBase(leaderboardID, null, playerID);

[UsedImplicitly]
public sealed class DeleteScoreShadowBanOptions(Guid leaderboardID, Guid scoreID)
    : DeleteShadowBanBase(leaderboardID, scoreID);

[UsedImplicitly]
public sealed class ListShadowBanOptions(Guid leaderboardID)
{
    private Guid LeaderboardID { get; } = leaderboardID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() }
        };
        return formData;
    }
}