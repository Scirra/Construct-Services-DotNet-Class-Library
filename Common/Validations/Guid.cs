using System;

namespace ConstructServices.Common;

internal static partial class Validations
{ 
    internal static bool IsValidGuid(this Guid guid)
        => guid != Guid.Empty;
    
    internal const string InvalidGuidError = "Provided Guid appears to be invalid.";
}