using ConstructServices.Common;
using System;
using System.Collections.Generic;
using ConstructServices.Ratings.Responses;

namespace ConstructServices.Ratings.Actions;

internal static partial class Rating
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
        byte maxRating,
        string languageISO = null)
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
}