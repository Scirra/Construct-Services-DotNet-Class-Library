using System.Collections.Generic;
using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Broadcasts.Responses;

public sealed class MessagesResponse : BaseResponse
{
    [JsonProperty(PropertyName = "messages")]
    public List<Message> Messages { get; set; }

    public MessagesResponse()
    {
    }
    public MessagesResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}