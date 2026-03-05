using System;
using System.Collections.Generic;
using System.Net.Http;
using JetBrains.Annotations;

namespace ConstructServices.Common;

[UsedImplicitly]
public sealed class PictureData
{
    internal string Base64 { get; }
    internal Uri URL { get; }
    internal byte[] Bytes { get; }

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

    internal static Dictionary<string, ByteArrayContent> BuildBinaryFormData(PictureData Picture, string dataParamName)
    {
        var postedBinaryData = new Dictionary<string, ByteArrayContent>();
        if (Picture?.Bytes != null)
        {
            postedBinaryData.Add(dataParamName, new ByteArrayContent(Picture.Bytes));
        }
        return postedBinaryData;
    }
    internal static Dictionary<string, string> BuildBaseFormData(PictureData picture, string urlParamName, string base64ParamName)
    {
        var formData = new Dictionary<string, string>();
        if (picture.URL != null)
        {
            formData.Add(urlParamName, picture.URL.ToString());
        }
        else if (!string.IsNullOrWhiteSpace(picture.Base64))
        {
            formData.Add(base64ParamName, picture.Base64);
        }
        return formData;
    }
}