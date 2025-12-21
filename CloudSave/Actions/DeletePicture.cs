using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
                path,
                service,
                formData
            )).Result;
        }

        /// <summary>
        /// Delete a picture associated with a cloud save
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeletePicture(Guid cloudSaveID)
            => DeletePicture(service, null, cloudSaveID);
    }
}