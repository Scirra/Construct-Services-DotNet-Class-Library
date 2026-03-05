using System;
using System.Linq;
using ConstructServices.Common.Languages;

namespace ConstructServices.Common.Validations.Common;
internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsTargetLanguageISOValid(string iso, bool optional = false)
    {
        if (string.IsNullOrWhiteSpace(iso))
        {
            if(optional) return new Responses.SuccessfullValidation();
            return new Responses.FailedValidation("No target language ISO specified.");
        }

        var valid = Extensions.ToList<TargetLanguage>().Any(c =>
            c.GetAttribute<LanguageAttribute>().ISO.Equals(iso, StringComparison.CurrentCultureIgnoreCase));
        if (valid)
        {
            return new Responses.SuccessfullValidation();
        }

        return new Responses.FailedValidation("Specified target language ISO is not supported or invalid.");
    }

    internal static Responses.ValidationResponseBase IsSourceLanguageISOValid(string iso, bool optional = false)
    {
        if (string.IsNullOrWhiteSpace(iso))
        {
            if(optional) return new Responses.SuccessfullValidation();
            return new Responses.FailedValidation("No target language ISO specified.");
        }

        var valid = Extensions.ToList<SourceLanguage>().Any(c =>
            c.GetAttribute<LanguageAttribute>().ISO.Equals(iso, StringComparison.CurrentCultureIgnoreCase));
        if (valid)
        {
            return new Responses.SuccessfullValidation();
        }

        return new Responses.FailedValidation("Specified target language ISO is not supported or invalid.");
    }
}