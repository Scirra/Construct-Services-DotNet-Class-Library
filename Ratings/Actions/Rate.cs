using ConstructServices.Broadcasts.Objects;
using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

public static class Rating
{
    extension(BaseService service)
    {
        internal RateResponse Rate(
            string apiEndPointPath,
            RateObjectBase rateObjectBase)
        {
            return Request.ExecuteSyncRequest<RateResponse>(
                apiEndPointPath,
                service,
                rateObjectBase.BuildFormData()
            );
        }

        internal async Task<RateResponse> RateAsync(
            string apiEndPointPath,
            RateObjectBase rateObjectBase)
        {
            return await Request.ExecuteAsyncRequest<RateResponse>(
                apiEndPointPath,
                service,
                rateObjectBase.BuildFormData()
            );
        }
    }

    public abstract class RateObjectBase
    {
        private Thing ForThing { get; }
        private Guid ForThingID { get; }
        private Dictionary<string, byte> Ratings { get; }

        protected RateObjectBase(Thing forThing, Guid forThingID, Dictionary<string, byte> ratings)
        {
            ForThing = forThing;
            ForThingID = forThingID;
            Ratings = ratings;
        }

        protected RateObjectBase(Thing forThing, Guid forThingID, byte rating)
        {
            ForThing = forThing;
            ForThingID = forThingID;
            Ratings = new Dictionary<string, byte> { {string.Empty, rating} };
        }

        protected internal Dictionary<string, string> BuildFormData() => new()
        {
            { "thingTypeID", ((byte)ForThing).ToString()},
            { "thingID", ForThingID.ToString()},
            { "value", string.Join(",", Ratings.Select(c=> c.Key + "=" + c.Value))}
        };
    }
    public sealed class RateBroadcastMessageOptions: RateObjectBase
    {            
        private const Thing ThisThing = Thing.BroadcastChannel;
        
        [UsedImplicitly]
        public RateBroadcastMessageOptions(Channel channel, byte rating) : base(ThisThing, channel.ID, rating) { }

        [UsedImplicitly]
        public RateBroadcastMessageOptions(Guid channelID, byte rating) : base(ThisThing, channelID, rating) { }

        [UsedImplicitly]
        public RateBroadcastMessageOptions(string strChannelID, byte rating) : base(ThisThing, Guid.Parse(strChannelID), rating) { }
        
        [UsedImplicitly]
        public RateBroadcastMessageOptions(Channel channel, Dictionary<string, byte> ratings) : base(ThisThing, channel.ID, ratings) { }

        [UsedImplicitly]
        public RateBroadcastMessageOptions(Guid channelID, Dictionary<string, byte> ratings) : base(ThisThing, channelID, ratings) { }

        [UsedImplicitly]
        public RateBroadcastMessageOptions(string strChannelID, Dictionary<string, byte> ratings) : base(ThisThing, Guid.Parse(strChannelID), ratings) { }
    }

    public sealed class RateCloudSaveOptions: RateObjectBase
    {            
        private const Thing ThisThing = Thing.CloudSaveBucket;
        
        [UsedImplicitly]
        public RateCloudSaveOptions(Bucket bucket, byte rating) : base(ThisThing, bucket.ID, rating) { }

        [UsedImplicitly]
        public RateCloudSaveOptions(Guid bucketID, byte rating) : base(ThisThing, bucketID, rating) { }

        [UsedImplicitly]
        public RateCloudSaveOptions(string strBucketID, byte rating) : base(ThisThing, Guid.Parse(strBucketID), rating) { }

        [UsedImplicitly]
        public RateCloudSaveOptions(Bucket bucket, Dictionary<string, byte> ratings) : base(ThisThing, bucket.ID, ratings) { }

        [UsedImplicitly]
        public RateCloudSaveOptions(Guid bucketID, Dictionary<string, byte> ratings) : base(ThisThing, bucketID, ratings) { }

        [UsedImplicitly]
        public RateCloudSaveOptions(string strBucketID, Dictionary<string, byte> ratings) : base(ThisThing, Guid.Parse(strBucketID), ratings) { }
    }
}