using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Enums;

public enum GetTeamsOrdering
{
    [UsedImplicitly]
    BestRanked,

    [UsedImplicitly]
    WorstRanked,

    [UsedImplicitly]
    NameAZ,

    [UsedImplicitly]
    NameZA,

    [UsedImplicitly]
    MostPlayers,

    [UsedImplicitly]
    LeastPlayers,

    [UsedImplicitly]
    Newest,

    [UsedImplicitly]
    Oldest
}