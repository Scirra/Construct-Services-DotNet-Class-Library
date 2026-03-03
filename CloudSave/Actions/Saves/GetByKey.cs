using System;
using System.Collections.Generic;
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
    }

    public sealed class GetCloudSaveByKeyOptions(string sessionKey, string key, Guid bucketID)
    {
        private string SessionKey { get; } = sessionKey;
        private string Key { get; } = key;
        private Guid BucketID { get; } = bucketID;
    
        [UsedImplicitly]
        public GetCloudSaveByKeyOptions(string key, Guid bucketID) : this(null, key, bucketID) { }
        public GetCloudSaveByKeyOptions(string key, string strBucketID) : this(null, key, Guid.Parse(strBucketID)) { }
        public GetCloudSaveByKeyOptions(string key, Bucket bucket) : this(null, key, bucket.ID) { }
        public GetCloudSaveByKeyOptions(string sessionKey, string key, string strBucketID) : this(sessionKey, key, Guid.Parse(strBucketID)) { }
        public GetCloudSaveByKeyOptions(string sessionKey, string key, Bucket bucket) : this(sessionKey, key, bucket.ID) { }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "key", Key },
                { "bucketID", BucketID.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }        
            return formData;
        }
    }    
}