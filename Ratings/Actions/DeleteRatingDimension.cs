using System;
using ConstructServices.Common;
using System.Collections.Generic;

namespace ConstructServices.Ratings.Actions;
internal static partial class Rating
{
    /// <summary>
    /// Delete a rating dimension
    /// </summary>
    internal static BaseResponse DeleteDimension(
        this BaseService service,
        string apiEndPointPath,
        Thing ratableThing,
        Guid thingID,
        string dimensionID)
    {
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
}