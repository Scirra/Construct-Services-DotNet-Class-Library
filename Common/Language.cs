using Newtonsoft.Json;

namespace ConstructServices.Common;

public sealed class Language
{
    [JsonProperty(PropertyName = "iso")]
    public string ISO { get; private set; }

    [JsonProperty(PropertyName = "englishName")]
    public string EnglishName { get; private set; }

    public Language()
    {

    }
}