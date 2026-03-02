using ConstructServices.CloudSave.Objects;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Saves
{
    extension(CloudSaveService service)
    {        
        /// <summary>
        /// Creates a new Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/create-cloud-save" />
        [UsedImplicitly]
        public CloudSaveResponse CreateCloudSave(
            CreateCloudSaveOptions createCloudSaveOptions)
        {
            return Request.ExecuteMultiPartFormSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Create,
                service,
                createCloudSaveOptions.BuildFormData(),
                createCloudSaveOptions.BuildBinaryFormData()
            );
        }

        /// <summary>
        /// Creates a new Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/create-cloud-save" />
        [UsedImplicitly]
        public async Task<CloudSaveResponse> CreateCloudSaveAsync(
            CreateCloudSaveOptions createCloudSaveOptions)
        {
            return await Request.ExecuteMultiPartFormAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Create,
                service,
                createCloudSaveOptions.BuildFormData(),
                createCloudSaveOptions.BuildBinaryFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class CreateCloudSaveOptions
    {    
        private Guid? BucketID { get; }
        private string SessionKey { get; }
        private string Name { get; }
        private string Key { get; }
        private ByteArrayContent Data { get; }
        private PictureData Picture { get; }
        
        /// <summary>
        /// Create a save in an existing bucket with no player association
        /// </summary>
        public CreateCloudSaveOptions(
            Guid bucketID,
            byte[] data,
            string name,
            string key,
            PictureData picture = null)
        {
            BucketID = bucketID;
            Data = new ByteArrayContent(data);
            Name = name;
            Key = key;
            Picture = picture;
        }    

        /// <summary>
        /// Create a save in an existing bucket with no player association
        /// </summary>
        public CreateCloudSaveOptions(
            Bucket bucket,
            byte[] data,
            string name,
            string key,
            PictureData picture = null)
        {
            BucketID = bucket.ID;
            Data = new ByteArrayContent(data);
            Name = name;
            Key = key;
            Picture = picture;
        }    

        /// <summary>
        /// Create a player save in an existing bucket
        /// </summary>
        public CreateCloudSaveOptions(
            string sessionKey,
            Guid bucketID,
            byte[] data,
            string name,
            string key,
            PictureData picture = null)
        {
            SessionKey = sessionKey;
            BucketID = bucketID;
            Data = new ByteArrayContent(data);
            Name = name;
            Key = key;
            Picture = picture;
        }    

        /// <summary>
        /// Create a player save in an existing bucket
        /// </summary>
        public CreateCloudSaveOptions(
            string sessionKey,
            string strBucketID,
            byte[] data,
            string name,
            string key,
            PictureData picture = null)
        {
            SessionKey = sessionKey;
            BucketID = Guid.Parse(strBucketID);
            Data = new ByteArrayContent(data);
            Name = name;
            Key = key;
            Picture = picture;
        }

        /// <summary>
        /// Create a private save in a players account
        /// </summary>
        public CreateCloudSaveOptions(
            string sessionKey,
            byte[] data,
            string name,
            string key,
            PictureData picture = null)
        {
            SessionKey = sessionKey;
            Data = new ByteArrayContent(data);
            Name = name;
            Key = key;
            Picture = picture;
        }    

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "name", Name },
                { "key", Key }
            };
            if (BucketID.HasValue)
            {
                formData.Add("bucketID", BucketID.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }
            if (Picture != null)
            {
                if (!string.IsNullOrWhiteSpace(Picture.Base64))
                {
                    formData.Add("picture", Picture.Base64);
                }
                else if (Picture.URL != null)
                {
                    formData.Add("pictureURL", Picture.URL.ToString());
                }
            }
            return formData;
        }

        internal Dictionary<string, ByteArrayContent> BuildBinaryFormData()
        {
            var postedBinaryData = new Dictionary<string, ByteArrayContent>
            {
                { "data", Data }
            };
            if (Picture?.Bytes != null)
            {
                postedBinaryData.Add("pictureData", new ByteArrayContent(Picture.Bytes));
            }
            return postedBinaryData;
        }
    }
}