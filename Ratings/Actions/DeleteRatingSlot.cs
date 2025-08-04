using System;
using ConstructServices.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

public static partial class Rating
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
        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            apiEndPointPath,
            service,
            formData
        )).Result;
    }
}