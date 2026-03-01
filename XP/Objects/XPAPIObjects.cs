using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.XP.Objects;

public sealed class GetXPOptions
{
    [UsedImplicitly]
    private Guid PlayerID { get; set; }

    /// <summary>
    /// No player ID specified, uses currently authenticated player
    /// </summary>
    public GetXPOptions()
    {
    }

    public GetXPOptions(string strPlayerID)
    {
        PlayerID = Guid.Parse(strPlayerID);
    }
    public GetXPOptions(Guid playerID)
    {
        PlayerID = playerID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (PlayerID != Guid.Empty)
        {
            formData.Add("playerID", PlayerID.ToString());
        }
        return formData;
    }
}
public sealed class ModifyXPOptions
{
    [UsedImplicitly]
    private Guid PlayerID { get; set; }

    [UsedImplicitly]
    private long Amount { get; set; }

    public ModifyXPOptions(string strPlayerID, long amount)
    {
        PlayerID = Guid.Parse(strPlayerID);
        Amount = amount;
    }
    public ModifyXPOptions(Guid playerID, long amount)
    {
        PlayerID = playerID;
        Amount = amount;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "playerID", PlayerID.ToString() },
            { "xp", Amount.ToString() }
        };
        return formData;
    }
}