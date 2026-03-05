using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

[UsedImplicitly]
public static partial class Saves
{
    extension(CloudSaveServiceBase service)
    {
        /// <summary>
        /// Delete a picture on an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/delete-picture" />
        [UsedImplicitly]
        public BaseResponse DeletePicture(Guid cloudSaveID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Saves.DeletePicture,
                service,
                DeleteCloudSavePictureOptions.BuildFormData(cloudSaveID)
            );
        }

        /// <summary>
        /// Delete a picture on an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/delete-picture" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeletePictureAsync(Guid cloudSaveID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Saves.DeletePicture,
                service,
                DeleteCloudSavePictureOptions.BuildFormData(cloudSaveID)
            );
        }
    }

    private static class DeleteCloudSavePictureOptions
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