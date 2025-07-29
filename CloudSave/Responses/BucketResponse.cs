﻿using ConstructServices.Common;
using Newtonsoft.Json;
using ConstructServices.CloudSave.Objects;

namespace ConstructServices.CloudSave.Responses;

public class BucketResponse : BaseResponse
{
    [JsonProperty(PropertyName = "bucket")]
    public GameBucket Bucket { get; set; }

    public BucketResponse()
    {
    }
    public BucketResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}