using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Saves
{
    extension(CloudSaveServiceBase service)
    {
        /// <summary>
        /// Get an existing Cloud Save by its ID
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public CloudSaveResponse GetByID(Guid cloudSaveID)
        {
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByIDOptions.BuildFormData(cloudSaveID)
            );
        }

        /// <summary>
        /// Get an existing Cloud Save by its ID
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByIDAsync(Guid cloudSaveID)
        {
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByIDOptions.BuildFormData(cloudSaveID)
            );
        }
    }
    
    private static class GetCloudSaveByIDOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid cloudSaveID)
        {
            return new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() }
            };
        }
    }
}
