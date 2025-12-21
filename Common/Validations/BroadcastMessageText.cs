namespace ConstructServices.Common.Validations;

internal static class BroadcastMessageText
{
    internal static ValidationResponse ValidateTest(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return new InvalidResponse("Message text cannot be empty string.");
        }
        return new ValidResponse();
    }
}