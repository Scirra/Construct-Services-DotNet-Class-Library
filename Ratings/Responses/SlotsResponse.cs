using ConstructServices.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConstructServices.Ratings.Responses;

internal class SlotsResponse : BaseResponse
{
    [JsonProperty(PropertyName = "slots")]
    public List<Objects.RatingSlot> Slots { get; set; }

    public SlotsResponse()
    {
    }
    public SlotsResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {
    }
}