using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    private const string GetSaveAPIEndPoint = "/getcloudsave.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Get a cloud save by its key
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByKey(string cloudSaveKey)
        {
            var keyValidator = Common.Validations.CloudSaveKey.ValidateKey(cloudSaveKey);
            if (!keyValidator.Successfull)
            {
                return new CloudSaveResponse(keyValidator.ErrorMessage);
            }
            var formData = new Dictionary<string, string>
            {
                { "key", cloudSaveKey }
            };
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save by its key
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByKeyAsync(string cloudSaveKey)
        {
            var keyValidator = Common.Validations.CloudSaveKey.ValidateKey(cloudSaveKey);
            if (!keyValidator.Successfull)
            {
                return new CloudSaveResponse(keyValidator.ErrorMessage);
            }
            var formData = new Dictionary<string, string>
            {
                { "key", cloudSaveKey }
            };
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its key
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(
            Guid bucketID,
            string cloudSaveKey)
        {
            var keyValidator = Common.Validations.CloudSaveKey.ValidateKey(cloudSaveKey);
            if (!keyValidator.Successfull)
            {
                return new CloudSaveResponse(keyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveKey },
                { "bucketID", bucketID.ToString() }
            };
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its key
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByIDAsync(
            Guid bucketID,
            string cloudSaveKey)
        {
            var keyValidator = Common.Validations.CloudSaveKey.ValidateKey(cloudSaveKey);
            if (!keyValidator.Successfull)
            {
                return new CloudSaveResponse(keyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveKey },
                { "bucketID", bucketID.ToString() }
            };
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its key
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(
            string sessionKey,
            Guid bucketID,
            string cloudSaveKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new CloudSaveResponse(sessionKeyValidator.ErrorMessage);
            }
            var keyValidator = Common.Validations.CloudSaveKey.ValidateKey(cloudSaveKey);
            if (!keyValidator.Successfull)
            {
                return new CloudSaveResponse(keyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "key", cloudSaveKey },
                { "bucketID", bucketID.ToString() }
            };
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its key
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByIDAsync(
            string sessionKey,
            Guid bucketID,
            string cloudSaveKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new CloudSaveResponse(sessionKeyValidator.ErrorMessage);
            }
            var keyValidator = Common.Validations.CloudSaveKey.ValidateKey(cloudSaveKey);
            if (!keyValidator.Successfull)
            {
                return new CloudSaveResponse(keyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "key", cloudSaveKey },
                { "bucketID", bucketID.ToString() }
            };
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save by its key
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(
            string sessionKey,
            string cloudSaveKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new CloudSaveResponse(sessionKeyValidator.ErrorMessage);
            }
            var keyValidator = Common.Validations.CloudSaveKey.ValidateKey(cloudSaveKey);
            if (!keyValidator.Successfull)
            {
                return new CloudSaveResponse(keyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "key", cloudSaveKey }
            };
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save by its key
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByIDAsync(
            string sessionKey,
            string cloudSaveKey)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new CloudSaveResponse(sessionKeyValidator.ErrorMessage);
            }
            var keyValidator = Common.Validations.CloudSaveKey.ValidateKey(cloudSaveKey);
            if (!keyValidator.Successfull)
            {
                return new CloudSaveResponse(keyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "key", cloudSaveKey }
            };
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
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
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save by its ID
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByIDAsync(Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() }
            };
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its ID
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(
            Guid bucketID,
            Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() },
                { "bucketID", bucketID.ToString() }
            };
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its ID
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByIDAsync(
            Guid bucketID,
            Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() },
                { "bucketID", bucketID.ToString() }
            };
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its ID
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(
            string sessionKey,
            Guid bucketID,
            Guid cloudSaveID)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new CloudSaveResponse(sessionKeyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "blobID", cloudSaveID.ToString() },
                { "bucketID", bucketID.ToString() }
            };
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save in a bucket by its ID
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByIDAsync(
            string sessionKey,
            Guid bucketID,
            Guid cloudSaveID)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new CloudSaveResponse(sessionKeyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "blobID", cloudSaveID.ToString() },
                { "bucketID", bucketID.ToString() }
            };
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save by its ID
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse GetByID(
            string sessionKey,
            Guid cloudSaveID)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new CloudSaveResponse(sessionKeyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "blobID", cloudSaveID.ToString() }
            };
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a cloud save by its ID
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> GetByIDAsync(
            string sessionKey,
            Guid cloudSaveID)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new CloudSaveResponse(sessionKeyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "blobID", cloudSaveID.ToString() }
            };
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                GetSaveAPIEndPoint,
                service,
                formData
            );
        }
    }
}