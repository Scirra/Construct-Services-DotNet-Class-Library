namespace ConstructServices.Common.Validations;

internal static class TeamName
{
    internal static ValidationResponse ValidateTeamName(this string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return new InvalidResponse("Team name cannot be empty string.");
        }
        return new ValidResponse();
    }
}