namespace ConstructServices.Common
{
    internal abstract class ValidationObjectResponse<T>
    {
        internal bool Successfull { get; set; }
        internal string ErrorMessage { get; set; }
        internal T ReturnedObject { get; set; }
        
        protected ValidationObjectResponse(T returnedObject)
        {
            Successfull = true;
            ReturnedObject = returnedObject;
        } 
        protected ValidationObjectResponse(string errorMessage)
        {
            Successfull = false;
            ErrorMessage = errorMessage;
        }
    }
    internal sealed class ValidObjectResponse<T>(T returnedObject) : ValidationObjectResponse<T>(returnedObject);
    internal sealed class InvalidObjectResponse<T>(string errorMessage) : ValidationObjectResponse<T>(errorMessage);

    internal abstract class ValidationResponse
    {
        internal bool Successfull { get; }
        internal string ErrorMessage { get; }

        protected ValidationResponse()
        {
            Successfull = true;
        } 
        protected ValidationResponse(string errorMessage)
        {
            Successfull = false;
            ErrorMessage = errorMessage;
        }
    }
    internal sealed class ValidResponse() : ValidationResponse;
    internal sealed class InvalidResponse(string errorMessage) : ValidationResponse(errorMessage);
}
