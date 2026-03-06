using System;
using JetBrains.Annotations;
using System.Linq;

namespace ConstructServices.Common.Countries;

[UsedImplicitly]
public static class Functions
{
    [UsedImplicitly]
    public static string ISOAlpha2(this Country country)
        => country.GetAttribute<CountryAttribute>().ISOAlpha2;

    [UsedImplicitly]
    public static Country GetFromISOAlpha2(string isoAlpha2)
    {
        isoAlpha2 = (isoAlpha2 ?? string.Empty).Trim();
        return Extensions.ToList<Country>().SingleOrDefault(c =>
            c.GetAttribute<CountryAttribute>().ISOAlpha2.Equals(isoAlpha2, StringComparison.CurrentCultureIgnoreCase));
    }
}