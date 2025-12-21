using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    extension(CloudSaveService service)
    {
        [UsedImplicitly] 
        public byte[] GetCloudSaveBytes(Objects.CloudSave forCloudSave)
        {
            return Task.Run(() => Request.DownloadBytes(
                new Uri(forCloudSave.DownloadURL),
                service
            )).Result;
        }
        
        [UsedImplicitly] 
        public byte[] GetCloudSaveBytes(string sessionKey, Objects.CloudSave forCloudSave)
        {
            return Task.Run(() => Request.DownloadBytes(
                new Uri(forCloudSave.DownloadURL),
                service,
                sessionKey
            )).Result;
        }
    }
}
