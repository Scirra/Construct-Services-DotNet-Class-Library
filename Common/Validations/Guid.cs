namespace ConstructServices.Common.Validations;
internal static class Guid
{
    internal static ValidationObjectResponse<System.Guid> IsValidGuid(this string strValue)
    {
        if (!System.Guid.TryParse(strValue, out var guid) || guid == System.Guid.Empty)
        {
            return new InvalidObjectResponse<System.Guid>("{0} is not a valid Guid.");
        }
        return new ValidObjectResponse<System.Guid>(guid);
    }
}