using ConstructServices.CloudSave.Objects;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Saves
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Get an existing Cloud Save by its key and bucket ID
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public CloudSaveResponse GetByKey(GetCloudSaveByKeyOptions getCloudSaveByKeyOptions)
        {
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                getCloudSaveByKeyOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get an existing Cloud Save by its key and bucket ID
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByKeyAsync(GetCloudSaveByKeyOptions getCloudSaveByKeyOptions)
        {
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                getCloudSaveByKeyOptions.BuildFormData()
            );
        }

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
}