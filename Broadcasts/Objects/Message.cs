using Newtonsoft.Json;
using System;
using ConstructServices.Common;
using ConstructServices.Ratings.Objects;

namespace ConstructServices.Broadcasts.Objects;

public sealed class Message
{
    [JsonProperty(PropertyName = "id")]
    public Guid ID { get; private set; }

    [JsonProperty(PropertyName = "channelID")]
    public Guid ChannelID { get; private set; }

    [JsonProperty(PropertyName = "date")]
    public DateTime Date { get; private set; }

    [JsonProperty(PropertyName = "formattedDate")]
    public string FormattedDate { get; private set; }

    [JsonProperty(PropertyName = "title")]
    public string Title { get; private set; }

    [JsonProperty(PropertyName = "text")]
    public string Text { get; private set; }

    [JsonProperty(PropertyName = "textLength")]
    public int TextLength { get; private set; }
    
    [JsonProperty(PropertyName = "formattedTextLength")]
    public string FormattedTextLength { get; private set; }

    [JsonProperty(PropertyName = "excerpt")]
    public string Excerpt { get; private set; }

    [JsonProperty(PropertyName = "reads")]
    public int Reads { get; private set; }

    [JsonProperty(PropertyName = "formattedReads")]
    public string FormattedReads { get; private set; }

    [JsonProperty(PropertyName = "ratingStatus")]
    public RatingStatus RatingStatus { get; private set; }

    [JsonProperty(PropertyName = "uniqueReads")]
    public int UniqueReads { get; private set; }

    [JsonProperty(PropertyName = "formattedUniqueReads")]
    public string FormattedUniqueReads { get; private set; }

    [JsonProperty(PropertyName = "updates")]
    public int Updates { get; private set; }

    [JsonProperty(PropertyName = "formattedUpdates")]
    public string FormattedUpdates { get; private set; }

    [JsonProperty(PropertyName = "lastUpdate")]
    public DateTime? LastUpdate { get; private set; }

    [JsonProperty(PropertyName = "formattedLastUpdate")]
    public string FormattedLastUpdate { get; private set; }

    [JsonProperty(PropertyName = "isUnread")]
    public bool IsUnread { get; private set; }

    [JsonProperty(PropertyName = "originalLanguage")]
    public Language OriginalLanguage { get; private set; }
    
    [JsonProperty(PropertyName = "responseLanguage")]
    public Language ResponseLanguage { get; private set; }

    public Message()
    {
    }
}
