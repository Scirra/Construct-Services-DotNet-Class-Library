namespace ConstructServices.Common.Validations.XP;

internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsBonusModifierValid(decimal modifier)
    {
        const decimal Min = (decimal)1.1;
        const decimal Max = 100;

        if (modifier is < Min or > Max)
        {
            return new Responses.FailedValidation($"Bonus modifier must be between {Min} and {Max}.");
        }

        return new Responses.SuccessfullValidation();
    }
}