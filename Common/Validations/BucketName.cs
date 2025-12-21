namespace ConstructServices.Common.Validations;

internal static class BucketName
{
    internal static ValidationResponse ValidateName(this string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return new InvalidResponse("Bucket name cannot be empty string.");
        }
        return new ValidResponse();
    }
}