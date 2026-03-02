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
        /// List all players non private Cloud Saves
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-saves" />
        [UsedImplicitly]
        public CloudSavesResponse ListPlayersCloudSaves(
            ListPlayersBucketSavesOptions listPlayersBucketSavesOptions,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListPlayerSaves,
                service,
                listPlayersBucketSavesOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List all players non private Cloud Saves
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-saves" />
        [UsedImplicitly]
        public async Task<CloudSavesResponse> ListPlayersCloudSavesAsync(
            ListPlayersBucketSavesOptions listPlayersBucketSavesOptions,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListPlayerSaves,
                service,
                listPlayersBucketSavesOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List all private Cloud Saves in a players account
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-saves" />
        [UsedImplicitly]
        public CloudSavesResponse ListPlayersPrivateCloudSaves(
            ListPlayersPrivateSavesOptions listPlayersPrivateSavesOptions,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListPlayerSaves,
                service,
                listPlayersPrivateSavesOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List all private Cloud Saves in a players account
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-saves" />
        [UsedImplicitly]
        public async Task<CloudSavesResponse> ListPlayersPrivateCloudSavesAsync(
            ListPlayersPrivateSavesOptions listPlayersPrivateSavesOptions,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListPlayerSaves,
                service,
                listPlayersPrivateSavesOptions.BuildFormData(),
                paginationOptions
            );
        }
    }
}