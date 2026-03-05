using JetBrains.Annotations;

namespace ConstructServices.Common.Languages;

[UsedImplicitly]
public static class Functions
{
    [UsedImplicitly]
    public static string ISO(this TargetLanguage targetLanguage)
        => targetLanguage.GetAttribute<LanguageAttribute>().ISO;

    [UsedImplicitly]
    public static string ISO(this SourceLanguage sourceLanguage)
        => sourceLanguage.GetAttribute<LanguageAttribute>().ISO;
}