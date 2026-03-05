using JetBrains.Annotations;

namespace ConstructServices.Common.Languages;

[UsedImplicitly]
public static class Functions
{
    public static string ISO(this TargetLanguage targetLanguage)
        => targetLanguage.GetAttribute<LanguageAttribute>().ISO;
    public static string ISO(this SourceLanguage sourceLanguage)
        => sourceLanguage.GetAttribute<LanguageAttribute>().ISO;
}