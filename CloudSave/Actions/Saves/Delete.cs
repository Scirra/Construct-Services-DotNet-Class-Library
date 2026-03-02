using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

public static partial class Saves
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/delete-cloud-save" />
        [UsedImplicitly]
        public BaseResponse Delete(DeleteCloudSaveOptions deleteCloudSaveOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Saves.Delete,
                service,
                deleteCloudSaveOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Delete an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/delete-cloud-save" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteAsync(DeleteCloudSaveOptions deleteCloudSaveOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Saves.Delete,
                service,
                deleteCloudSaveOptions.BuildFormData()
            );
        }
    }

    
    [UsedImplicitly]
    public sealed class DeleteCloudSaveOptions
    {
        private Guid CloudSaveID { get; }
        private string SessionKey { get; }
    
        public DeleteCloudSaveOptions(Guid cloudSaveID)
        {
            CloudSaveID = cloudSaveID;
        }
        public DeleteCloudSaveOptions(string sessionKey, Guid cloudSaveID)
        {
            SessionKey = sessionKey;
            CloudSaveID = cloudSaveID;
        }
        public DeleteCloudSaveOptions(string sessionKey, string strCloudSaveID)
        {
            SessionKey = sessionKey;
            CloudSaveID = Guid.Parse(strCloudSaveID);
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", CloudSaveID.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }
            return formData;
        }
    }
}