namespace ConstructServices.Common.Validations.XP;

internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsBonusDescriptionValid(string description)
    {
        const int Max = 1024;

        var length = (description ?? string.Empty).Trim().Length;
        if (length > Max)
        {
            return new Responses.FailedValidation($"Description cannot exceed {Max} characters in length.");
        }

        return new Responses.SuccessfullValidation();
    }
}