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

        return new Responses.SuccessfullValidation();
    }
}