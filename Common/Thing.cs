using JetBrains.Annotations;

namespace ConstructServices.Common;

public enum Thing : byte
{
    [UsedImplicitly]
    CloudSaveBlob = 0,

    [UsedImplicitly]
    BroadcastChannel = 1,

    [UsedImplicitly]
    BroadcastMessage = 2,

    [UsedImplicitly]
    CloudSaveBucket = 3,

    [UsedImplicitly]
    Leaderboard = 4,

    [UsedImplicitly]
    Player = 5,

    [UsedImplicitly]
    Game = 6,

    [UsedImplicitly]
    GameAPIKey = 7
}