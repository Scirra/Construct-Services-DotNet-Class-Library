namespace ConstructServices.Common.Validations;

internal static class EmailAddress
{    
    internal static ValidationResponse ValidateEmailAddress(this string emailAddress)
    {
        try
        {
            _ = new System.Net.Mail.MailAddress(emailAddress);
        }
        catch
        {
            return new InvalidResponse("Email is in invalid format.");
        }
        return new ValidResponse();
    }
}