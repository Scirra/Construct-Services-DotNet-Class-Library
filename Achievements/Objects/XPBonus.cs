using Newtonsoft.Json;

namespace ConstructServices.Achievements.Objects;

public sealed class XPBonus
{
    [JsonProperty(PropertyName = "from")]
    public int From { get; set; }

    [JsonProperty(PropertyName = "bonus")]
    public long Bonus { get; set; }

    public XPBonus()
    {

    }
}