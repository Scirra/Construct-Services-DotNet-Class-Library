namespace ConstructServices.Common.Validations.Common;

internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsDataValid(byte[] data)
    {
        if (data == null || data.Length == 0)
        {
            return new Responses.FailedValidation("Provided data is null or empty.");
        }

        return new Responses.SuccessfullValidation();
    }
}