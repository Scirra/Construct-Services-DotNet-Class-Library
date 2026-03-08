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
            Thing forThing,
            Guid thingID,
            string apiEndPointPath,
            RateObjectOptions rateObjectOptions)
        {
            var validation = rateObjectOptions.Validate();
            if (!validation.Valid) return new RateResponse(validation.ErrorMessage);

            return Request.ExecuteSyncRequest<RateResponse>(
                apiEndPointPath,
                service,
                rateObjectOptions.BuildFormData(forThing, thingID)
            );
        }

        internal async Task<RateResponse> RateAsync(
            Thing forThing,
            Guid thingID,
            string apiEndPointPath,
            RateObjectOptions rateObjectOptions)
        {
            var validation = rateObjectOptions.Validate();
            if (!validation.Valid) return new RateResponse(validation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<RateResponse>(
                apiEndPointPath,
                service,
                rateObjectOptions.BuildFormData(forThing, thingID)
            );
        }
    }

    [UsedImplicitly]
    public class DimensionRating
    {
        [UsedImplicitly]
        public string DimensionID { internal get; set; }

        [UsedImplicitly]
        public byte Rating { internal get; set; }
    }

    public sealed class RateObjectOptions
    {
        [UsedImplicitly]
        public byte? DimensionlessRating { private get; set; }

        [UsedImplicitly]
        public List<DimensionRating> DimensionRatings { private get; set; }
        
        internal Common.Validations.Responses.ValidationResponseBase Validate()
        {
            if ((DimensionRatings == null || !DimensionRatings.Any()) && !DimensionlessRating.HasValue)
            {
                return new Common.Validations.Responses.FailedValidation("No ratings were passed in the request.");
            }
            return new Common.Validations.Responses.SuccessfullValidation();
        }
        internal Dictionary<string, string> BuildFormData(Thing forThing, Guid forThingID)
        {
            var formData = new Dictionary<string, string>
            {
                { "thingTypeID", ((byte)forThing).ToString()},
                { "thingID", forThingID.ToString()}
            };

            // Add dimensionless rating
            if (DimensionlessRating.HasValue)
            {
                DimensionRatings ??= [];
                DimensionRatings.Add(new DimensionRating
                {
                    DimensionID = string.Empty,
                    Rating = DimensionlessRating.Value
                });
            }

            // Add form data
            if (DimensionRatings != null)
            {
                formData.Add("value", string.Join(",", DimensionRatings.Select(c=> c.DimensionID + "=" + c.Rating)));
            }
            return formData;
        }
    }
}