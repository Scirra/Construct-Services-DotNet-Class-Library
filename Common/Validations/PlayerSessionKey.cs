namespace ConstructServices.Common.Validations;

internal static class PlayerSessionKey
{
    internal static ValidationResponse ValidatePlayerSessionKey(this string sessionKey)
    {
        if (string.IsNullOrWhiteSpace(sessionKey))
        {
            return new InvalidResponse("Session key cannot be empty string.");
        }
        return new ValidResponse();
    }
}