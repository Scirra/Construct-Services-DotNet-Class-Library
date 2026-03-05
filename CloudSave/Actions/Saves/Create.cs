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
    extension(CloudSaveServiceBase service)
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
        private string Key { get; }
        private ByteArrayContent Data { get; }

        [UsedImplicitly]
        public Guid? BucketID { private get; set; }

        [UsedImplicitly]
        public string Name { private get; set; }

        [UsedImplicitly]
        public PictureData Picture { private get; set; }
        
        public CreateCloudSaveOptions(Guid bucketID, string key, byte[] data)
        {
            BucketID = bucketID;
            Key = key;   
            Data = new ByteArrayContent(data);
        }
        public CreateCloudSaveOptions(string key, byte[] data)
        {
            Key = key;   
            Data = new ByteArrayContent(data);
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