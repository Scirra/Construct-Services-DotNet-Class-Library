using Newtonsoft.Json;

namespace ConstructServices.Authentication.Objects;

public class AvailableAvatar
{
    [JsonProperty(PropertyName = "width")]
    public uint Width { get; set; }
            
    [JsonProperty(PropertyName = "height")]
    public uint Height { get; set; }
            
    [JsonProperty(PropertyName = "url")]
    public string URL { get; set; }

    public AvailableAvatar()
    {

    }
}