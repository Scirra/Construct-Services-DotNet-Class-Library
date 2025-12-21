namespace ConstructServices.Common.Validations;

internal static class ForceLinkCode
{
    internal static ValidationResponse ValidateForceLinkCode(this string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            return new InvalidResponse("Force link code cannot be empty string.");
        }
        return new ValidResponse();
    }
}