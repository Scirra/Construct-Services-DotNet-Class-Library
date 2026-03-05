using System;
using System.Linq;
using ConstructServices.Common.Languages;

namespace ConstructServices.Common;
internal static partial class Validations
{
    internal static bool IsValidTargetLanguage(string iso)
    {
        if (string.IsNullOrWhiteSpace(iso)) return false;
        return Extensions.ToList<TargetLanguage>().Any(c =>
            c.GetAttribute<LanguageAttribute>().ISO.Equals(iso, StringComparison.CurrentCultureIgnoreCase));
    }

    internal static bool IsValidSourceLanguage(string iso)
    {
        if (string.IsNullOrWhiteSpace(iso)) return false;
        return Extensions.ToList<TargetLanguage>().Any(c =>
            c.GetAttribute<LanguageAttribute>().ISO.Equals(iso, StringComparison.CurrentCultureIgnoreCase));
    }
}