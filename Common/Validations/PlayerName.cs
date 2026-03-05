namespace ConstructServices.Common;

internal static partial class Validations
{    
    internal static ValidationResponseBase IsPlayerNameValid(string playerName)
    {
        const int MinPlayerNameLength = 1;
        const int MaxPlayerNameLength = 50;

        var length = playerName.Trim().Length;
        if (length is < MinPlayerNameLength or > MaxPlayerNameLength)
        {
            return new FailedValidation(
                $"Player name should be between {MinPlayerNameLength} and {MaxPlayerNameLength} characters long.");
        }

        if (IsValidEmailForm(playerName))
        {
            return new FailedValidation("Cannot use an email address as a player name.");
        }
        
        return new SuccessfullValidation();
    }
}