using System;
using ConstructServices.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Ratings.Enums;

namespace ConstructServices.Ratings.Actions;

public static partial class Rating
{
    /// <summary>
    /// Delete a rating slot
    /// </summary>
    internal static BaseResponse DeleteSlot(
        this BaseService service,
        string apiEndPointPath,
        RatableThing ratableThing,
        Guid thingID,
        string slotID)
    {
        var formData = new Dictionary<string, string>
        {
            { "thingTypeID", ((byte)ratableThing).ToString()},
            { "thingID", thingID.ToString()},
            { "slotID", slotID }
        };
        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            apiEndPointPath,
            service,
            formData
        )).Result;
    }
}