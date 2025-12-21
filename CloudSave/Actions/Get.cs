using ConstructServices.CloudSave.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using ConstructServices.Common;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Get a cloud save by its key
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByKey(string cloudSaveKey)
        {
            var formData = new Dictionary<string, string>
            {
                { "key", cloudSaveKey }
            };
            const string path = "/getcloudsave.json";
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                path,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its key
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(Guid bucketID,
            string cloudSaveKey)
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveKey },
                { "bucketID", bucketID.ToString() }
            };
            const string path = "/getcloudsave.json";
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                path,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its key
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(string sessionKey,
            Guid bucketID,
            string cloudSaveKey)
        {
            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "key", cloudSaveKey },
                { "bucketID", bucketID.ToString() }
            };
            const string path = "/getcloudsave.json";
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                path,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save by its key
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(string sessionKey,
            string cloudSaveKey)
        {
            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "key", cloudSaveKey }
            };
            const string path = "/getcloudsave.json";
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                path,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save by its ID
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() }
            };
            const string path = "/getcloudsave.json";
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                path,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its ID
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(Guid bucketID,
            Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() },
                { "bucketID", bucketID.ToString() }
            };
            const string path = "/getcloudsave.json";
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                path,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its ID
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(string sessionKey,
            Guid bucketID,
            Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "blobID", cloudSaveID.ToString() },
                { "bucketID", bucketID.ToString() }
            };
            const string path = "/getcloudsave.json";
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                path,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save by its ID
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(string sessionKey,
            Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "blobID", cloudSaveID.ToString() }
            };
            const string path = "/getcloudsave.json";
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                path,
                service,
                formData
            );
        }
    }
}