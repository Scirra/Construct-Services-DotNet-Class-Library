using JetBrains.Annotations;

namespace ConstructServices.Common;

public enum EmailType : byte
{
    [EmailType("Verification", "Contains a link to verify ownership of email address")]
    VerificationEmail = 0,

    [EmailType("Sign In", "Contains a magic link to sign into your game")]
    SignInEmail = 1
}

[UsedImplicitly]
public class EmailTypeAttribute(string friendlyName, string description) : System.Attribute
{
    public string FriendlyName { get; } = friendlyName;
    public string Description { get; } = description;
}