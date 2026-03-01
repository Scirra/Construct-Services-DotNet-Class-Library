using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConstructServices.XP.Objects;

public abstract class ModifyXPBonusBase
{        
    [UsedImplicitly]
    public DateTime Start { get; set; }

    [UsedImplicitly]
    public DateTime End { get; set; }

    [UsedImplicitly]
    public string Title { get; set; }

    [UsedImplicitly]
    public string Description { get; set; }

    [UsedImplicitly]
    public string LanguageISO { get; set; }
    
    protected Dictionary<string, string> BuildBaseFormData() => new()
    {
        { "start", new DateTimeOffset(Start).ToUnixTimeSeconds().ToString() },
        { "end", new DateTimeOffset(End).ToUnixTimeSeconds().ToString() },
        { "title", Title },
        { "description", Description },
        { "language", LanguageISO }
    };
}
public sealed class CreateXPBonusOptions : ModifyXPBonusBase
{
    [UsedImplicitly]
    public decimal Modifier { get; private set; }
    public CreateXPBonusOptions(DateTime startDate, DateTime endDate, decimal modifier, string title, string description, string languageISO = null)
    {
        Start = startDate;
        End = endDate;
        Modifier = modifier;
        Title = title;
        Description = description;
        LanguageISO = languageISO;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        formData.Add("modifier", Modifier.ToString(CultureInfo.InvariantCulture));
        return formData;
    }
}
public sealed class UpdateXPBonusOptions : ModifyXPBonusBase
{
    [UsedImplicitly]
    public Guid ID { get; private set; }

    [UsedImplicitly]
    public decimal? Modifier { get; set; }
    
    public UpdateXPBonusOptions(Guid bonusID)
    {
        ID = bonusID;
    }
    public UpdateXPBonusOptions(string strBonusID)
    {
        ID = Guid.Parse(strBonusID);
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        formData.Add("bonusID", ID.ToString());
        if(Modifier.HasValue) formData.Add("modifier", Modifier.Value.ToString(CultureInfo.InvariantCulture));
        return formData;
    }
}
public sealed class DeleteXPBonusOptions
{
    [UsedImplicitly]
    public Guid BonusID { get; private set; }
    
    public DeleteXPBonusOptions(string strBonusID)
    {
        BonusID = Guid.Parse(strBonusID);
    }
    public DeleteXPBonusOptions(Guid bonusID)
    {
        BonusID = bonusID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "bonusID", BonusID.ToString() }
        };
        return formData;
    }
}
public sealed class GetBonusOptions
{
    [UsedImplicitly]
    private Guid BonusID { get; set; }
    public GetBonusOptions(string strBonusID)
    {
        BonusID = Guid.Parse(strBonusID);
    }
    public GetBonusOptions(Guid bonusID)
    {
        BonusID = bonusID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "bonusID", BonusID.ToString() }
        };
        return formData;
    }
}
public sealed class GetBonusesOptions(DateTime from, DateTime to)
{
    [UsedImplicitly]
    private DateTime Start { get; set; } = from;

    [UsedImplicitly]
    private DateTime End { get; set; } = to;

    public GetBonusesOptions(DateTime to) : this(DateTime.UtcNow, to)
    {
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "start", new DateTimeOffset(Start).ToUnixTimeSeconds().ToString() },
            { "end", new DateTimeOffset(End).ToUnixTimeSeconds().ToString() }
        };
        return formData;
    }
}