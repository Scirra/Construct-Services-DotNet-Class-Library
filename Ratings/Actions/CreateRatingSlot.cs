using ConstructServices.Common;
using ConstructServices.Ratings.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Ratings.Responses;

namespace ConstructServices.Ratings.Actions;


public static partial class Rating
{
    /// <summary>
    /// Create a rating slot
    /// </summary>
    internal static SlotResponse CreateSlot(
        this BaseService service,
        string apiEndPointPath,
        RatableThing ratableThing,
        Guid thingID,
        string slotID,
        string title,
        string description,
        byte maxRating)
    {
        var formData = new Dictionary<string, string>
        {
            { "thingTypeID", ((byte)ratableThing).ToString()},
            { "thingID", thingID.ToString()},
            { "slotID", slotID },
            { "title", title },
            { "description", description },
            { "maxRating", maxRating.ToString() }
        };
        return Task.Run(() => Request.ExecuteRequest<SlotResponse>(
            apiEndPointPath,
            service,
            formData
        )).Result;
    }
}