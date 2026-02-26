using System;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.XP.Objects;

public sealed class XPRank
{
    [JsonProperty(PropertyName = "id")]
    public Guid ID { get; internal set; }
        
    [JsonProperty(PropertyName = "atXP")]
    public long AtXP { get; internal set; }

    [JsonProperty(PropertyName = "formattedAtXP")]
    public string FormattedAtXP { get; set; }
        
    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }
        
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    [JsonProperty(PropertyName = "originalLanguage")]
    public Language OriginalLanguage  { get; set; }
    
    [JsonProperty(PropertyName = "responseLanguage")]
    public Language ResponseLanguage { get; set; }

    public XPRank()
    {

    }
}