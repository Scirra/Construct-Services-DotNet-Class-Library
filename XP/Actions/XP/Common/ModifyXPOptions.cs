using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.XP.Actions;

[UsedImplicitly]
public sealed class ModifyXPOptions
{
    private long Amount { get; }

    public ModifyXPOptions(long amount)
    {
        Amount = amount;
    }

    internal Dictionary<string, string> BuildFormData(Guid playerID)
    {
        var formData = new Dictionary<string, string>
        {
            { "playerID", playerID.ToString() },
            { "xp", Amount.ToString() }
        };
        return formData;
    }
}