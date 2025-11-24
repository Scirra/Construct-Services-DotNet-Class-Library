using ConstructServices.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConstructServices.CloudSave.Responses;

public sealed class CloudSavesResponse : BaseResponse
{
    [JsonProperty(PropertyName = "pagination")]
    public Pagination Pagination { get; set; }

    [JsonProperty(PropertyName = "blobs")]
    public List<Objects.CloudSave> Blobs { get; set; }

    public CloudSavesResponse()
    {
    }
    public CloudSavesResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}