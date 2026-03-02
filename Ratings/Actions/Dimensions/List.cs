using System;
using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using System.Threading.Tasks;
using ConstructServices.Broadcasts.Objects;
using ConstructServices.CloudSave.Objects;
using JetBrains.Annotations;

namespace ConstructServices.Ratings.Actions;

public static partial class Dimensions
{
    extension(BaseService service)
    {
        internal DimensionsResponse ListDimensions(
            string apiEndPointPath,
            ListRatingDimensionOptions listRatingDimensionOptions)
        {
            return Request.ExecuteSyncRequest<DimensionsResponse>(
                apiEndPointPath,
                service,
                listRatingDimensionOptions.BuildFormData()
            );
        }

        internal async Task<DimensionsResponse> ListDimensionsAsync(
            string apiEndPointPath,
            ListRatingDimensionOptions listRatingDimensionOptions)
        {
            return await Request.ExecuteAsyncRequest<DimensionsResponse>(
                apiEndPointPath,
                service,
                listRatingDimensionOptions.BuildFormData()
            );
        }
    }

    
    [UsedImplicitly]
    public abstract class ListRatingDimensionOptions(
        Thing forThing,
        Guid forThingID)
    {
        private Thing ForThing { get; } = forThing;

        private Guid ForThingID { get; } = forThingID;

        protected internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "thingTypeID", ((byte)ForThing).ToString() },
                { "thingID", ForThingID.ToString() }
            };
            return formData;
        }
    }
    public sealed class ListBroadcastChannelDimensionOptions : ListRatingDimensionOptions
    {
        private const Thing ThisThing = Thing.BroadcastChannel;

        [UsedImplicitly]
        public ListBroadcastChannelDimensionOptions(Channel channel) : base(ThisThing, channel.ID)
        {
        }

        [UsedImplicitly]
        public ListBroadcastChannelDimensionOptions(Guid channelID) : base(ThisThing, channelID)
        {
        }

        [UsedImplicitly]
        public ListBroadcastChannelDimensionOptions(string strChannelID) : base(ThisThing, Guid.Parse(strChannelID))
        {
        }
    }
    public sealed class ListCloudSaveBucketDimensionOptions : ListRatingDimensionOptions
    {
        private const Thing ThisThing = Thing.CloudSaveBucket;

        [UsedImplicitly]
        public ListCloudSaveBucketDimensionOptions(Bucket bucket) : base(ThisThing, bucket.ID)
        {
        }

        [UsedImplicitly]
        public ListCloudSaveBucketDimensionOptions(Guid bucketID) : base(ThisThing, bucketID)
        {
        }

        [UsedImplicitly]
        public ListCloudSaveBucketDimensionOptions(string strBucketID) : base(ThisThing, Guid.Parse(strBucketID))
        {
        }
    }
}