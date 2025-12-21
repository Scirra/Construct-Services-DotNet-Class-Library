using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.CloudSave.Responses;

public sealed class CloudSaveResponse : BaseResponse
{
    [JsonProperty(PropertyName = "blob")]
    public Objects.CloudSave Blob { get; set; }

    public CloudSaveResponse()
    {
    }

    public CloudSaveResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}