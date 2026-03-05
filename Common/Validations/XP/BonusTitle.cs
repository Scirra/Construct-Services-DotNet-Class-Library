namespace ConstructServices.Common.Validations.XP;

internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsBonusTitleValid(string title)
    {
        const int Max = 128;

        var length = (title ?? string.Empty).Trim().Length;
        if (length > Max)
        {
            return new Responses.FailedValidation($"Title cannot exceed {Max} characters in length.");
        }

        return new Responses.SuccessfullValidation();
    }
}