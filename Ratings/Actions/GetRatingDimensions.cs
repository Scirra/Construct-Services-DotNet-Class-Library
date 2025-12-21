using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Ratings.Responses;

namespace ConstructServices.Ratings.Actions;

internal static partial class Rating
{
    /// <summary>
    /// Get all rating dimensions
    /// </summary>
    internal static DimensionsResponse GetDimensions(
        this BaseService service,
        string apiEndPointPath,
        Thing ratableThing,
        Guid thingID)
    {
        var formData = new Dictionary<string, string>
        {
            { "thingTypeID", ((byte)ratableThing).ToString()},
            { "thingID", thingID.ToString()}
        };
        return Task.Run(() => Request.ExecuteRequest<DimensionsResponse>(
            apiEndPointPath,
            service,
            formData
        )).Result;
    }
}