using JetBrains.Annotations;

namespace ConstructServices.Common;

[UsedImplicitly]
public enum SourceLanguage
{
    [Language("AR")]
    Arabic,

    [Language("BG")]
    Bulgarian,

    [Language("CS")]
    Czech,

    [Language("DA")]
    Danish,

    [Language("DE")]
    German,

    [Language("EL")]
    Greek,

    [Language("EN")]
    English,

    [Language("ES")]
    Spanish,

    [Language("ET")]
    Estonian,

    [Language("FI")]
    Finnish,

    [Language("FR")]
    French,

    [Language("HE")]
    Hebrew,

    [Language("HU")]
    Hungarian,

    [Language("ID")]
    Indonesian,

    [Language("IT")]
    Italian,

    [Language("JA")]
    Japanese,

    [Language("KO")]
    Korean,

    [Language("LT")]
    Lithuanian,

    [Language("LV")]
    Latvian,

    [Language("NB")]
    NorwegianBokmål,

    [Language("NL")]
    Dutch,

    [Language("PL")]
    Polish,

    [Language("PT")]
    Portuguese,

    [Language("RO")]
    Romanian,

    [Language("RU")]
    Russian,

    [Language("SK")]
    Slovak,

    [Language("SL")]
    Slovenian,

    [Language("SV")]
    Swedish,

    [Language("TH")]
    Thai,

    [Language("TR")]
    Turkish,

    [Language("UK")]
    Ukrainian,

    [Language("VI")]
    Vietnamese,

    [Language("ZH")]
    Chinese
}

[UsedImplicitly]
public enum TargetLanguage
{
    [Language("AR")]
    Arabic,

    [Language("BG")]
    Bulgarian,

    [Language("CS")]
    Czech,

    [Language("DA")]
    Danish,

    [Language("DE")]
    German,

    [Language("EL")]
    Greek,

    [Language("EN-GB")]
    EnglishBritish,

    [Language("EN-US")]
    EnglishAmerican,

    [Language("ES")]
    Spanish,

    [Language("ES-419")]
    SpanishLatinAmerican,

    [Language("ET")]
    Estonian,

    [Language("FI")]
    Finnish,

    [Language("FR")]
    French,

    [Language("HE")]
    Hebrew,

    [Language("HU")]
    Hungarian,

    [Language("ID")]
    Indonesian,

    [Language("IT")]
    Italian,

    [Language("JA")]
    Japanese,

    [Language("KO")]
    Korean,

    [Language("LT")]
    Lithuanian,

    [Language("LV")]
    Latvian,

    [Language("NB")]
    NorwegianBokmål,

    [Language("NL")]
    Dutch,

    [Language("PL")]
    Polish,

    [Language("PT-BR")]
    PortugueseBrazilian,

    [Language("PT-PT")]
    Portuguese,

    [Language("RO")]
    Romanian,

    [Language("RU")]
    Russian,

    [Language("SK")]
    Slovak,

    [Language("SL")]
    Slovenian,

    [Language("SV")]
    Swedish,

    [Language("TH")]
    Thai,

    [Language("TR")]
    Turkish,

    [Language("UK")]
    Ukrainian,

    [Language("VI")]
    Vietnamese,

    [Language("ZH-HANS")]
    ChineseSimplified,

    [Language("ZH-HANT")]
    ChineseTraditional
}

internal sealed class LanguageAttribute(string iso) : System.Attribute
{    
    public string ISO { get; } = iso;
}