using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

public static partial class Saves
{
    extension(CloudSaveServiceBase service)
    {
        /// <summary>
        /// Delete an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/delete-cloud-save" />
        [UsedImplicitly]
        public BaseResponse DeleteCloudSave(Guid cloudSaveID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Saves.Delete,
                service,
                DeleteCloudSaveOptions.BuildFormData(cloudSaveID)
            );
        }

        /// <summary>
        /// Delete an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/delete-cloud-save" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteCloudSaveAsync(Guid cloudSaveID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Saves.Delete,
                service,
                DeleteCloudSaveOptions.BuildFormData(cloudSaveID)
            );
        }
    }

    private static class DeleteCloudSaveOptions
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