using System;
using Newtonsoft.Json;

namespace ConstructServices.CloudSave.Objects;

public class Rating
{
    [JsonProperty(PropertyName = "date")]
    public DateTime Date { get; set; }

    [JsonProperty(PropertyName = "value")]
    public byte Value { get; set; }
    
    public Rating()
    {
    }
}