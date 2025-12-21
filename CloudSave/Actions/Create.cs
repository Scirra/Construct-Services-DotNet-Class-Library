using ConstructServices.CloudSave.Objects;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    private const string CreateAPIEndPoint = "/create.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Upload a new cloud save to a bucket from a player
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse Create(string sessionKey,
            Guid bucketID,
            byte[] cloudSaveData,
            string cloudSaveName,
            string cloudSaveKey,
            PictureData picture = null)
            => DoCreate(service, sessionKey, bucketID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);
        
        /// <summary>
        /// Upload a new cloud save to a bucket from a player
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> CreateAsync(
            string sessionKey,
            Guid bucketID,
            byte[] cloudSaveData,
            string cloudSaveName,
            string cloudSaveKey,
            PictureData picture = null)
            => await DoCreateAsync(service, sessionKey, bucketID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);
        
        /// <summary>
        /// Upload a new cloud save to a bucket from a player
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse Create(string sessionKey,
            GameBucket bucket,
            byte[] cloudSaveData,
            string cloudSaveName,
            string cloudSaveKey,
            PictureData picture = null)
            => DoCreate(service, sessionKey, bucket.ID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);

        /// <summary>
        /// Upload a new cloud save to a bucket from a player
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> CreateAsync(string sessionKey,
            GameBucket bucket,
            byte[] cloudSaveData,
            string cloudSaveName,
            string cloudSaveKey,
            PictureData picture = null)
            => await DoCreateAsync(service, sessionKey, bucket.ID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);
        
        /// <summary>
        /// Upload a new cloud save to a bucket with no player association
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse Create(Guid bucketID,
            byte[] cloudSaveData,
            string cloudSaveName,
            string cloudSaveKey,
            PictureData picture = null)
            => DoCreate(service, null, bucketID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);

        /// <summary>
        /// Upload a new cloud save to a bucket with no player association
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> CreateAsync(Guid bucketID,
            byte[] cloudSaveData,
            string cloudSaveName,
            string cloudSaveKey,
            PictureData picture = null)
            => await DoCreateAsync(service, null, bucketID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);
        
        /// <summary>
        /// Upload a new cloud save to a bucket with no player association
        /// </summary>
        [UsedImplicitly]
        public CloudSaveResponse Create(GameBucket bucket,
            byte[] cloudSaveData,
            string cloudSaveName,
            string cloudSaveKey,
            PictureData picture = null)
            => DoCreate(service, null, bucket.ID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);

        /// <summary>
        /// Upload a new cloud save to a bucket with no player association
        /// </summary>
        [UsedImplicitly]
        public async Task<CloudSaveResponse> CreateAsync(GameBucket bucket,
            byte[] cloudSaveData,
            string cloudSaveName,
            string cloudSaveKey,
            PictureData picture = null)
            => await DoCreateAsync(service, null, bucket.ID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);
    }
    
    private static CloudSaveResponse DoCreate(
        CloudSaveService service,
        string sessionKey,
        Guid? bucketID,
        byte[] cloudSaveData,
        string cloudSaveName,
        string cloudSaveKey,
        PictureData picture = null)
    {
        var keyValidator = Common.Validations.CloudSaveKey.ValidateKey(cloudSaveKey);
        if (!keyValidator.Successfull)
        {
            return new CloudSaveResponse(keyValidator.ErrorMessage, false);
        }

        var formData = new Dictionary<string, string>
        {
            { "name", cloudSaveName },
            { "key", cloudSaveKey }
        };
        if (!string.IsNullOrWhiteSpace(sessionKey))
        {
            formData.Add("sessionKey", sessionKey);
        }
        if (bucketID.HasValue)
        {
            formData.Add("bucketID", bucketID.ToString());
        }
        
        // Add binary data to request
        var postedBinaryData = new Dictionary<string, ByteArrayContent>
        {
            { "data", new ByteArrayContent(cloudSaveData) }
        };
        if (picture != null)
        {
            if (!string.IsNullOrWhiteSpace(picture.Base64))
            {
                formData.Add("picture", picture.Base64);
            }
            else if (picture.URL != null)
            {
                formData.Add("pictureURL", picture.URL.ToString());
            }
            if (picture.Bytes != null)
            {
                postedBinaryData.Add("pictureData", new ByteArrayContent(picture.Bytes));
            }
        }

        return Request.ExecuteMultiPartFormSyncRequest<CloudSaveResponse>(
            CreateAPIEndPoint,
            service,
            formData,
            postedBinaryData
        );
    }

    private static async Task<CloudSaveResponse> DoCreateAsync(
        CloudSaveService service,
        string sessionKey,
        Guid? bucketID,
        byte[] cloudSaveData,
        string cloudSaveName,
        string cloudSaveKey,
        PictureData picture = null)
    {
        var keyValidator = Common.Validations.CloudSaveKey.ValidateKey(cloudSaveKey);
        if (!keyValidator.Successfull)
        {
            return new CloudSaveResponse(keyValidator.ErrorMessage, false);
        }

        var formData = new Dictionary<string, string>
        {
            { "name", cloudSaveName },
            { "key", cloudSaveKey }
        };
        if (!string.IsNullOrWhiteSpace(sessionKey))
        {
            formData.Add("sessionKey", sessionKey);
        }
        if (bucketID.HasValue)
        {
            formData.Add("bucketID", bucketID.ToString());
        }
        
        // Add binary data to request
        var postedBinaryData = new Dictionary<string, ByteArrayContent>
        {
            { "data", new ByteArrayContent(cloudSaveData) }
        };
        if (picture != null)
        {
            if (!string.IsNullOrWhiteSpace(picture.Base64))
            {
                formData.Add("picture", picture.Base64);
            }
            else if (picture.URL != null)
            {
                formData.Add("pictureURL", picture.URL.ToString());
            }
            if (picture.Bytes != null)
            {
                postedBinaryData.Add("pictureData", new ByteArrayContent(picture.Bytes));
            }
        }

        return await Request.ExecuteMultiPartFormAsyncRequest<CloudSaveResponse>(
            CreateAPIEndPoint,
            service,
            formData,
            postedBinaryData
        );
    }
}