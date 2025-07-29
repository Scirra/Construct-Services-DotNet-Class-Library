﻿using ConstructServices.Common;
using ConstructServices.Ratings.Enums;
using ConstructServices.Ratings.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

public static partial class Rating
{
    /// <summary>
    /// Rate an object
    /// </summary>
    internal static RateResponse Rate(
        this BaseService service,
        string apiEndPointPath,
        string sessionKey,
        RatableThing ratableThing,
        Guid thingID,
        Dictionary<string, byte> slotRatings)
    {
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", sessionKey},
            { "thingTypeID", ((byte)ratableThing).ToString()},
            { "thingID", thingID.ToString()},
            { "value", string.Join(",", slotRatings.Select(c=> c.Key + "=" + c.Value))}
        };
        return Task.Run(() => Request.ExecuteRequest<RateResponse>(
            apiEndPointPath,
            service,
            formData
        )).Result;
    }

    /// <summary>
    /// Rate an object
    /// </summary>
    internal static RateResponse Rate(
        this BaseService service,
        string apiEndPointPath,
        string sessionKey,
        RatableThing ratableThing,
        Guid thingID,
        byte rating)
        => Rate(service, sessionKey, apiEndPointPath, ratableThing, thingID,
            new Dictionary<string, byte> { { string.Empty, rating } });
}