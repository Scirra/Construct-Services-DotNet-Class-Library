namespace ConstructServices.Common.Validations.XP;

internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsRankDescriptionValid(string description)
    {
        const int Max = 1024;

        description = (description ?? string.Empty).Trim();

        var length = description.Length;
        if (length > Max)
        {
            return new Responses.FailedValidation($"Description cannot exceed {Max} characters in length.");
        }

        return new Responses.SuccessfullValidation();
    }
}