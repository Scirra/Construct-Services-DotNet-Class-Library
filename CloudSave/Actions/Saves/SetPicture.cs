using System;
using System.Collections.Generic;
using System.Net.Http;
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
        /// Set a picture on an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/set-picture" />
        [UsedImplicitly]
        public BaseResponse SetPicture(SetCloudSavePictureOptions setCloudSavePictureOptions)
        {
            if (setCloudSavePictureOptions.Picture.Bytes != null)
            {
                return Request.ExecuteMultiPartFormSyncRequest<BaseResponse>(
                    Config.EndPointPaths.Saves.SetPicture,
                    service,
                    setCloudSavePictureOptions.BuildFormData(),
                    setCloudSavePictureOptions.BuildBinaryFormData()
                );
            }
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.SetPicture,
                service,
                setCloudSavePictureOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Set a picture on an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/set-picture" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetPictureAsync(SetCloudSavePictureOptions setCloudSavePictureOptions)
        {
            if (setCloudSavePictureOptions.Picture.Bytes != null)
            {
                return await Request.ExecuteMultiPartFormAsyncRequest<BaseResponse>(
                    Config.EndPointPaths.Saves.SetPicture,
                    service,
                    setCloudSavePictureOptions.BuildFormData(),
                    setCloudSavePictureOptions.BuildBinaryFormData()
                );
            }
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.SetPicture,
                service,
                setCloudSavePictureOptions.BuildFormData()
            );
        }
    }

    
    [UsedImplicitly]
    public sealed class SetCloudSavePictureOptions
    {
        private Guid CloudSaveID { get; }
        internal PictureData Picture { get; }
        private string SessionKey { get; }
    
        public SetCloudSavePictureOptions(Guid cloudSaveID, PictureData picture)
        {
            CloudSaveID = cloudSaveID;
            Picture = picture;
        }
        public SetCloudSavePictureOptions(string sessionKey, Guid cloudSaveID, PictureData picture)
        {
            SessionKey = sessionKey;
            CloudSaveID = cloudSaveID;
            Picture = picture;
        }
        public SetCloudSavePictureOptions(string sessionKey, string strCloudSaveID, PictureData picture)
        {
            SessionKey = sessionKey;
            CloudSaveID = Guid.Parse(strCloudSaveID);
            Picture = picture;
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", CloudSaveID.ToString() }
            };  
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }          
            if (!string.IsNullOrWhiteSpace(Picture.Base64))
            {
                formData.Add("picture", Picture.Base64);
            }
            else if (Picture.URL != null)
            {
                formData.Add("pictureURL", Picture.URL.ToString());
            }
            return formData;
        }
        internal Dictionary<string, ByteArrayContent> BuildBinaryFormData()
        {
            var postedBinaryData = new Dictionary<string, ByteArrayContent>
            {
                { "pictureData", new ByteArrayContent(Picture.Bytes) }
            };
            return postedBinaryData;
        }
    }
}