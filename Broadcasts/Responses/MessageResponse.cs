using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Broadcasts.Responses;

public sealed class MessageResponse : BaseResponse
{
    [JsonProperty(PropertyName = "message")]
    public Message Message { get; set; }

    public MessageResponse()
    {
    }
    public MessageResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}