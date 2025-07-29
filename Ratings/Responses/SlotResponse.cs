using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Ratings.Responses;

public class SlotResponse : BaseResponse
{
    [JsonProperty(PropertyName = "slot")]
    public Objects.RatingSlot Slot { get; set; }

    public SlotResponse()
    {
    }
    public SlotResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {
    }
}