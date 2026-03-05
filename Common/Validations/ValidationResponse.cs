namespace ConstructServices.Common;
internal static partial class Validations
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
    internal class SuccessfullValidation : ValidationResponseBase;
    internal class FailedValidation(string errorMessage) : ValidationResponseBase(errorMessage);
}