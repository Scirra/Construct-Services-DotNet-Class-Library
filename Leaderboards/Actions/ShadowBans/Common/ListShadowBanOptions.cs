using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

[UsedImplicitly]
public sealed class ListShadowBanOptions()
{
    // ReSharper disable once MemberCanBeMadeStatic.Global
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        return formData;
    }
}