namespace ConstructServices.Common;

internal static partial class Validations
{
    internal static ValidationResponseBase IsUsernameValid(string username)
    {
        const int MinUsernameLength = 3;
        const int MaxUsernameLength = 32;
        
        var length = username.Trim().Length;
        if (length is < MinUsernameLength or > MaxUsernameLength)
        {
            return new FailedValidation(
                $"Username should be between {MinUsernameLength} and {MaxUsernameLength} characters long.");
        }

        return new SuccessfullValidation();
    }

    internal static ValidationResponseBase IsPasswordValid(string password)
    { 
        const int MinPasswordLength = 8;
        const int MaxPasswordLength = 32;
        
        var length = password.Trim().Length;
        if (length is < MinPasswordLength or > MaxPasswordLength)
        {
            return new FailedValidation(
                $"Password should be between {MinPasswordLength} and {MaxPasswordLength} characters long.");
        }

        return new SuccessfullValidation();
    }
}