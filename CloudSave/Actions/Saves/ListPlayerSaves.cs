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
        /// List all players non private Cloud Saves
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-saves" />
        [UsedImplicitly]
        public CloudSavesResponse ListPlayersCloudSaves(
            ListPlayersSavesOptions listPlayersSavesOptions,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListPlayerSaves,
                service,
                listPlayersSavesOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List all players non private Cloud Saves
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-saves" />
        [UsedImplicitly]
        public async Task<CloudSavesResponse> ListPlayersCloudSavesAsync(
            ListPlayersSavesOptions listPlayersSavesOptions,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListPlayerSaves,
                service,
                listPlayersSavesOptions.BuildFormData(),
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

    public abstract class ListPlayerSaveOptions(bool returnPrivateSaves)
    {
        private bool ReturnPrivateSaves { get; } = returnPrivateSaves;

        [UsedImplicitly]
        public Guid PlayerID { private get; set; }

        [UsedImplicitly]
        public Enums.GetPlayerCloudSaveSortMethod? SortBy { private get; set; }

        [UsedImplicitly]
        public ListPlayerCloudSaveFilters Filters { private get; set; }

        internal Dictionary<string, string> BuildBaseFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "mode", "Player" },
                { "playerID", PlayerID.ToString() },
                { "bucketSaves", (!ReturnPrivateSaves).ToInt().ToString() }
            };
            if (SortBy.HasValue)
            {
                formData.Add("orderBy", SortBy.ToString());
            }
            if (Filters != null)
            {
                if (!string.IsNullOrWhiteSpace(Filters.Name))
                {
                    formData.Add("name", Filters.Name);
                }

                if (!string.IsNullOrWhiteSpace(Filters.Key))
                {
                    formData.Add("key", Filters.Key);
                }
            }
            return formData;
        }
    }

    [UsedImplicitly]
    public sealed class ListPlayersPrivateSavesOptions()
        : ListPlayerSaveOptions(true)
    {
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = BuildBaseFormData();
            return formData;
        }
    }

    [UsedImplicitly]
    public sealed class ListPlayersSavesOptions()
        : ListPlayerSaveOptions(false)
    {
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = BuildBaseFormData();
            return formData;
        }
    }    
}