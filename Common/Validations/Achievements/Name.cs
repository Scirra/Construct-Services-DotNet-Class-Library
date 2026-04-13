namespace ConstructServices.Common.Validations.Achievements;

internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsAchievementNameValid(string name)
    {
        const int MinLength = 1;
        const int MaxLength = 128;
        
        var length = (name ?? string.Empty).Trim().Length;
        if (length is < MinLength or > MaxLength)
        {
            return new Responses.FailedValidation($"Achievement name must be between {MinLength} and {MaxLength} characters in length.");
        }

        return new Responses.SuccessfullValidation();
    }
}