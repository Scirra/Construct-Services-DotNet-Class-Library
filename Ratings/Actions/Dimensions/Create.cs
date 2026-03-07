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
        internal DimensionResponse CreateDimension(
            Thing forThing,
            Guid forThingID,
            string apiEndPointPath,
            CreateRatingDimensionOptions createRatingDimensionOptions)
        {
            var validation = createRatingDimensionOptions.Validate();
            if (!validation.Valid) return new DimensionResponse(validation.ErrorMessage);

            return Request.ExecuteSyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                createRatingDimensionOptions.BuildFormData(forThing, forThingID)
            );
        }
        internal async Task<DimensionResponse> CreateDimensionAsync(
            Thing forThing,
            Guid forThingID,
            string apiEndPointPath,
            CreateRatingDimensionOptions createRatingDimensionOptions)
        {
            var validation = createRatingDimensionOptions.Validate();
            if (!validation.Valid) return new DimensionResponse(validation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                createRatingDimensionOptions.BuildFormData(forThing, forThingID)
            );
        }
    }

    [UsedImplicitly]
    public sealed class CreateRatingDimensionOptions
    {
        [UsedImplicitly]
        public byte MaxRating { private get; set; }

        [UsedImplicitly]
        public string ID { private get; set; }
        
        [UsedImplicitly]
        public string Title { private get; set; }

        [UsedImplicitly]
        public string Description { private get; set; }
        
        [UsedImplicitly]
        public string LanguageISO { private get; set; }

        [UsedImplicitly]
        public SourceLanguage Language {
            set => LanguageISO = value.ISO();
        }
        
        internal Common.Validations.Responses.ValidationResponseBase Validate()
        {
            var languageValidation = Functions.IsSourceLanguageISOValid(LanguageISO, true);
            if (!languageValidation.Valid) return languageValidation;

            return new Common.Validations.Responses.SuccessfullValidation();
        }

        internal Dictionary<string, string> BuildFormData(Thing forThing, Guid forThingID)
        {
            var formData = new Dictionary<string, string>
            {
                { "dimensionID", ID },
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "thingTypeID", ((byte)forThing).ToString() },
                { "thingID", forThingID.ToString() },
                { "maxRating", MaxRating.ToString() }
            };
            return formData;
        }
    }
}