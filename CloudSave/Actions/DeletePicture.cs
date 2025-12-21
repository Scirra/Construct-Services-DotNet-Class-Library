using ConstructServices.Common;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

[UsedImplicitly]
public static partial class CloudSaves
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete a picture associated with a cloud save
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeletePicture(string sessionKey,
            Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(sessionKey))
            {
                formData.Add("sessionKey", sessionKey);
            }

            const string path = "/deletepicture.json";
            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
                service,
                formData
            );
        }

        /// <summary>
        /// Delete a picture associated with a cloud save
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeletePicture(Guid cloudSaveID)
            =>
                service.DeletePicture(null, cloudSaveID);
    }
}