using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.XP.Actions;

[UsedImplicitly]
public sealed class ModifyXPOptions(long amount)
{
    private long Amount { get; } = amount;

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