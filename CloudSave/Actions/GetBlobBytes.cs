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
            return Request.DownloadBytes(
                new Uri(forCloudSave.DownloadURL),
                service
            ).GetAwaiter().GetResult();
        }

        [UsedImplicitly] 
        public async Task<byte[]> GetCloudSaveBytesAsync(Objects.CloudSave forCloudSave)
        {
            return await Request.DownloadBytes(
                new Uri(forCloudSave.DownloadURL),
                service
            );
        }
        
        [UsedImplicitly] 
        public byte[] GetCloudSaveBytes(string sessionKey, Objects.CloudSave forCloudSave)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                throw new Exception(sessionKeyValidator.ErrorMessage);
            }

            return Request.DownloadBytes(
                new Uri(forCloudSave.DownloadURL),
                service,
                sessionKey
            ).GetAwaiter().GetResult();
        }
        
        [UsedImplicitly] 
        public async Task<byte[]> GetCloudSaveBytesAsync(string sessionKey, Objects.CloudSave forCloudSave)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                throw new Exception(sessionKeyValidator.ErrorMessage);
            }

            return await Request.DownloadBytes(
                new Uri(forCloudSave.DownloadURL),
                service,
                sessionKey
            );
        }
    }
}
