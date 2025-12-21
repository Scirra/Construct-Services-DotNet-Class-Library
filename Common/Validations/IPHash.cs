namespace ConstructServices.Common.Validations;

internal static class IPHash
{
    internal static ValidationObjectResponse<int> ValidateIPHash(this string hash)
    {
        if (string.IsNullOrWhiteSpace(hash))
            return new InvalidObjectResponse<int>("No IP Hash was provided.");
        if (!int.TryParse(hash, out var ipHash))
            return new InvalidObjectResponse<int>("IP hash not a valid int.");
        return new ValidObjectResponse<int>(ipHash);
    }
}