namespace ConstructServices.Common.Validations.Broadcasts;
internal static partial class Functions
{    
    internal static Responses.ValidationResponseBase IsMessageTextValid(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return new Responses.FailedValidation("Message text cannot be empty.");
        }
        return new Responses.SuccessfullValidation();
    }
}