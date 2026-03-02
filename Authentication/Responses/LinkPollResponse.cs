using System;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Authentication.Responses;
public sealed class LinkPollResponse : BaseResponse
{
    [JsonProperty(PropertyName = "linked")]
    public bool Linked { get; set; }

    [JsonProperty(PropertyName = "forceCode")]
    public Guid? ForceCode { get; set; }

    [JsonProperty(PropertyName = "forceURL")]
    public string ForceURL { get; set; }

    [JsonProperty(PropertyName = "forceCodeExpiryMins")]
    public int ForceCodeExpiryMins { get; set; }

    public LinkPollResponse()
    {
    }

    public LinkPollResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {
    }
}