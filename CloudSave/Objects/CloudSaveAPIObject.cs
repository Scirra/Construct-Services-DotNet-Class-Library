using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ConstructServices.CloudSave.Objects;

public abstract class ModifyCloudSaveBase
{        
    [UsedImplicitly]
    public Guid BucketID { get; set; }

    [UsedImplicitly]
    public string Name { get; set; }

    [UsedImplicitly]
    public string Key { get; set; }

    protected Dictionary<string, string> BuildBaseFormData() => new()
    {
        { "bucketID", BucketID.ToString() },
        { "name", Name },
        { "key", Key }
    };
}

[UsedImplicitly]
public sealed class CreateCloudSaveOptions : ModifyCloudSaveBase
{
    private ByteArrayContent Data { get; }
    private PictureData Picture { get; }

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