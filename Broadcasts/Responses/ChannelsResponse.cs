using System.Collections.Generic;
using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Broadcasts.Responses;

public sealed class ChannelsResponse : BaseResponse
{
    [JsonProperty(PropertyName = "channels")]
    public List<Channel> Channels { get; set; }

    public ChannelsResponse()
    {
    }
    public ChannelsResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}