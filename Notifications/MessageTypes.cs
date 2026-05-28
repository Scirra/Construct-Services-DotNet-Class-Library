using JetBrains.Annotations;

namespace ConstructServices.Notifications;

[UsedImplicitly]
public enum MessageType
{
    NewBroadcastMessage,
    AchievementAwarded,
    XPChanged,
    XPRankChanged
}