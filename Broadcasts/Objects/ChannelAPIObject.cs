using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using ConstructServices.Common;

namespace ConstructServices.Broadcasts.Objects;

public abstract class ModifyChannelBase
{        
    [UsedImplicitly]
    public string Name { get; set; }

    [UsedImplicitly]
    public string Description { get; set; }

    [UsedImplicitly]
    public string LanguageISO { get; set; }
    
    protected Dictionary<string, string> BuildBaseFormData() => new()
    {
        { "name", Name },
        { "description", Description },
        { "language", LanguageISO }
    };
}
public sealed class CreateChannelOptions : ModifyChannelBase
{
    [UsedImplicitly]
    public bool AllowRatings { get; private set; }

    public CreateChannelOptions(
        string name,
        string description,
        bool allowRatings,
        string languageISO = null)
    {
        Name = name;
        Description = description;
        AllowRatings = allowRatings;
        LanguageISO = languageISO;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        formData.Add("allowRatings", AllowRatings.ToInt().ToString());
        return formData;
    }
}
public sealed class UpdateChannelOptions : ModifyChannelBase
{
    [UsedImplicitly]
    public Guid ID { get; private set; }

    [UsedImplicitly]
    public bool? AllowRatings { get; set; }
    
    public UpdateChannelOptions(Guid channelID)
    {
        ID = channelID;
    }
    public UpdateChannelOptions(string strChannelID)
    {
        ID = Guid.Parse(strChannelID);
    }

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        formData.Add("channelID", ID.ToString());
        if(AllowRatings.HasValue) formData.Add("allowRatings", AllowRatings.Value.ToInt().ToString());
        return formData;
    }
}
public sealed class DeleteChannelOptions
{
    [UsedImplicitly]
    public Guid ChannelID { get; private set; }
    
    public DeleteChannelOptions(string strChannelID)
    {
        ChannelID = Guid.Parse(strChannelID);
    }
    public DeleteChannelOptions(Guid channelID)
    {
        ChannelID = channelID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "channelID", ChannelID.ToString() }
        };
        return formData;
    }
}
public sealed class GetChannelOptions
{
    [UsedImplicitly]
    public Guid ChannelID { get; private set; }

    public GetChannelOptions(string strChannelID)
    {
        ChannelID = Guid.Parse(strChannelID);
    }
    public GetChannelOptions(Guid channelID)
    {
        ChannelID = channelID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "channelID", ChannelID.ToString() }
        };
        return formData;
    }
}