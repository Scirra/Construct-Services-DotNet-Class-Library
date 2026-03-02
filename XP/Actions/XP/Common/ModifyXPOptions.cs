using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.XP.Actions;

[UsedImplicitly]
public sealed class ModifyXPOptions
{
    private Guid PlayerID { get; }
    private long Amount { get; }

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