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
        public CloudSaveResponse GetPlayerSaveByKey(Guid playerID, string key)
        {            
            var keyValidation = Common.Validations.CloudSave.Functions.IsCloudSaveKeyValid(key);
            if (!keyValidation.Valid) return new CloudSaveResponse(keyValidation.ErrorMessage);

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
        public async Task<CloudSaveResponse> GetPlayerSaveByKeyAsync(Guid playerID, string key)
        {
            var keyValidation = Common.Validations.CloudSave.Functions.IsCloudSaveKeyValid(key);
            if (!keyValidation.Valid) return new CloudSaveResponse(keyValidation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByKeyOptions.BuildFormData(key, null, playerID)
            );
        }

        /// <summary>
        /// Get a Cloud Save in a Bucket by key
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public CloudSaveResponse GetBucketSaveByKey(Guid bucketID, string key)
        {
            var keyValidation = Common.Validations.CloudSave.Functions.IsCloudSaveKeyValid(key);
            if (!keyValidation.Valid) return new CloudSaveResponse(keyValidation.ErrorMessage);

            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByKeyOptions.BuildFormData(key, bucketID, null)
            );
        }

        /// <summary>
        /// Get a Cloud Save in a Bucket by key
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/get-cloud-save" />
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetBucketSaveByKeyAsync(Guid bucketID, string key)
        {
            var keyValidation = Common.Validations.CloudSave.Functions.IsCloudSaveKeyValid(key);
            if (!keyValidation.Valid) return new CloudSaveResponse(keyValidation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByKeyOptions.BuildFormData(key, bucketID, null)
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
            var keyValidation = Common.Validations.CloudSave.Functions.IsCloudSaveKeyValid(key);
            if (!keyValidation.Valid) return new CloudSaveResponse(keyValidation.ErrorMessage);

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
            var keyValidation = Common.Validations.CloudSave.Functions.IsCloudSaveKeyValid(key);
            if (!keyValidation.Valid) return new CloudSaveResponse(keyValidation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Get,
                service,
                GetCloudSaveByKeyOptions.BuildFormData(key, null, null)
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