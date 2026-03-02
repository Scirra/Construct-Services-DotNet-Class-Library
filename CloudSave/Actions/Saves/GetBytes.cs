using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Saves
{
    extension(CloudSaveService service)
    {        
        /// <summary>
        /// Get an existing Cloud Saves data
        /// </summary>
        [UsedImplicitly] 
        public byte[] GetCloudSaveBytes(Objects.CloudSave forCloudSave)
        {
            return Request.DownloadBytes(
                new Uri(forCloudSave.DownloadURL),
                service
            ).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get an existing Cloud Saves data
        /// </summary>
        [UsedImplicitly] 
        public async Task<byte[]> GetCloudSaveBytesAsync(Objects.CloudSave forCloudSave)
        {
            return await Request.DownloadBytes(
                new Uri(forCloudSave.DownloadURL),
                service
            );
        }
    }
}
