using ConstructServices.Authentication.Objects;
using ConstructServices.Common.Countries;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;

namespace ConstructServices.Leaderboards.Objects;

public sealed class ShadowBan
{
    [JsonProperty(PropertyName = "dateBanned")]
    public DateTime Date { get; private set; }

    [JsonProperty(PropertyName = "ipHash")]
    public int IPHash { get; private set; }

    [JsonProperty(PropertyName = "country")]
    public string CountryISOAlpha2 { get; private set; }    
    
    [UsedImplicitly]
    public Country Country()
        => Functions.GetFromISOAlpha2(CountryISOAlpha2);

    [JsonProperty(PropertyName = "player")]
    public Player Player { get; private set; }

    public ShadowBan()
    {

    }
}