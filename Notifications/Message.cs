using Newtonsoft.Json;
using System;
using JetBrains.Annotations;

namespace ConstructServices.Notifications;

public abstract class WebsocketMessage(MessageType messageType)
{
    [UsedImplicitly]
    public MessageType MessageType { get; } = messageType;
}

public sealed class NewBroadcastWebsocketMessage(Guid channelID, Guid messageID) : WebsocketMessage(MessageType.NewBroadcastMessage)
{
    [UsedImplicitly]
    [JsonProperty(PropertyName = "channelID")]
    public Guid ChannelID { get; } = channelID;
        
    [UsedImplicitly]
    [JsonProperty(PropertyName = "messageID")]
    public Guid MessageID { get; } = messageID;
}

public sealed class AchievementAwardedWebsocketMessage(Guid achievementID, int awarded) : WebsocketMessage(MessageType.AchievementAwarded)
{
    [UsedImplicitly]
    [JsonProperty(PropertyName = "achievementID")]
    public Guid AchievementID { get; } = achievementID;
        
    [UsedImplicitly]
    [JsonProperty(PropertyName = "awarded")]
    public int Awarded { get; } = awarded;
}

public sealed class XPChangedWebsocketMessage(long change, long currentXP) : WebsocketMessage(MessageType.XPChanged)
{
    [UsedImplicitly]
    [JsonProperty(PropertyName = "change")]
    public long Change { get; } = change;
        
    [UsedImplicitly]
    [JsonProperty(PropertyName = "currentXP")]
    public long CurrentXP { get; } = currentXP;
}

public sealed class XPRankChangedWebsocketMessage(Guid oldRankID, Guid newRankID, bool isPromotion) : WebsocketMessage(MessageType.XPRankChanged)
{
    [UsedImplicitly]
    [JsonProperty(PropertyName = "oldRankID")]
    public Guid OldRankID { get; } = oldRankID;
        
    [UsedImplicitly]
    [JsonProperty(PropertyName = "newRankID")]
    public Guid NewRankID { get; } = newRankID;

    [UsedImplicitly]
    [JsonProperty(PropertyName = "isPromotion")]
    public bool IsPromotion { get; } = isPromotion;
}