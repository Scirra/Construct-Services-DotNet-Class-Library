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
        /// Delete a rating dimension
        /// </summary>
        internal BaseResponse DeleteDimension(string apiEndPointPath,
            Thing ratableThing,
            Guid thingID,
            string dimensionID)
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
            return Request.ExecuteSyncRequest<BaseResponse>(
                apiEndPointPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Delete a rating dimension
        /// </summary>
        internal async Task<BaseResponse> DeleteDimensionAsync(string apiEndPointPath,
            Thing ratableThing,
            Guid thingID,
            string dimensionID)
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
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                apiEndPointPath,
                service,
                formData
            );
        }
    }
}