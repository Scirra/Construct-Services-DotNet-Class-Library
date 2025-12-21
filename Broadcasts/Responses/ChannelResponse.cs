using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Broadcasts.Responses;

public sealed class ChannelResponse : BaseResponse
{
    [JsonProperty(PropertyName = "channel")]
    public Channel Channel { get; set; }

    public ChannelResponse()
    {
    }
    public ChannelResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}