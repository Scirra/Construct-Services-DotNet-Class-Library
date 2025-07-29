﻿using ConstructServices.Common;
using ConstructServices.Ratings.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConstructServices.Ratings.Responses;

public class RateResponse : BaseResponse
{
    [JsonProperty(PropertyName = "rating")]
    public RatingAggregate Rating { get; set; }

    [JsonProperty(PropertyName = "slotRatings")]
    public List<RatingSlot> Slots { get; set; }

    public RateResponse()
    {
    }
    public RateResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {
    }
}