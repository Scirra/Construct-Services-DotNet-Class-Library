namespace ConstructServices.Common.Validations.Authentication;
internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsUsernameValid(string username)
    {
        const int MinUsernameLength = 3;
        const int MaxUsernameLength = 32;
        
        var length = (username ?? string.Empty).Trim().Length;
        if (length is < MinUsernameLength or > MaxUsernameLength)
        {
            return new Responses.FailedValidation(
                $"Username should be between {MinUsernameLength} and {MaxUsernameLength} characters long.");
        }

        return new Responses.SuccessfullValidation();
    }

    internal static Responses.ValidationResponseBase IsPasswordValid(string password)
    { 
        const int MinPasswordLength = 8;
        const int MaxPasswordLength = 32;
        
        var length = (password ?? string.Empty).Trim().Length;
        if (length is < MinPasswordLength or > MaxPasswordLength)
        {
            return new Responses.FailedValidation(
                $"Password should be between {MinPasswordLength} and {MaxPasswordLength} characters long.");
        }

        return new Responses.SuccessfullValidation();
    }
}