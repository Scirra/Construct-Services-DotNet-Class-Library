using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Saves
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Get an existing Cloud Save by its ID
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public CloudSaveResponse GetByID(GetCloudSaveByIDOptions getCloudSaveByIDOptions)
        {
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                getCloudSaveByIDOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get an existing Cloud Save by its ID
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByIDAsync(GetCloudSaveByIDOptions getCloudSaveByIDOptions)
        {
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                getCloudSaveByIDOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class GetCloudSaveByIDOptions(string sessionKey, Guid cloudSaveID)
    {
        private string SessionKey { get; } = sessionKey;
        private Guid CloudSaveID { get; } = cloudSaveID;
    
        public GetCloudSaveByIDOptions(Guid cloudSaveID) : this(null, cloudSaveID) { }
        public GetCloudSaveByIDOptions(string strCloudSaveID) : this(null, Guid.Parse(strCloudSaveID)) { }
        public GetCloudSaveByIDOptions(string sessionKey, string strCloudSaveID) : this(sessionKey, Guid.Parse(strCloudSaveID)) { }
        public GetCloudSaveByIDOptions(Objects.CloudSave cloudSave) : this(null, cloudSave.ID) { }
        public GetCloudSaveByIDOptions(string sessionKey, Objects.CloudSave cloudSave) : this(sessionKey, cloudSave.ID) { }

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
