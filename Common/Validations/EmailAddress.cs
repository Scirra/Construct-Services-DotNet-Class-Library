namespace ConstructServices.Common;

internal static partial class Validations
{
    internal static ValidationResponseBase IsEmailAddressValid(string emailAddress)
    {
        const int MinEmailLength = 4;
        const int MaxEmailLength = 128;

        var length = emailAddress.Trim().Length;
        if (length is < MinEmailLength or > MaxEmailLength)
        {
            return new FailedValidation($"Email address should be between {MinEmailLength} and {MaxEmailLength} characters in length.");
        }
        if (!IsValidEmailForm(emailAddress))
        {
            return new FailedValidation("Email address appears to be invalid.");
        }
        
        return new SuccessfullValidation();
    }

    internal static bool IsValidEmailForm(string emailAddress)
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
