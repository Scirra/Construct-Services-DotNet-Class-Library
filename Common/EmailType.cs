using JetBrains.Annotations;

namespace ConstructServices.Common;

public enum EmailType : byte
{
    [UsedImplicitly]
    [EmailType("Verification", "Contains a link to verify ownership of email address")]
    VerificationEmail = 0,
    
    [UsedImplicitly]
    [EmailType("Sign In", "Contains a magic link to sign into your game")]
    SignInEmail = 1,
    
    [UsedImplicitly]
    [EmailType("Forgotten Password", "Contains a link for the user to create a new password")]
    ForgottenPassword = 2
}

[UsedImplicitly]
public class EmailTypeAttribute(string friendlyName, string description) : System.Attribute
{
    [UsedImplicitly]
    public string FriendlyName { get; } = friendlyName;

    [UsedImplicitly]
    public string Description { get; } = description;
}