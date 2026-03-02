using System.Threading.Tasks;
using ConstructServices.CloudSave.Objects;
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
}