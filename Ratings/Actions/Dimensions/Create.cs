using ConstructServices.Broadcasts.Objects;
using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common.Languages;
using Functions = ConstructServices.Common.Validations.Common.Functions;

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
    public abstract class CreateRatingDimensionOptions(
        Thing forThing,
        Guid forThingID,
        byte maxRating)
    {
        private Thing ForThing { get; } = forThing;
        private Guid ForThingID { get; } = forThingID;
        private byte MaxRating { get; } = maxRating;

        [UsedImplicitly]
        public string ID { private get; set; }
        
        [UsedImplicitly]
        public string Title { private get; set; }

        [UsedImplicitly]
        public string Description { private get; set; }

        [UsedImplicitly]
        public string LanguageISO {
            private get;
            set
            {
                if (!Functions.IsValidSourceLanguage(value))
                    throw new InvalidSourceLanguageException();
                field = value;
            }
        }

        [UsedImplicitly]
        public SourceLanguage Language {
            set => LanguageISO = value.ISO();
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
            byte maxRating) 
            : base(Thing.BroadcastChannel, channel.ID, maxRating)
        {
        }

        [UsedImplicitly]
        public CreateBroadcastChannelRatingDimensionOptions(
            Guid channelID,
            byte maxRating) 
            : base(Thing.BroadcastChannel, channelID, maxRating)
        {
        }
    }
    public sealed class CreateCloudSaveBucketRatingDimensionOptions : CreateRatingDimensionOptions
    {
        [UsedImplicitly]
        public CreateCloudSaveBucketRatingDimensionOptions(
            Bucket bucket,
            byte maxRating) 
            : base(Thing.BroadcastChannel, bucket.ID, maxRating)
        {
        }

        [UsedImplicitly]
        public CreateCloudSaveBucketRatingDimensionOptions(
            Guid bucketID,
            byte maxRating) 
            : base(Thing.BroadcastChannel, bucketID, maxRating)
        {
        }
    }
}