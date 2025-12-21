using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Ratings.Responses;

namespace ConstructServices.Ratings.Actions;

internal static partial class Rating
{
    extension(BaseService service)
    {
        /// <summary>
        /// Create a rating dimension
        /// </summary>
        internal DimensionResponse CreateDimension(
            string apiEndPointPath,
            Thing ratableThing,
            Guid thingID,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
        {
            var dimensionIDValidator = Common.Validations.RatingDimensionID.ValidateDimensionID(dimensionID);
            if (!dimensionIDValidator.Successfull)
            {
                return new DimensionResponse(dimensionIDValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "thingTypeID", ((byte)ratableThing).ToString()},
                { "thingID", thingID.ToString()},
                { "dimensionID", dimensionID },
                { "title", title },
                { "description", description },
                { "maxRating", maxRating.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(languageISO))
            {
                formData.Add("language", languageISO);
            }

            return Request.ExecuteSyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Create a rating dimension
        /// </summary>
        internal async Task<DimensionResponse> CreateDimensionAsync(
            string apiEndPointPath,
            Thing ratableThing,
            Guid thingID,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
        {
            var dimensionIDValidator = Common.Validations.RatingDimensionID.ValidateDimensionID(dimensionID);
            if (!dimensionIDValidator.Successfull)
            {
                return new DimensionResponse(dimensionIDValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "thingTypeID", ((byte)ratableThing).ToString()},
                { "thingID", thingID.ToString()},
                { "dimensionID", dimensionID },
                { "title", title },
                { "description", description },
                { "maxRating", maxRating.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(languageISO))
            {
                formData.Add("language", languageISO);
            }

            return await Request.ExecuteAsyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                formData
            );
        }
    }
}