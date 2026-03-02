using System.Collections.Generic;
using System.Net;
using JetBrains.Annotations;
using Guid = System.Guid;

namespace ConstructServices.Leaderboards.Objects;

public abstract class CreateShadowBanBase(
    Guid? scoreID = null,
    Guid? playerID = null,
    string ipAddress = null,
    int? ipHash = null)
{ 
    private Guid? ScoreID { get; } = scoreID;
    private Guid? PlayerID { get; } = playerID;
    private string IPAddress { get; } = ipAddress;
    private int? IPHash { get; } = ipHash;

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
    public CreateIPShadowBanOptions(string ipAddress) 
        : base(null, null, ipAddress) { }
    public CreateIPShadowBanOptions(IPAddress ipAddress) 
        : base(null, null, ipAddress.ToString()) { }
    public CreateIPShadowBanOptions(int ipHash) 
        : base(null, null, null, ipHash) { }
}

[UsedImplicitly]
public sealed class CreatePlayerShadowBanOptions(Guid playerID)
    : CreateShadowBanBase(null, playerID);

[UsedImplicitly]
public sealed class CreateScoreShadowBanOptions(Guid scoreID)
    : CreateShadowBanBase(scoreID);
public abstract class DeleteShadowBanBase(
    Guid? scoreID = null,
    Guid? playerID = null,
    string ipAddress = null,
    int? ipHash = null)
{
    private Guid? ScoreID { get; } = scoreID;
    private Guid? PlayerID { get; } = playerID;
    private string IPAddress { get; } = ipAddress;
    private int? IPHash { get; } = ipHash;

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
        : base(null, null, ipAddress) { }
    public DeleteIPShadowBanOptions(Guid leaderboardID, IPAddress ipAddress) 
        : base(null, null, ipAddress.ToString()) { }
    public DeleteIPShadowBanOptions(Guid leaderboardID, int ipHash) 
        : base(null, null, null, ipHash) { }
}

[UsedImplicitly]
public sealed class DeletePlayerShadowBanOptions(Guid playerID)
    : DeleteShadowBanBase(null, playerID);

[UsedImplicitly]
public sealed class DeleteScoreShadowBanOptions(Guid scoreID)
    : DeleteShadowBanBase(scoreID);

[UsedImplicitly]
public sealed class ListShadowBanOptions()
{
    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        return formData;
    }
}