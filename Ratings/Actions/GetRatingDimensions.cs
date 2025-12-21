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
        /// Get all rating dimensions
        /// </summary>
        internal DimensionsResponse GetDimensions(string apiEndPointPath,
            Thing ratableThing,
            Guid thingID)
        {
            var formData = new Dictionary<string, string>
            {
                { "thingTypeID", ((byte)ratableThing).ToString()},
                { "thingID", thingID.ToString()}
            };
            return Request.ExecuteSyncRequest<DimensionsResponse>(
                apiEndPointPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Get all rating dimensions
        /// </summary>
        internal async Task<DimensionsResponse> GetDimensionsAsync(string apiEndPointPath,
            Thing ratableThing,
            Guid thingID)
        {
            var formData = new Dictionary<string, string>
            {
                { "thingTypeID", ((byte)ratableThing).ToString()},
                { "thingID", thingID.ToString()}
            };
            return await Request.ExecuteAsyncRequest<DimensionsResponse>(
                apiEndPointPath,
                service,
                formData
            );
        }
    }
}