using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ConstructServices.CloudSave.Objects;

public abstract class ModifyCloudSaveBase
{        
    [UsedImplicitly]
    public Guid? BucketID { get; set; }

    [UsedImplicitly]
    public string SessionKey { get; set; }

    [UsedImplicitly]
    public string Name { get; set; }

    [UsedImplicitly]
    public string Key { get; set; }

    protected Dictionary<string, string> BuildBaseFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "name", Name },
            { "key", Key }
        };
        if (BucketID.HasValue)
        {
            formData.Add("bucketID", BucketID.Value.ToString());
        }
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class CreateCloudSaveOptions : ModifyCloudSaveBase
{
    private ByteArrayContent Data { get; }
    private PictureData Picture { get; }
    
    /// <summary>
    /// Create a save in an existing bucket with no player association
    /// </summary>
    public CreateCloudSaveOptions(
        Guid bucketID,
        byte[] data,
        string name,
        string key,
        PictureData picture = null)
    {
        BucketID = bucketID;
        Data = new ByteArrayContent(data);
        Name = name;
        Key = key;
        Picture = picture;
    }    

    /// <summary>
    /// Create a player save in an existing bucket
    /// </summary>
    public CreateCloudSaveOptions(
        string sessionKey,
        Guid bucketID,
        byte[] data,
        string name,
        string key,
        PictureData picture = null)
    {
        SessionKey = sessionKey;
        BucketID = bucketID;
        Data = new ByteArrayContent(data);
        Name = name;
        Key = key;
        Picture = picture;
    }    

    /// <summary>
    /// Create a player save in an existing bucket
    /// </summary>
    public CreateCloudSaveOptions(
        string sessionKey,
        string strBucketID,
        byte[] data,
        string name,
        string key,
        PictureData picture = null)
    {
        SessionKey = sessionKey;
        BucketID = Guid.Parse(strBucketID);
        Data = new ByteArrayContent(data);
        Name = name;
        Key = key;
        Picture = picture;
    }

    /// <summary>
    /// Create a private save in a players account
    /// </summary>
    public CreateCloudSaveOptions(
        string sessionKey,
        byte[] data,
        string name,
        string key,
        PictureData picture = null)
    {
        SessionKey = sessionKey;
        Data = new ByteArrayContent(data);
        Name = name;
        Key = key;
        Picture = picture;
    }    

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        if (Picture != null)
        {
            if (!string.IsNullOrWhiteSpace(Picture.Base64))
            {
                formData.Add("picture", Picture.Base64);
            }
            else if (Picture.URL != null)
            {
                formData.Add("pictureURL", Picture.URL.ToString());
            }
        }
        return formData;
    }

    internal Dictionary<string, ByteArrayContent> BuildBinaryFormData()
    {
        var postedBinaryData = new Dictionary<string, ByteArrayContent>
        {
            { "data", Data }
        };
        if (Picture?.Bytes != null)
        {
            postedBinaryData.Add("pictureData", new ByteArrayContent(Picture.Bytes));
        }
        return postedBinaryData;
    }
}