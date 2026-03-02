using ConstructServices.Broadcasts.Objects;
using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

public static partial class Dimensions
{
    extension(BaseService service)
    {
        internal DimensionResponse UpdateDimension(
            string apiEndPointPath,
            UpdateRatingDimensionBase updateRatingDimensionBase)
        {
            return Request.ExecuteSyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                updateRatingDimensionBase.BuildFormData()
            );
        }

        internal async Task<DimensionResponse> UpdateDimensionAsync(
            string apiEndPointPath,
            UpdateRatingDimensionBase updateRatingDimensionBase)
        {
            return await Request.ExecuteAsyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                updateRatingDimensionBase.BuildFormData()
            );
        }
    }

    public abstract class UpdateRatingDimensionBase
    {
        private Thing ForThing { get; }
        private Guid ForThingID { get; }
        
        [UsedImplicitly]
        public byte? MaxRating { get; set; }

        [UsedImplicitly]
        public string ID { get; set; }

        [UsedImplicitly]
        public string Title { get; set; }

        [UsedImplicitly]
        public string Description { get; set; }

        [UsedImplicitly]
        public string LanguageISO { get; set; }

        protected UpdateRatingDimensionBase(
            Thing forThing, 
            Guid forThingID, 
            string dimensionID)
        {
            ForThing = forThing;
            ForThingID = forThingID;
            ID = dimensionID;
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "dimensionID", ID },
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "thingTypeID", ((byte)ForThing).ToString() },
                { "thingID", ForThingID.ToString() }
            };
            if(MaxRating.HasValue) formData.Add("maxRating", MaxRating.ToString());
            return formData;
        }
    }
    public sealed class UpdateBroadcastChannelRatingDimensionOptions : UpdateRatingDimensionBase
    {
        private const Thing ThisThing = Thing.BroadcastChannel;

        [UsedImplicitly]
        public UpdateBroadcastChannelRatingDimensionOptions(Channel channel, string dimensionID) 
            : base(ThisThing, channel.ID, dimensionID)
        {
        }

        [UsedImplicitly]
        public UpdateBroadcastChannelRatingDimensionOptions(Guid channelID, string dimensionID) 
            : base(ThisThing, channelID, dimensionID)
        {
        }

        [UsedImplicitly]
        public UpdateBroadcastChannelRatingDimensionOptions(string strChannelID, string dimensionID) 
            : base(ThisThing, Guid.Parse(strChannelID), dimensionID)
        {
        }
    }

    public sealed class UpdateCloudSaveBucketRatingDimensionOptions : UpdateRatingDimensionBase
    {
        private const Thing ThisThing = Thing.CloudSaveBucket;

        [UsedImplicitly]
        public UpdateCloudSaveBucketRatingDimensionOptions(Bucket bucket, string dimensionID) 
            : base(ThisThing, bucket.ID, dimensionID)
        {
        }

        [UsedImplicitly]
        public UpdateCloudSaveBucketRatingDimensionOptions(Guid bucketID, string dimensionID) 
            : base(ThisThing, bucketID, dimensionID)
        {
        }

        [UsedImplicitly]
        public UpdateCloudSaveBucketRatingDimensionOptions(string strBucketID, string dimensionID) 
            : base(ThisThing, Guid.Parse(strBucketID), dimensionID)
        {
        }
    }
}