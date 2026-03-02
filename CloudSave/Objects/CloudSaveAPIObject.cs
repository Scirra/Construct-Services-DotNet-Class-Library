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
    /// Create a save in an existing bucket with no player association
    /// </summary>
    public CreateCloudSaveOptions(
        Bucket bucket,
        byte[] data,
        string name,
        string key,
        PictureData picture = null)
    {
        BucketID = bucket.ID;
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
public sealed class DeleteCloudSaveOptions
{
    [UsedImplicitly]
    private Guid CloudSaveID { get; set; }

    [UsedImplicitly]
    private string SessionKey { get; set; }
    
    public DeleteCloudSaveOptions(Guid cloudSaveID)
    {
        CloudSaveID = cloudSaveID;
    }
    public DeleteCloudSaveOptions(string sessionKey, Guid cloudSaveID)
    {
        SessionKey = sessionKey;
        CloudSaveID = cloudSaveID;
    }
    public DeleteCloudSaveOptions(string sessionKey, string strCloudSaveID)
    {
        SessionKey = sessionKey;
        CloudSaveID = Guid.Parse(strCloudSaveID);
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "blobID", CloudSaveID.ToString() }
        };
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}
public sealed class DeleteCloudSavePictureOptions
{
    [UsedImplicitly]
    private Guid CloudSaveID { get; set; }

    [UsedImplicitly]
    private string SessionKey { get; set; }
    
    public DeleteCloudSavePictureOptions(Guid cloudSaveID)
    {
        CloudSaveID = cloudSaveID;
    }
    public DeleteCloudSavePictureOptions(string sessionKey, Guid cloudSaveID)
    {
        SessionKey = sessionKey;
        CloudSaveID = cloudSaveID;
    }
    public DeleteCloudSavePictureOptions(string sessionKey, string strCloudSaveID)
    {
        SessionKey = sessionKey;
        CloudSaveID = Guid.Parse(strCloudSaveID);
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "blobID", CloudSaveID.ToString() }
        };
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class SetCloudSavePictureOptions
{
    private Guid CloudSaveID { get; set; }
    internal PictureData Picture { get; set; }
    
    public SetCloudSavePictureOptions(Guid cloudSaveID, PictureData picture)
    {
        CloudSaveID = cloudSaveID;
        Picture = picture;
    }
    public SetCloudSavePictureOptions(string sessionKey, Guid cloudSaveID, PictureData picture)
    {
        CloudSaveID = cloudSaveID;
        Picture = picture;
    }
    public SetCloudSavePictureOptions(string sessionKey, string strCloudSaveID, PictureData picture)
    {
        CloudSaveID = Guid.Parse(strCloudSaveID);
        Picture = picture;
    }

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "blobID", CloudSaveID.ToString() }
        };            
        if (!string.IsNullOrWhiteSpace(Picture.Base64))
        {
            formData.Add("picture", Picture.Base64);
        }
        else if (Picture.URL != null)
        {
            formData.Add("pictureURL", Picture.URL.ToString());
        }
        return formData;
    }
    internal Dictionary<string, ByteArrayContent> BuildBinaryFormData()
    {
        var postedBinaryData = new Dictionary<string, ByteArrayContent>
        {
            { "pictureData", new ByteArrayContent(Picture.Bytes) }
        };
        return postedBinaryData;
    }
}
public sealed class GetCloudSaveByIDOptions
{
    [UsedImplicitly]
    private Guid CloudSaveID { get; set; }
    
    public GetCloudSaveByIDOptions(Guid cloudSaveID)
    {
        CloudSaveID = cloudSaveID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "blobID", CloudSaveID.ToString() }
        };
        return formData;
    }
}
public sealed class GetCloudSaveByKeyOptions
{
    [UsedImplicitly]
    private string Key { get; set; }

    [UsedImplicitly]
    private Guid BucketID { get; set; }
    
    public GetCloudSaveByKeyOptions(string key, Guid bucketID)
    {
        Key = key;
        BucketID = bucketID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "key", Key },
            { "bucketID", BucketID.ToString() }
        };
        return formData;
    }
}    

public sealed class ListPlayerCloudSaveFilters
{
    public string Name { get; [UsedImplicitly] set; }
    public string Key { get; [UsedImplicitly] set; }
}
public abstract class ListPlayerSaveOptions
{
    private bool ReturnPrivateSaves { get; }
    private Guid PlayerID { get; }
    private Enums.GetPlayerCloudSaveSortMethod? SortBy { get; }
    private ListPlayerCloudSaveFilters Filters { get; }

    protected ListPlayerSaveOptions(
        bool returnPrivateSaves,
        Guid playerID,
        Enums.GetPlayerCloudSaveSortMethod? sortBy = null,
        ListPlayerCloudSaveFilters filters = null)
    {
        ReturnPrivateSaves = returnPrivateSaves;
        PlayerID = playerID;
        SortBy = sortBy;
        Filters = filters;
    }

    [UsedImplicitly]
    protected Dictionary<string, string> BuildBaseFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "mode", "Player" },
            { "playerID", PlayerID.ToString() },
            { "bucketSaves", (!ReturnPrivateSaves).ToInt().ToString() }
        };
        if (SortBy.HasValue)
        {
            formData.Add("orderBy", SortBy.ToString());
        }
        if (Filters != null)
        {
            if (!string.IsNullOrWhiteSpace(Filters.Name))
            {
                formData.Add("name", Filters.Name);
            }

            if (!string.IsNullOrWhiteSpace(Filters.Key))
            {
                formData.Add("key", Filters.Key);
            }
        }
        return formData;
    }
}    
public sealed class ListPlayersPrivateSavesOptions : ListPlayerSaveOptions
{
    [UsedImplicitly]
    public ListPlayersPrivateSavesOptions(
        Guid playerID,
        Enums.GetPlayerCloudSaveSortMethod? sortBy = null,
        ListPlayerCloudSaveFilters filters = null) : base(true, playerID, sortBy, filters)
    {
    }

    [UsedImplicitly]
    public Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        return formData;
    }
}    
public sealed class ListPlayersSavesOptions : ListPlayerSaveOptions
{
    [UsedImplicitly]
    public ListPlayersSavesOptions(
        Guid playerID,
        Enums.GetPlayerCloudSaveSortMethod? sortBy = null,
        ListPlayerCloudSaveFilters filters = null) : base(false, playerID, sortBy, filters)
    {
    }

    [UsedImplicitly]
    public Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        return formData;
    }
}    