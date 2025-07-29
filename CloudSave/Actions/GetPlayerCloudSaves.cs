using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    public class GetPlayerCloudSaveFilters
    {
        public string Name { get; set; }
        public string Key { get; set; }
    }

    /// <summary>
    /// Return paginated players cloud saves
    /// </summary>
    [UsedImplicitly]
    public static CloudSavesResponse GetCloudSaves(
        this CloudSaveService service,
        string sessionKey,
        PaginationOptions paginationOptions,
        Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
        GetPlayerCloudSaveFilters filters = null)
        => GetCloudSaves(service, null, sessionKey, paginationOptions, orderBy, filters);

    /// <summary>
    /// Return paginated players cloud saves
    /// </summary>
    [UsedImplicitly]
    public static CloudSavesResponse GetCloudSaves(
        this CloudSaveService service,
        Guid playerID,
        PaginationOptions paginationOptions,
        Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
        GetPlayerCloudSaveFilters filters = null)
    => GetCloudSaves(service, playerID, null, paginationOptions, orderBy, filters);

    private static CloudSavesResponse GetCloudSaves(
        this CloudSaveService service,
        Guid? playerID,
        string sessionKey,
        PaginationOptions paginationOptions,
        Enums.GetPlayerCloudSaveSortMethod? orderBy = null,
        GetPlayerCloudSaveFilters filters = null)
    {
        var formData = new Dictionary<string, string>
        {
            { "mode", "Player" }
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
        return Task.Run(() => Request.ExecuteRequest<CloudSavesResponse>(
            path,
            service,
            formData,
            paginationOptions
        )).Result;
    }
}