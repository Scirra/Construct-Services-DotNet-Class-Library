namespace ConstructServices.Common;

public abstract class BaseService
{
    internal string APIKey { get; private set; }

    protected BaseService(string aPIKey = null)
    {
        APIKey = aPIKey;
    }
}