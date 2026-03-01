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
        AtXP = long.Parse(strAtXP);
        Title = title;
        Description = description;
        LanguageISO = languageISO;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        formData.Add("xp", AtXP.ToString());
        return formData;
    }
}
public sealed class UpdateXPRankOptions : ModifyXPRankBase
{
    [UsedImplicitly]
    public Guid ID { get; private set; }

    [UsedImplicitly]
    public long? AtXP { get; set; }

    public UpdateXPRankOptions(Guid rankID)
    {
        ID = rankID;
    }
    public UpdateXPRankOptions(string strRankID)
    {
        ID = Guid.Parse(strRankID);
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        formData.Add("rankID", ID.ToString());
        if(AtXP.HasValue) formData.Add("xp", AtXP.Value.ToString());
        return formData;
    }
}
public sealed class DeleteXPRankOptions
{
    [UsedImplicitly]
    public Guid RankID { get; private set; }
    
    public DeleteXPRankOptions(string strRankID)
    {
        RankID = Guid.Parse(strRankID);
    }
    public DeleteXPRankOptions(Guid rankID)
    {
        RankID = rankID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "rankID", RankID.ToString() }
        };
        return formData;
    }
}