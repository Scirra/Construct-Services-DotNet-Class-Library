using System;
using System.Collections.Generic;
using System.Net.Http;
using JetBrains.Annotations;

namespace ConstructServices.Common;

[UsedImplicitly]
public sealed class PictureData
{
    internal string Base64 { get; private set; }
    internal Uri URL { get; private set; }
    internal byte[] Bytes { get; private set; }

    public PictureData(string base64Data)
    {
        Base64 = base64Data;
    }
    public PictureData(Uri pictureURL)
    {
        URL = pictureURL;
    }
    public PictureData(byte[] pictureFile)
    {
        Bytes = pictureFile;
    }

    internal static Dictionary<string, ByteArrayContent> BuildBinaryFormData(PictureData Picture)
    {
        var postedBinaryData = new Dictionary<string, ByteArrayContent>();
        if (Picture?.Bytes != null)
        {
            postedBinaryData.Add("pictureData", new ByteArrayContent(Picture.Bytes));
        }
        return postedBinaryData;
    }
    internal static Dictionary<string, string> BuildBaseFormData(PictureData picture)
    {
        var formData = new Dictionary<string, string>();
        if (picture.URL != null)
        {
            formData.Add("avatarURL", picture.URL.ToString());
        }
        else if (!string.IsNullOrWhiteSpace(picture.Base64))
        {
            formData.Add("avatar", picture.Base64);
        }
        return formData;
    }
}