using System;
using System.Linq;

namespace ConstructServices.Common.Validations.CloudSave;
internal static partial class Functions
{    
    internal static Responses.ValidationResponseBase IsCloudSaveKeyValid(string key)
    {
        const int MaxLength = 256;

        key = (key ?? string.Empty).Trim();

        if (string.IsNullOrWhiteSpace(key))
        {
            return new Responses.FailedValidation("Cloud save key is mandatory.");
        }

        var length = key.Length;
        if (length > MaxLength)
        {
            return new Responses.FailedValidation($"Cloud save key cannot exceed {MaxLength} characters in length.");
        }
        
        if (key.IndexOf("..", StringComparison.CurrentCultureIgnoreCase) != -1)
        {
            return new Responses.FailedValidation("Cloud save key cannot contain multiple consecutive dots.");
        }
        if (key.StartsWith(".", StringComparison.Ordinal) || key.EndsWith(".", StringComparison.Ordinal))
        {
            return new Responses.FailedValidation("Cloud save key cannot start or end with a dot.");
        }
        if (!key.All(c => c.IsAlphaNumeric() || c.Equals('.')))
        {
            return new Responses.FailedValidation("Cloud save key can only contain alphanumeric chars and dots.");
        }

        return new Responses.SuccessfullValidation();
    }
}