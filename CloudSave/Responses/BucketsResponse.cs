using ConstructServices.Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using ConstructServices.CloudSave.Objects;

namespace ConstructServices.CloudSave.Responses
{
    public sealed class BucketsResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty(PropertyName = "buckets")]
        public List<GameBucket> Buckets { get; set; }

        public BucketsResponse()
        {
        }
        public BucketsResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
