using ConstructServices.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConstructServices.Ratings.Responses;

public sealed class DimensionsResponse : BaseResponse
{
    [JsonProperty(PropertyName = "dimensions")]
    public List<Objects.RatingDimension> Dimensions { get; set; }

    public DimensionsResponse()
    {
    }
    public DimensionsResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {
    }
}