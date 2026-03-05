using System;

namespace ConstructServices.Common;

internal static partial class Validations
{
    internal static bool HasOnePicture(this PictureData picture)
    {
        var count = 0;
        if (!string.IsNullOrWhiteSpace(picture.Base64)) count++;
        if (picture.URL != null 
            && (picture.URL.Scheme.Equals("http", StringComparison.CurrentCultureIgnoreCase) 
                || picture.URL.Scheme.Equals("https", StringComparison.CurrentCultureIgnoreCase))) count++;
        if (picture.Bytes is { Length: > 0 }) count++;
        return count == 1;
    }

    internal static readonly BaseResponse NoPictureResponse
        = new("Image URL, base 64 or binary data needs to be passed.");
}