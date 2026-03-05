namespace ConstructServices.Common.Validations.Authentication;
internal static partial class Functions
{
    internal static Responses.ValidationResponseBase IsEmailAddressValid(string emailAddress)
    {
        const int MinEmailLength = 4;
        const int MaxEmailLength = 128;

        var length = (emailAddress ?? string.Empty).Trim().Length;
        if (length is < MinEmailLength or > MaxEmailLength)
        {
            return new Responses.FailedValidation($"Email address should be between {MinEmailLength} and {MaxEmailLength} characters in length.");
        }
        if (!IsValidEmailForm(emailAddress))
        {
            return new Responses.FailedValidation("Email address appears to be invalid.");
        }
        
        return new Responses.SuccessfullValidation();
    }

    private static bool IsValidEmailForm(string emailAddress)
    {
        try
        {
            _ = new System.Net.Mail.MailAddress(emailAddress);
        }
        catch
        {
            return false;
        }
        return true;
    }
}
