using System;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace ConstructServices.Broadcasts.Objects;
public abstract class ModifyMessageBase
{        
    [UsedImplicitly]
    public string Title { get; set; }

    [UsedImplicitly]
    public string Text { get; set; }

    [UsedImplicitly]
    public string LanguageISO { get; set; }
    
    protected Dictionary<string, string> BuildBaseFormData() => new()
    {
        { "title", Title },
        { "text", Text },
        { "language", LanguageISO },
    };
}
public sealed class CreateMessageOptions : ModifyMessageBase
{
    [UsedImplicitly]
    public Guid ChannelID { get; private set; }
    
    public CreateMessageOptions(
        Guid channelID,
        string title,
        string text,
        string languageISO = null)
    {
        ChannelID = channelID;
        Title = title;
        Text = text;
        LanguageISO = languageISO;
    }
    public CreateMessageOptions(
        string strChannelID,
        string title,
        string text,
        string languageISO = null)
    {
        ChannelID = Guid.Parse(strChannelID);
        Title = title;
        Text = text;
        LanguageISO = languageISO;
    }
    public CreateMessageOptions(
        Channel channel,
        string title,
        string text,
        string languageISO = null)
    {
        ChannelID = channel.ID;
        Title = title;
        Text = text;
        LanguageISO = languageISO;
    }

    [UsedImplicitly]
    public Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        formData.Add("channelID", ChannelID.ToString());
        return formData;
    }
}
public sealed class UpdateMessageOptions : ModifyMessageBase
{
    [UsedImplicitly]
    public Guid MessageID { get; private set; }
    
    public UpdateMessageOptions(Guid messageID)
    {
        MessageID = messageID;
    }
    public UpdateMessageOptions(string strMessageID)
    {
        MessageID = Guid.Parse(strMessageID);
    }

    [UsedImplicitly]
    public Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        formData.Add("messageID", MessageID.ToString());
        return formData;
    }
}
public sealed class DeleteMessageOptions
{
    [UsedImplicitly]
    public Guid MessageID { get; private set; }
    
    public DeleteMessageOptions(string strMessageID)
    {
        MessageID = Guid.Parse(strMessageID);
    }
    public DeleteMessageOptions(Guid messageID)
    {
        MessageID = messageID;
    }

    [UsedImplicitly]
    public Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "messageID", MessageID.ToString() }
        };
        return formData;
    }
}
public sealed class GetMessageOptions
{
    [UsedImplicitly]
    public Guid MessageID { get; private set; }
    
    public GetMessageOptions(string strMessageID)
    {
        MessageID = Guid.Parse(strMessageID);
    }
    public GetMessageOptions(Guid messageID)
    {
        MessageID = messageID;
    }

    [UsedImplicitly]
    public Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "messageID", MessageID.ToString() }
        };
        return formData;
    }
}