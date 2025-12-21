using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Authentication.Objects;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    public sealed class GetPlayerCloudSaveFilters
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
        public CloudSavesResponse GetPlayersPrivateCloudSaves(
            string sessionKey,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            GetPlayerCloudSaveFilters filters = null)
            => GetPlayersCloudSaves(service, null, sessionKey, false, paginationOptions, orderBy, filters);
        
        /// <summary>
        /// Return paginated players private cloud saves
        /// </summary>
        [UsedImplicitly]
        public CloudSavesResponse GetPlayersPrivateCloudSaves(
            ExpandedPlayer player,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            GetPlayerCloudSaveFilters filters = null)
            => GetPlayersCloudSaves(service, player.ID, null, false, paginationOptions, orderBy, filters);

        /// <summary>
        /// Return paginated players private cloud saves
        /// </summary>
        [UsedImplicitly]
        public CloudSavesResponse GetPlayersPrivateCloudSaves(
            Guid playerID,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            GetPlayerCloudSaveFilters filters = null)
            => GetPlayersCloudSaves(service, playerID, null, false, paginationOptions, orderBy, filters);
        
        /// <summary>
        /// Return paginated players cloud saves in game buckets
        /// </summary>
        [UsedImplicitly]
        public CloudSavesResponse GetPlayersBucketCloudSaves(
            string sessionKey,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            GetPlayerCloudSaveFilters filters = null)
            => GetPlayersCloudSaves(service, null, sessionKey, true, paginationOptions, orderBy, filters);
        
        /// <summary>
        /// Return paginated players cloud saves in game buckets
        /// </summary>
        [UsedImplicitly]
        public CloudSavesResponse GetPlayersBucketCloudSaves(
            ExpandedPlayer player,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            GetPlayerCloudSaveFilters filters = null)
            => GetPlayersCloudSaves(service, player.ID, null, true, paginationOptions, orderBy, filters);

        /// <summary>
        /// Return paginated players cloud saves in game buckets
        /// </summary>
        [UsedImplicitly]
        public CloudSavesResponse GetPlayersBucketCloudSaves(
            Guid playerID,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            GetPlayerCloudSaveFilters filters = null)
            => GetPlayersCloudSaves(service, playerID, null, true, paginationOptions, orderBy, filters);
        
        private CloudSavesResponse GetPlayersCloudSaves(
            Guid? playerID,
            string sessionKey,
            bool getBucketSaves,
            PaginationOptions paginationOptions,
            Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
            GetPlayerCloudSaveFilters filters = null)
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

            const string path = "/getcloudsaves.json";
            return Request.ExecuteSyncRequest<CloudSavesResponse>(
                path,
                service,
                formData,
                paginationOptions
            );
        }
    }
}