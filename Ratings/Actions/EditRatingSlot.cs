using ConstructServices.Common;
using ConstructServices.Ratings.Enums;
using ConstructServices.Ratings.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

public static partial class Rating
{
    /// <summary>
    /// Create a rating slot
    /// </summary>
    internal static SlotResponse EditSlot(
        this BaseService service,
        string apiEndPointPath,
        RatableThing ratableThing,
        Guid thingID,
        string slotID,
        string newTitle = null,
        string newDescription = null,
        byte? newMaxRating = null)
    {
        var formData = new Dictionary<string, string>
        {
            { "thingTypeID", ((byte)ratableThing).ToString()},
            { "thingID", thingID.ToString()},
            { "slotID", slotID }
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

        return Task.Run(() => Request.ExecuteRequest<SlotResponse>(
            apiEndPointPath,
            service,
            formData
        )).Result;
    }
}