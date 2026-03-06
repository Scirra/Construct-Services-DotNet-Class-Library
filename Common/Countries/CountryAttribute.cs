namespace ConstructServices.Common.Countries;

internal sealed class CountryAttribute(string isoAlpha2) : System.Attribute
{    
    public string ISOAlpha2 { get; } = isoAlpha2;
}