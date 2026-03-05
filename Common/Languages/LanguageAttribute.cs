namespace ConstructServices.Common.Languages;
internal sealed class LanguageAttribute(string iso) : System.Attribute
{    
    public string ISO { get; } = iso;
}