using System;

namespace ConstructServices.Common.Validations.Common;
internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsPictureValid(this PictureData picture)
    {
        var count = 0;
        if (!string.IsNullOrWhiteSpace(picture.Base64)) count++;
        if (picture.URL != null 
            && (picture.URL.Scheme.Equals("http", StringComparison.CurrentCultureIgnoreCase) 
                || picture.URL.Scheme.Equals("https", StringComparison.CurrentCultureIgnoreCase))) count++;
        if (picture.Bytes is { Length: > 0 }) count++;

        return count switch
        {
            0 => new Responses.FailedValidation("Must specify a picture in this request."),
            > 1 => new Responses.FailedValidation("Must specify only one picture in this request."),
            _ => new Responses.SuccessfullValidation()
        };
    }
}