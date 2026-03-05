namespace ConstructServices.Common.Validations;
internal static class Responses
{
    internal abstract class ValidationResponseBase
    {
        internal bool Valid { get; private set; }
        internal string ErrorMessage { get; private set; }
        internal ValidationResponseBase()
        {
            Valid = true;
        }
        internal ValidationResponseBase(string errorMessage)
        {
            Valid = false;
            ErrorMessage = errorMessage;
        }
    }
    internal sealed class SuccessfullValidation : ValidationResponseBase;
    internal sealed class FailedValidation(string errorMessage) : ValidationResponseBase(errorMessage);
}