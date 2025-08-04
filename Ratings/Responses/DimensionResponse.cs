using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Ratings.Responses;

public class DimensionResponse : BaseResponse
{
    [JsonProperty(PropertyName = "dimension")]
    public Objects.RatingDimension Dimension { get; set; }

    public DimensionResponse()
    {
    }
    public DimensionResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {
    }
}