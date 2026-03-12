using System;
using System.Collections.Generic;

namespace ConstructServices.XP.Actions;

internal sealed class ModifyXPOptions
{
    internal static Dictionary<string, string> BuildFormData(Guid playerID, long amount)
    {
        var formData = new Dictionary<string, string>
        {
            { "playerID", playerID.ToString() },
            { "xp", amount.ToString() }
        };
        return formData;
    }
}