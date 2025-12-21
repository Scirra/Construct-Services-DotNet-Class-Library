namespace ConstructServices.Common.Validations;

internal static class RatingDimensionID
{
    internal static ValidationResponse ValidateDimensionID(this string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return new InvalidResponse("Rating dimension ID cannot be empty string.");
        }
        return new ValidResponse();
    }
}