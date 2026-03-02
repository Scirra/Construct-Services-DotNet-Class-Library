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
        internal DimensionResponse CreateDimension(
            string apiEndPointPath,
            CreateRatingDimensionOptions createRatingDimensionOptions)
        {
            return Request.ExecuteSyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                createRatingDimensionOptions.BuildFormData()
            );
        }
        internal async Task<DimensionResponse> CreateDimensionAsync(
            string apiEndPointPath,
            CreateRatingDimensionOptions createRatingDimensionOptions)
        {
            return await Request.ExecuteAsyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                createRatingDimensionOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public abstract class CreateRatingDimensionOptions
    {
        private Thing ForThing { get; }
        private Guid ForThingID { get; }
        private byte MaxRating { get; }
        private string ID { get;  }
        private string Title { get; }
        private string Description { get; }
        private string LanguageISO { get; }

        protected CreateRatingDimensionOptions(
            Thing forThing,
            Guid forThingID,
            byte maxRating,
            string id,
            string title,
            string description,
            string languageISO = null)
        {
            ForThing = forThing;
            ForThingID = forThingID;
            MaxRating = maxRating;
            ID = id;
            Title = title;
            Description = description;
            LanguageISO = languageISO;
        }
        protected CreateRatingDimensionOptions(
            Thing forThing,
            string strForThingID,
            byte maxRating,
            string id,
            string title,
            string description,
            string languageISO = null)
        {
            ForThing = forThing;
            ForThingID = Guid.Parse(strForThingID);
            MaxRating = maxRating;
            ID = id;
            Title = title;
            Description = description;
            LanguageISO = languageISO;
        }

        protected internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "dimensionID", ID },
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "thingTypeID", ((byte)ForThing).ToString() },
                { "thingID", ForThingID.ToString() },
                { "maxRating", MaxRating.ToString() }
            };
            return formData;
        }
    }

    public sealed class CreateBroadcastChannelRatingDimensionOptions : CreateRatingDimensionOptions
    {    
        [UsedImplicitly]
        public CreateBroadcastChannelRatingDimensionOptions(
            Channel channel,
            byte maxRating,
            string id,
            string title,
            string description,
            string languageISO = null) 
            : base(Thing.BroadcastChannel, channel.ID, maxRating, id, title, description, languageISO)
        {
        }

        [UsedImplicitly]
        public CreateBroadcastChannelRatingDimensionOptions(
            Guid channelID,
            byte maxRating,
            string id,
            string title,
            string description,
            string languageISO = null) 
            : base(Thing.BroadcastChannel, channelID, maxRating, id, title, description, languageISO)
        {
        }

        [UsedImplicitly]
        public CreateBroadcastChannelRatingDimensionOptions(
            string channelID,
            byte maxRating,
            string id,
            string title,
            string description,
            string languageISO = null) 
            : base(Thing.BroadcastChannel, channelID, maxRating, id, title, description, languageISO)
        {
        }
    }
    public sealed class CreateCloudSaveBucketRatingDimensionOptions : CreateRatingDimensionOptions
    {
        [UsedImplicitly]
        public CreateCloudSaveBucketRatingDimensionOptions(
            Bucket bucket,
            byte maxRating,
            string id,
            string title,
            string description,
            string languageISO = null) 
            : base(Thing.BroadcastChannel, bucket.ID, maxRating, id, title, description, languageISO)
        {
        }

        [UsedImplicitly]
        public CreateCloudSaveBucketRatingDimensionOptions(
            Guid bucketID,
            byte maxRating,
            string id,
            string title,
            string description,
            string languageISO = null) 
            : base(Thing.BroadcastChannel, bucketID, maxRating, id, title, description, languageISO)
        {
        }

        [UsedImplicitly]
        public CreateCloudSaveBucketRatingDimensionOptions(
            string bucketID,
            byte maxRating,
            string id,
            string title,
            string description,
            string languageISO = null) 
            : base(Thing.BroadcastChannel, bucketID, maxRating, id, title, description, languageISO)
        {
        }
    }
}