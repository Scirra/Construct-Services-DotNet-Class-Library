using ConstructServices.Authentication.Objects;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Saves
{
    public sealed class ListPlayerCloudSaveFilters
    {
        public string Name { get; [UsedImplicitly] set; }
        public string Key { get; [UsedImplicitly] set; }
    }

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Return paginated players private cloud saves
        /// </summary>
        [UsedImplicitly]
        public CloudSavesResponse ListPlayersPrivateCloudSaves(
            string sessionKey,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                service.ListPlayersCloudSaves(null, sessionKey, false, paginationOptions, orderBy, filters);

        /// <summary>
        /// Return paginated players private cloud saves
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSavesResponse> ListPlayersPrivateCloudSavesAsync(
            string sessionKey,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                await service.ListPlayersCloudSavesAsync(null, sessionKey, false, paginationOptions, orderBy, filters);
        
        /// <summary>
        /// Return paginated players private cloud saves
        /// </summary>
        [UsedImplicitly]
        public CloudSavesResponse ListPlayersPrivateCloudSaves(
            ExpandedPlayer player,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                service.ListPlayersCloudSaves(player.ID, null, false, paginationOptions, orderBy, filters);

        /// <summary>
        /// Return paginated players private cloud saves
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSavesResponse> ListPlayersPrivateCloudSavesAsync(
            ExpandedPlayer player,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                await service.ListPlayersCloudSavesAsync(player.ID, null, false, paginationOptions, orderBy, filters);
        
        /// <summary>
        /// Return paginated players private cloud saves
        /// </summary>
        [UsedImplicitly]
        public CloudSavesResponse ListPlayersPrivateCloudSaves(
            Guid playerID,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                service.ListPlayersCloudSaves(playerID, null, false, paginationOptions, orderBy, filters);

        /// <summary>
        /// Return paginated players private cloud saves
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSavesResponse> ListPlayersPrivateCloudSavesAsync(
            Guid playerID,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                await service.ListPlayersCloudSavesAsync(playerID, null, false, paginationOptions, orderBy, filters);
        
        /// <summary>
        /// Return paginated players cloud saves in game buckets
        /// </summary>
        [UsedImplicitly]
        public CloudSavesResponse ListPlayersBucketCloudSaves(
            string sessionKey,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                service.ListPlayersCloudSaves(null, sessionKey, true, paginationOptions, orderBy, filters);

        /// <summary>
        /// Return paginated players cloud saves in game buckets
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSavesResponse> ListPlayersBucketCloudSavesAsync(
            string sessionKey,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                await service.ListPlayersCloudSavesAsync(null, sessionKey, true, paginationOptions, orderBy, filters);
        
        /// <summary>
        /// Return paginated players cloud saves in game buckets
        /// </summary>
        [UsedImplicitly]
        public CloudSavesResponse ListPlayersBucketCloudSaves(
            ExpandedPlayer player,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                service.ListPlayersCloudSaves(player.ID, null, true, paginationOptions, orderBy, filters);

        /// <summary>
        /// Return paginated players cloud saves in game buckets
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSavesResponse> ListPlayersBucketCloudSavesAsync(
            ExpandedPlayer player,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                await service.ListPlayersCloudSavesAsync(player.ID, null, true, paginationOptions, orderBy, filters);
        
        /// <summary>
        /// Return paginated players cloud saves in game buckets
        /// </summary>
        [UsedImplicitly]
        public CloudSavesResponse ListPlayersBucketCloudSaves(
            Guid playerID,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                service.ListPlayersCloudSaves(playerID, null, true, paginationOptions, orderBy, filters);
        
        /// <summary>
        /// Return paginated players cloud saves in game buckets
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSavesResponse> ListPlayersBucketCloudSavesAsync(
            Guid playerID,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
            =>
                await service.ListPlayersCloudSavesAsync(playerID, null, true, paginationOptions, orderBy, filters);

        private CloudSavesResponse ListPlayersCloudSaves(
            Guid? playerID,
            string sessionKey,
            bool getBucketSaves,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
        {
            var formData = new Dictionary<string, string>
            {
                { "mode", "Player" },
                { "bucketSaves", getBucketSaves.ToInt().ToString() }
            };

            if (playerID.HasValue)
            {
                formData.Add("playerID", playerID.Value.ToString());
            }
            else
            {
                formData.Add("sessionKey", sessionKey);
            }

            if (orderBy.HasValue)
            {
                formData.Add("orderBy", orderBy.Value.ToString());
            }

            // Filters
            if (filters != null)
            {
                if (!string.IsNullOrWhiteSpace(filters.Name))
                {
                    formData.Add("name", filters.Name);
                }

                if (!string.IsNullOrWhiteSpace(filters.Key))
                {
                    formData.Add("key", filters.Key);
                }
            }

            return Request.ExecuteSyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListPlayerSaves,
                service,
                formData,
                paginationOptions
            );
        }

        private async Task<CloudSavesResponse> ListPlayersCloudSavesAsync(
            Guid? playerID,
            string sessionKey,
            bool getBucketSaves,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            ListPlayerCloudSaveFilters filters = null)
        {
            var formData = new Dictionary<string, string>
            {
                { "mode", "Player" },
                { "bucketSaves", getBucketSaves.ToInt().ToString() }
            };

            if (playerID.HasValue)
            {
                formData.Add("playerID", playerID.Value.ToString());
            }
            else
            {
                formData.Add("sessionKey", sessionKey);
            }

            if (orderBy.HasValue)
            {
                formData.Add("orderBy", orderBy.Value.ToString());
            }

            // Filters
            if (filters != null)
            {
                if (!string.IsNullOrWhiteSpace(filters.Name))
                {
                    formData.Add("name", filters.Name);
                }

                if (!string.IsNullOrWhiteSpace(filters.Key))
                {
                    formData.Add("key", filters.Key);
                }
            }

            return await Request.ExecuteAsyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListPlayerSaves,
                service,
                formData,
                paginationOptions
            );
        }
    }
}