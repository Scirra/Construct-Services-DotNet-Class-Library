using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete a cloud save
        /// </summary>
        [UsedImplicitly]
        public BaseResponse Delete(Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() }
            };

            const string path = "/delete.json";
            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
                service,
                formData
            );
        }

        /// <summary>
        /// Delete a cloud save
        /// </summary>
        [UsedImplicitly]
        public BaseResponse Delete(string sessionKey,
            Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "blobID", cloudSaveID.ToString() }
            };

            const string path = "/delete.json";
            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
                service,
                formData
            );
        }
    }
}