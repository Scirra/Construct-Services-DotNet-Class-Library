namespace ConstructServices.Common.Validations;

internal static class CloudSaveKey
{
    internal static ValidationResponse ValidateKey(this string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            return new InvalidResponse("Key cannot be empty string.");
        }
        return new ValidResponse();
    }
}