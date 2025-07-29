using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.CloudSave.Responses
{
    public class CloudSavesResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "blob")]
        public Objects.CloudSave Blob { get; set; }

        public CloudSavesResponse()
        {
        }

        public CloudSavesResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}