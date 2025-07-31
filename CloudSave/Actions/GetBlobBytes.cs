using System;
using System.Threading.Tasks;
using ConstructServices.Common;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    public static byte[] GetCloudSaveBytes(this CloudSaveService service, Objects.CloudSave forCloudSave)
    {
        return Task.Run(() => Request.DownloadBytes(
            new Uri(forCloudSave.DownloadURL),
            service
        )).Result;
    }
    public static byte[] GetCloudSaveBytes(this CloudSaveService service, string sessionKey, Objects.CloudSave forCloudSave)
    {
        return Task.Run(() => Request.DownloadBytes(
            new Uri(forCloudSave.DownloadURL),
            service,
            sessionKey
        )).Result;
    }
}
