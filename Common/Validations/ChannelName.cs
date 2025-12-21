namespace ConstructServices.Common.Validations;

internal static class ChannelName
{
    internal static ValidationResponse ValidateChannelName(this string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return new InvalidResponse("Channel name cannot be empty string.");
        }
        return new ValidResponse();
    }
}