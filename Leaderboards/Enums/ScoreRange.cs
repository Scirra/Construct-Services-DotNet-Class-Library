using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Enums;

public enum ScoreRange
{
    [UsedImplicitly] All,
    [UsedImplicitly] Daily,
    [UsedImplicitly] Weekly,
    [UsedImplicitly] Monthly,
    [UsedImplicitly] Yearly
}