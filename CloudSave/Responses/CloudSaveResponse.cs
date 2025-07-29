using ConstructServices.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Responses
{
    public class CloudSaveResponse : BaseResponse
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
}
