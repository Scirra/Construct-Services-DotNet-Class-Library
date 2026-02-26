using ConstructServices.Common;
using Newtonsoft.Json;
using System;

namespace ConstructServices.XP.Objects;

public sealed class XPBonus
{        
    [JsonProperty(PropertyName = "id")] 
    public Guid ID { get; set; }
        
    [JsonProperty(PropertyName = "startDate")]
    public DateTime StartDate { get; set; }
    
    [JsonProperty(PropertyName = "formattedStartDate")]
    public string FormattedStartDate { get; set; }
    
    [JsonProperty(PropertyName = "endDate")]
    public DateTime EndDate { get; set; }
    
    [JsonProperty(PropertyName = "formattedEndDate")]
    public string FormattedEndDate { get; set; }
        
    [JsonProperty(PropertyName = "modifier")]
    public decimal Modifier { get; set; }

    [JsonProperty(PropertyName = "title")]
    public string Title { get; internal set; }
    
    [JsonProperty(PropertyName = "description")]
    public string Description { get; internal set; }

    [JsonProperty(PropertyName = "originalLanguage")]
    public Language OriginalLanguage { get; set; }
    
    [JsonProperty(PropertyName = "responseLanguage")]
    public Language ResponseLanguage { get; set; }

    public XPBonus()
    {
    }
}