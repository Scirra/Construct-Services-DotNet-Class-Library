using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using ConstructServices.Broadcasts.Objects;

namespace ConstructServices.Ratings.Objects;

public abstract class RateObjectBase
{
    private string SessionKey { get; }
    private Thing ForThing { get; }
    private Guid ForThingID { get; }
    private Dictionary<string, byte> Ratings { get; }

    protected RateObjectBase(string sessionKey, Thing forThing, Guid forThingID, Dictionary<string, byte> ratings)
    {
        SessionKey = sessionKey;
        ForThing = forThing;
        ForThingID = forThingID;
        Ratings = ratings;
    }

    protected RateObjectBase(string sessionKey, Thing forThing, Guid forThingID, byte rating)
    {
        SessionKey = sessionKey;
        ForThing = forThing;
        ForThingID = forThingID;
        Ratings = new Dictionary<string, byte> { {string.Empty, rating} };
    }

    protected internal Dictionary<string, string> BuildFormData() => new()
    {
        { "sessionKey", SessionKey},
        { "thingTypeID", ((byte)ForThing).ToString()},
        { "thingID", ForThingID.ToString()},
        { "value", string.Join(",", Ratings.Select(c=> c.Key + "=" + c.Value))}
    };
}
public sealed class RateBroadcastMessageOptions: RateObjectBase
{            
    private const Thing ThisThing = Thing.BroadcastChannel;
    
    [UsedImplicitly]
    public RateBroadcastMessageOptions(string sessionKey, Channel channel, byte rating) : base(sessionKey, ThisThing, channel.ID, rating) { }

    [UsedImplicitly]
    public RateBroadcastMessageOptions(string sessionKey, Guid channelID, byte rating) : base(sessionKey, ThisThing, channelID, rating) { }

    [UsedImplicitly]
    public RateBroadcastMessageOptions(string sessionKey, string strChannelID, byte rating) : base(sessionKey, ThisThing, Guid.Parse(strChannelID), rating) { }
    
    [UsedImplicitly]
    public RateBroadcastMessageOptions(string sessionKey, Channel channel, Dictionary<string, byte> ratings) : base(sessionKey, ThisThing, channel.ID, ratings) { }

    [UsedImplicitly]
    public RateBroadcastMessageOptions(string sessionKey, Guid channelID, Dictionary<string, byte> ratings) : base(sessionKey, ThisThing, channelID, ratings) { }

    [UsedImplicitly]
    public RateBroadcastMessageOptions(string sessionKey, string strChannelID, Dictionary<string, byte> ratings) : base(sessionKey, ThisThing, Guid.Parse(strChannelID), ratings) { }
}

public sealed class RateCloudSaveOptions: RateObjectBase
{            
    private const Thing ThisThing = Thing.CloudSaveBucket;
    
    [UsedImplicitly]
    public RateCloudSaveOptions(string sessionKey, GameBucket bucket, byte rating) : base(sessionKey, ThisThing, bucket.ID, rating) { }

    [UsedImplicitly]
    public RateCloudSaveOptions(string sessionKey, Guid bucketID, byte rating) : base(sessionKey, ThisThing, bucketID, rating) { }

    [UsedImplicitly]
    public RateCloudSaveOptions(string sessionKey, string strBucketID, byte rating) : base(sessionKey, ThisThing, Guid.Parse(strBucketID), rating) { }

    [UsedImplicitly]
    public RateCloudSaveOptions(string sessionKey, GameBucket bucket, Dictionary<string, byte> ratings) : base(sessionKey, ThisThing, bucket.ID, ratings) { }

    [UsedImplicitly]
    public RateCloudSaveOptions(string sessionKey, Guid bucketID, Dictionary<string, byte> ratings) : base(sessionKey, ThisThing, bucketID, ratings) { }

    [UsedImplicitly]
    public RateCloudSaveOptions(string sessionKey, string strBucketID, Dictionary<string, byte> ratings) : base(sessionKey, ThisThing, Guid.Parse(strBucketID), ratings) { }
}