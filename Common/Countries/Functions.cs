using JetBrains.Annotations;

namespace ConstructServices.Common.Countries;

[UsedImplicitly]
public static class Functions
{
    [UsedImplicitly]
    public static string ISOAlpha2(this Country country)
        => country.GetAttribute<CountryAttribute>().ISOAlpha2;
}