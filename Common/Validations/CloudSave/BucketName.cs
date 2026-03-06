namespace ConstructServices.Common.Validations.CloudSave;
internal static partial class Functions
{    
    internal static Responses.ValidationResponseBase IsBucketNameValid(string name)
    {
        const int MaxLength = 50;

        name = (name ?? string.Empty).Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            return new Responses.FailedValidation("Bucket name cannot be empty.");
        }

        var length = name.Length;
        if (length > MaxLength)
        {
            return new Responses.FailedValidation($"Bucket name cannot exceed {MaxLength} characters in length.");
        }

        return new Responses.SuccessfullValidation();
    }
}