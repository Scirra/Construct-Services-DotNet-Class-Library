namespace ConstructServices.Common.Validations.CloudSave;
internal static partial class Functions
{    
    internal static Responses.ValidationResponseBase IsCloudSaveNameValid(string name)
    {
        const int MaxLength = 128;

        name = (name ?? string.Empty).Trim();

        var length = name.Length;
        if (length > MaxLength)
        {
            return new Responses.FailedValidation($"Cloud save name cannot exceed {MaxLength} characters in length.");
        }

        return new Responses.SuccessfullValidation();
    }
}