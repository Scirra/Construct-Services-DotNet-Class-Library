using System;

namespace ConstructServices.Common.Validations;

internal static class Guids
{ 
    internal static bool IsValidGuid(this Guid guid)
        => guid != Guid.Empty;
}