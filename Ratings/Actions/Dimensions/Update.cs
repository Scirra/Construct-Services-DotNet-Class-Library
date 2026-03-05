using ConstructServices.Common;
using ConstructServices.Common.Languages;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Functions = ConstructServices.Common.Validations.Common.Functions;

namespace ConstructServices.Ratings.Actions;

public static partial class Dimensions
{
    extension(BaseService service)
    {
        internal DimensionResponse UpdateDimension(
            string apiEndPointPath,            
            Guid forThingID,
            string dimensionID,
            UpdateRatingDimensionBase updateRatingDimensionBase)
        {
            return Request.ExecuteSyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                updateRatingDimensionBase.BuildFormData(forThingID, dimensionID)
            );
        }

        internal async Task<DimensionResponse> UpdateDimensionAsync(
            string apiEndPointPath,    
            Guid forThingID,
            string dimensionID,
            UpdateRatingDimensionBase updateRatingDimensionBase)
        {
            return await Request.ExecuteAsyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                updateRatingDimensionBase.BuildFormData(forThingID, dimensionID)
            );
        }
    }

    public abstract class UpdateRatingDimensionBase
    {
        private Thing ForThing { get; }
        
        [UsedImplicitly]
        public byte? MaxRating { private get; set; }
        
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

        internal UpdateRatingDimensionBase(Thing forThing)
        {
            ForThing = forThing;
        }

        internal Dictionary<string, string> BuildFormData(Guid thingID, string dimensionID)
        {
            var formData = new Dictionary<string, string>
            {
                { "dimensionID", dimensionID },
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "thingTypeID", ((byte)ForThing).ToString() },
                { "thingID", thingID.ToString() }
            };
            if(MaxRating.HasValue) formData.Add("maxRating", MaxRating.ToString());
            return formData;
        }
    }    
    
    [UsedImplicitly]
    public sealed class UpdateChannelRatingDimensionOptions() : UpdateRatingDimensionBase(Thing.BroadcastChannel);
    
    [UsedImplicitly]
    public sealed class UpdateCloudSaveBucketRatingDimensionOptions() : UpdateRatingDimensionBase(Thing.CloudSaveBucket);
}