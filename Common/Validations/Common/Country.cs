using System;
using System.Linq;
using ConstructServices.Common.Countries;

namespace ConstructServices.Common.Validations.Common;
internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsCountryISOAlpha2Valid(string iso)
    {
        iso = (iso ?? string.Empty).Trim();
        if (string.IsNullOrWhiteSpace(iso))
        {
            return new Responses.FailedValidation("Country ISO is null or empty.");
        }

        if (iso.Length != 2)
        {
            return new Responses.FailedValidation("Country ISO must be 2 characters long.");
        }

        var valid = Extensions.ToList<Countries.Country>().Any(c =>
            c.GetAttribute<CountryAttribute>().ISOAlpha2.Equals(iso, StringComparison.CurrentCultureIgnoreCase));
        if (!valid)
        {
            return new Responses.FailedValidation("Country ISO doesn't exist.");
        }

        return new Responses.SuccessfullValidation();
    }
}