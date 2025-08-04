using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Ratings.Responses;

namespace ConstructServices.Ratings.Actions;

public static partial class Rating
{
    /// <summary>
    /// Create a rating dimension
    /// </summary>
    internal static DimensionResponse CreateDimension(
        this BaseService service,
        string apiEndPointPath,
        Thing ratableThing,
        Guid thingID,
        string dimensionID,
        string title,
        string description,
        byte maxRating)
    {
        var formData = new Dictionary<string, string>
        {
            { "thingTypeID", ((byte)ratableThing).ToString()},
            { "thingID", thingID.ToString()},
            { "dimensionID", dimensionID },
            { "title", title },
            { "description", description },
            { "maxRating", maxRating.ToString() }
        };
        return Task.Run(() => Request.ExecuteRequest<DimensionResponse>(
            apiEndPointPath,
            service,
            formData
        )).Result;
    }
}