using System;
using System.Linq;

namespace ConstructServices.Common.Validations;

internal static class Languages
{
    internal static bool IsValidTargetLanguage(string iso)
    {
        if (string.IsNullOrWhiteSpace(iso)) return false;
        return ((TargetLanguage[])Enum.GetValues(typeof(TargetLanguage))).ToList().Any(c =>
            c.GetAttribute<LanguageAttribute>().ISO.Equals(iso, StringComparison.CurrentCultureIgnoreCase));
    }
}