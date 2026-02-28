using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.XP.Objects;

public abstract class ModifyXPRankBase
{        
    [UsedImplicitly]
    public string Title { get; set; }

    [UsedImplicitly]
    public string Description { get; set; }

    [UsedImplicitly]
    public string LanguageISO { get; set; }


    protected Dictionary<string, string> BuildBaseFormData() => new()
    {
        { "title", Title },
        { "description", Description },
        { "language", LanguageISO }
    };
}
public sealed class CreateXPRankOptions : ModifyXPRankBase
{
    [UsedImplicitly]
    public long AtXP { get; private set; }
    
    public CreateXPRankOptions(long atXP, string title, string description, string languageISO = null)
    {
        AtXP = atXP;
        Title = title;
        Description = description;
        LanguageISO = languageISO;
    }
    public CreateXPRankOptions(string strAtXP, string title, string description, string languageISO = null)
    {
        if (!long.TryParse(strAtXP, out var atXP)) throw new InvalidCastException();
        AtXP = atXP;
        Title = title;
        Description = description;
        LanguageISO = languageISO;
    }

    [UsedImplicitly]
    public Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        formData.Add("xp", AtXP.ToString());
        return formData;
    }
}
public sealed class UpdateXPRankOptions : ModifyXPRankBase
{
    [UsedImplicitly]
    public long? AtXP { get; set; }
    
    [UsedImplicitly]
    public Dictionary<string, string> BuildFormData(Guid rankID)
    {
        var formData = BuildBaseFormData();
        formData.Add("rankID", rankID.ToString());
        if(AtXP.HasValue) formData.Add("xp", AtXP.ToString());
        return formData;
    }
}
public sealed class DeleteXPRankOptions
{
    [UsedImplicitly]
    public Guid RankID { get; private set; }
    
    public DeleteXPRankOptions(string strRankID)
    {
        if (!Guid.TryParse(strRankID, out var rankID)) throw new InvalidCastException();
        RankID = rankID;
    }
    public DeleteXPRankOptions(Guid rankID)
    {
        RankID = rankID;
    }

    [UsedImplicitly]
    public Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "rankID", RankID.ToString() }
        };
        return formData;
    }
}