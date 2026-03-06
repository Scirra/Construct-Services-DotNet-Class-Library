namespace ConstructServices.Common.Countries;

public static class Functions
{
    public static string ISOAlpha2(this Country country)
        => country.GetAttribute<CountryAttribute>().ISOAlpha2;
}