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
    /// Get all rating slots
    /// </summary>
    internal static SlotsResponse GetSlots(
        this BaseService service,
        string apiEndPointPath,
        RatableThing ratableThing,
        Guid thingID)
    {
        var formData = new Dictionary<string, string>
        {
            { "thingTypeID", ((byte)ratableThing).ToString()},
            { "thingID", thingID.ToString()}
        };
        return Task.Run(() => Request.ExecuteRequest<SlotsResponse>(
            apiEndPointPath,
            service,
            formData
        )).Result;
    }
}