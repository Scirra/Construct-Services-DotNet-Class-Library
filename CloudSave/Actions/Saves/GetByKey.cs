using System;
using System.Collections.Generic;
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
        /// Get a players private Cloud Save by key
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public CloudSaveResponse GetByKey(Guid playerID, string key)
        {
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByKeyOptions.BuildFormData(key, null, playerID)
            );
        }

        /// <summary>
        /// Get a players private Cloud Save by key
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByKeyAsync(Guid playerID, string key)
        {
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByKeyOptions.BuildFormData(key, null, playerID)
            );
        }
    }

    extension(PlayerCloudSaveService service)
    {
        /// <summary>
        /// Get private Cloud Save by key
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public CloudSaveResponse GetByKey(string key)
        {
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByKeyOptions.BuildFormData(key, null, null)
            );
        }

        /// <summary>
        /// Get private Cloud Save by key
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByKeyAsync(string key)
        {
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByKeyOptions.BuildFormData(key, null, null)
            );
        }
    }

    extension(CloudSaveServiceBase service)
    {
        /// <summary>
        /// Get an existing Cloud Save by its key and bucket ID
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public CloudSaveResponse GetByKey(Guid bucketID, string key)
        {
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByKeyOptions.BuildFormData(key, bucketID, null)
            );
        }

        /// <summary>
        /// Get an existing Cloud Save by its key and bucket ID
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByKeyAsync(Guid bucketID, string key)
        {
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByKeyOptions.BuildFormData(key, bucketID, null)
            );
        }
    }
    private static class GetCloudSaveByKeyOptions
    {
        internal static Dictionary<string, string> BuildFormData(string key, Guid? bucketID, Guid? playerID)
        {
            var formData = new Dictionary<string, string>
            {
                { "key", key }
            };
            if (bucketID.HasValue)
            {
                formData.Add("bucketID", bucketID.Value.ToString());
            }
            if (playerID.HasValue)
            {
                formData.Add("playerID", playerID.Value.ToString());
            }
            return formData;
        }
    }    
}