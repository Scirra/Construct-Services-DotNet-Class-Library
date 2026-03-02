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
        /// Creates a new Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/create-cloud-save" />
        [UsedImplicitly]
        public CloudSaveResponse CreateCloudSave(
            CreateCloudSaveOptions createCloudSaveOptions)
        {
            return Request.ExecuteMultiPartFormSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Create,
                service,
                createCloudSaveOptions.BuildFormData(),
                createCloudSaveOptions.BuildBinaryFormData()
            );
        }

        /// <summary>
        /// Creates a new Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/create-cloud-save" />
        [UsedImplicitly]
        public async Task<CloudSaveResponse> CreateCloudSaveAsync(
            CreateCloudSaveOptions createCloudSaveOptions)
        {
            return await Request.ExecuteMultiPartFormAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Create,
                service,
                createCloudSaveOptions.BuildFormData(),
                createCloudSaveOptions.BuildBinaryFormData()
            );
        }
    }
}