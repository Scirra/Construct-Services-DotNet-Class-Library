namespace ConstructServices.Common
{
    public class ObjectReturnMethodResult<T> : GenericMethodResult
    {
        public T ReturnedObject { get; set; }

        public ObjectReturnMethodResult(string errorMessage, bool success) : base(success, errorMessage)
        {
        }
        public ObjectReturnMethodResult(string errorMessage) : base(false, errorMessage)
        {
        }

        // Required if T is string
        public ObjectReturnMethodResult(bool success, T obj) : base(success)
        {
            ReturnedObject = obj;
        }
        public ObjectReturnMethodResult(T obj) : base(true)
        {
            ReturnedObject = obj;
        }
    }
}
