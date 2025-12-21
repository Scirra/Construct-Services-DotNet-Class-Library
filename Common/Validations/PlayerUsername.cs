namespace ConstructServices.Common.Validations;

internal static class PlayerUsername
{
    internal static ValidationResponse ValidatePlayerUsername(this string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            return new InvalidResponse("Username cannot be empty string.");
        }
        return new ValidResponse();
    }
}