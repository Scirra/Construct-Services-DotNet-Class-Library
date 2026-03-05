using System;

namespace ConstructServices.Common;

internal static partial class Validations
{ 
    internal static bool IsValidGuid(this Guid guid)
        => guid != Guid.Empty;

    internal static readonly BaseResponse InvalidGuidResponse
        = new("Invalid Guid");
}