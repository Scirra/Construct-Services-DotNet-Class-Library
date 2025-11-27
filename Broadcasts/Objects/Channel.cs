using System;
using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.Ratings.Objects;
using Newtonsoft.Json;

namespace ConstructServices.Broadcasts.Objects;

public sealed class Channel
{
    [JsonProperty(PropertyName = "id")]
    public Guid ID { get; private set; }

    [JsonProperty(PropertyName = "name")]
    public string Name { get; private set; }

    [JsonProperty(PropertyName = "description")]
    public string Description { get; private set; }

    [JsonProperty(PropertyName = "created")]
    public DateTime Created { get; private set; }
    
    [JsonProperty(PropertyName = "formattedCreated")]
    public string FormattedCreated { get; private set; }

    [JsonProperty(PropertyName = "broadcasts")]
    public int Broadcasts { get; private set; }
    
    [JsonProperty(PropertyName = "formattedBroadcasts")]
    public string FormattedBroadcasts { get; private set; }

    [JsonProperty(PropertyName = "lastBroadcast")]
    public DateTime? LastBroadcast { get; private set; }
    
    [JsonProperty(PropertyName = "formattedLastBroadcast")]
    public string FormattedLastBroadcast { get; private set; }

    [JsonProperty(PropertyName = "allowRatings")]
    public bool AllowRatings { get; private set; }

    [JsonProperty(PropertyName = "anyUnreadMessages")]
    public bool AnyUnreadMessages { get; private set; }

    [JsonProperty(PropertyName = "dimensionlessMaxRatingValue")]
    public byte DimensionlessMaxRatingValue { get; private set; }

    [JsonProperty(PropertyName = "ratingDimensions")]
    public Dictionary<string, RatingDimension> RatingDimensions { get; private set; }

    [JsonProperty(PropertyName = "originalLanguage")]
    public Language OriginalLanguage { get; private set; }

    public Channel()
    {
    }
}