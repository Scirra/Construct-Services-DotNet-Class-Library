using System;

namespace ConstructServices.Common.Validations;

internal static class PlayerPassword
{
    internal static ValidationResponse ValidatePlayerPassword(this string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return new InvalidResponse("{0} cannot be empty string.");
        }
        return new ValidResponse();
    }
    internal static ValidationResponse ValidateChangePassword(string currentPassword, string newPassword)
    {
        var currentPasswordValidator = currentPassword.ValidatePlayerPassword();
        if (!currentPasswordValidator.Successfull)
        {
            return new InvalidResponse(string.Format(currentPasswordValidator.ErrorMessage, "Current password"));
        }
        var newPasswordValidator = newPassword.ValidatePlayerPassword();
        if (!newPasswordValidator.Successfull)
        {
            return new InvalidResponse(string.Format(newPasswordValidator.ErrorMessage, "New password"));
        }
        if (currentPassword.Equals(newPassword, StringComparison.CurrentCulture))
        {
            return new InvalidResponse("New password must be different from current password.");
        }
        return new ValidResponse();
    }
}