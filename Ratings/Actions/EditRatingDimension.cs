using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

internal static partial class Rating
{
    extension(BaseService service)
    {
        /// <summary>
        /// Update a rating dimension
        /// </summary>
        internal DimensionResponse EditDimension(string apiEndPointPath,
            Thing ratableThing,
            Guid thingID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
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
                { "dimensionID", dimensionID }
            };
            if (!string.IsNullOrEmpty(newTitle))
            {
                formData.Add("title", newTitle);
            }
            if (!string.IsNullOrEmpty(newDescription))
            {
                formData.Add("description", newDescription);
            }
            if (newMaxRating.HasValue)
            {
                formData.Add("maxRating", newMaxRating.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(newLanguageISO))
            {
                formData.Add("language", newLanguageISO);
            }

            return Request.ExecuteSyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Update a rating dimension
        /// </summary>
        internal async Task<DimensionResponse> EditDimensionAsync(string apiEndPointPath,
            Thing ratableThing,
            Guid thingID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
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
                { "dimensionID", dimensionID }
            };
            if (!string.IsNullOrEmpty(newTitle))
            {
                formData.Add("title", newTitle);
            }
            if (!string.IsNullOrEmpty(newDescription))
            {
                formData.Add("description", newDescription);
            }
            if (newMaxRating.HasValue)
            {
                formData.Add("maxRating", newMaxRating.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(newLanguageISO))
            {
                formData.Add("language", newLanguageISO);
            }

            return await Request.ExecuteAsyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                formData
            );
        }
    }
}