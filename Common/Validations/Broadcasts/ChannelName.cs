namespace ConstructServices.Common.Validations.Broadcasts;
internal static partial class Functions
{    
    internal static Responses.ValidationResponseBase IsChannelNameValid(string name)
    {
        const int MinLength = 1;
        const int MaxLength = 64;
        
        var length = (name ?? string.Empty).Trim().Length;
        if (length is < MinLength or > MaxLength)
        {
            return new Responses.FailedValidation($"Channel name must be between {MinLength} and {MaxLength} characters in length.");
        }

        return new Responses.SuccessfullValidation();
    }
}
