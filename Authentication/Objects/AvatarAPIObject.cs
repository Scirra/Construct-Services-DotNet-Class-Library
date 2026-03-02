using System;
using System.Collections.Generic;
using System.Net.Http;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Objects;

public sealed class DeleteAvatarOptions
{    
    [UsedImplicitly]
    public Guid? PlayerID { get; private set; }

    [UsedImplicitly]
    public string SessionKey { get; private set; }
        
    public DeleteAvatarOptions(Guid playerID)
    {
        PlayerID = playerID;
    }
    public DeleteAvatarOptions(string sessionKey)
    {
        SessionKey = sessionKey;
    }

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}
public sealed class SetAvatarOptions
{    
    [UsedImplicitly]
    public Guid? PlayerID { get; private set; }
        
    [UsedImplicitly]
    public string SessionKey { get; private set; }

    [UsedImplicitly]
    public PictureData Picture { get; private set; }
        
    public SetAvatarOptions(Guid playerID, PictureData picture)
    {
        PlayerID = playerID;
        Picture = picture;
    }
    public SetAvatarOptions(string sessionKey, PictureData picture)
    {
        SessionKey = sessionKey;
        Picture = picture;
    }
    internal Dictionary<string, ByteArrayContent> BuildBinaryFormData()
    {
        var postedBinaryData = new Dictionary<string, ByteArrayContent>();
        if (Picture?.Bytes != null)
        {
            postedBinaryData.Add("pictureData", new ByteArrayContent(Picture.Bytes));
        }
        return postedBinaryData;
    }

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        if (Picture.URL != null)
        {
            formData.Add("avatarURL", Picture.URL.ToString());
        }
        else if (!string.IsNullOrWhiteSpace(Picture.Base64))
        {
            formData.Add("avatar", Picture.Base64);
        }
        return formData;
    }
}