using ConstructServices.Broadcasts.Objects;
using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

public static partial class Dimensions
{
    extension(BaseService service)
    {
        internal BaseResponse DeleteDimension(
            string apiEndPointPath,
            DeleteRatingDimensionOptions deleteRatingDimensionOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                apiEndPointPath,
                service,
                deleteRatingDimensionOptions.BuildFormData()
            );
        }

        internal async Task<BaseResponse> DeleteDimensionAsync(
            string apiEndPointPath,
            DeleteRatingDimensionOptions deleteRatingDimensionOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                apiEndPointPath,
                service,
                deleteRatingDimensionOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public abstract class DeleteRatingDimensionOptions(Thing forThing, Guid forThingID, string dimensionID)
    {
        [UsedImplicitly]
        private Thing ForThing { get;  } = forThing;

        [UsedImplicitly]
        private Guid ForThingID { get; } = forThingID;

        [UsedImplicitly]
        private string DimensionID { get; } = dimensionID;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "thingTypeID", ((byte)ForThing).ToString() },
                { "thingID", ForThingID.ToString() },
                { "dimensionID", DimensionID }
            };
            return formData;
        }
    }
    public sealed class DeleteBroadcastChannelRatingDimensionOptions : DeleteRatingDimensionOptions
    {
        private const Thing ThisThing = Thing.BroadcastChannel;

        [UsedImplicitly]
        public DeleteBroadcastChannelRatingDimensionOptions(Channel channel, string dimensionID) 
            : base(ThisThing, channel.ID, dimensionID)
        {
        }

        [UsedImplicitly]
        public DeleteBroadcastChannelRatingDimensionOptions(Guid channelID, string dimensionID) 
            : base(ThisThing, channelID, dimensionID)
        {
        }

        [UsedImplicitly]
        public DeleteBroadcastChannelRatingDimensionOptions(string strChannelID, string dimensionID) 
            : base(ThisThing, Guid.Parse(strChannelID), dimensionID)
        {
        }
    }

    public sealed class DeleteCloudSaveBucketRatingDimensionOptions : DeleteRatingDimensionOptions
    {
        private const Thing ThisThing = Thing.CloudSaveBucket;

        [UsedImplicitly]
        public DeleteCloudSaveBucketRatingDimensionOptions(Bucket bucket, string dimensionID) 
            : base(ThisThing, bucket.ID, dimensionID)
        {
        }

        [UsedImplicitly]
        public DeleteCloudSaveBucketRatingDimensionOptions(Guid bucketID, string dimensionID) 
            : base(ThisThing, bucketID, dimensionID)
        {
        }

        [UsedImplicitly]
        public DeleteCloudSaveBucketRatingDimensionOptions(string strBucketID, string dimensionID) 
            : base(ThisThing, Guid.Parse(strBucketID), dimensionID)
        {
        }
    }
}