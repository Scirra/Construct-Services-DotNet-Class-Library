using ConstructServices.Common;
using JetBrains.Annotations;
using System;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    extension(CloudSaveService service)
    {
        [UsedImplicitly] 
        public byte[] GetCloudSaveBytes(Objects.CloudSave forCloudSave)
        {
            return Request.DownloadBytes(
                new Uri(forCloudSave.DownloadURL),
                service
            ).GetAwaiter().GetResult();
        }
        
        [UsedImplicitly] 
        public byte[] GetCloudSaveBytes(string sessionKey, Objects.CloudSave forCloudSave)
        {
            return Request.DownloadBytes(
                new Uri(forCloudSave.DownloadURL),
                service,
                sessionKey
            ).GetAwaiter().GetResult();
        }
    }
}
