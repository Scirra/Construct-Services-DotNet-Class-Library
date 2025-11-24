using System;
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
}