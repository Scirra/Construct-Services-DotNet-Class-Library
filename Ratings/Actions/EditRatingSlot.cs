using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

internal static partial class Rating
{
    /// <summary>
    /// Update a rating dimension
    /// </summary>
    internal static DimensionResponse EditDimension(
        this BaseService service,
        string apiEndPointPath,
        Thing ratableThing,
        Guid thingID,
        string dimensionID,
        string newTitle = null,
        string newDescription = null,
        byte? newMaxRating = null)
    {
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

        return Task.Run(() => Request.ExecuteRequest<DimensionResponse>(
            apiEndPointPath,
            service,
            formData
        )).Result;
    }
}