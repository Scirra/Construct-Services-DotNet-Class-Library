namespace ConstructServices.Common.Validations.XP;

internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsRankTitleValid(string title)
    {
        const int Max = 128;

        title = (title ?? string.Empty).Trim();

        var length = title.Length;
        if (length > Max)
        {
            return new Responses.FailedValidation($"Title cannot exceed {Max} characters in length.");
        }

        return new Responses.SuccessfullValidation();
    }
}