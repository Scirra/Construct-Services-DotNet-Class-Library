namespace ConstructServices.Common.Validations;

internal static class PlayerName
{
    internal static ValidationResponse ValidatePlayerName(this string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return new InvalidResponse("Player name cannot be empty string.");
        }
        return new ValidResponse();
    }
}