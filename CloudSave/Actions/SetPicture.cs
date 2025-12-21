using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    private const string SetPictureAPIEndPoint = "/setpicture.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Set a cloud saves picture
        /// </summary>
        [UsedImplicitly]
        public BaseResponse SetPicture(
            string sessionKey,
            string strCloudSaveID,
            PictureData picture)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strCloudSaveID);
            if (!idValidator.Successfull)
            {
                return new BaseResponse(string.Format(idValidator.ErrorMessage, "Cloud save ID"), false);
            }
            return service.SetPicture(sessionKey, idValidator.ReturnedObject, picture);
        }

        /// <summary>
        /// Set a cloud saves picture
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> SetPictureAsync(
            string sessionKey,
            string strCloudSaveID,
            PictureData picture)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strCloudSaveID);
            if (!idValidator.Successfull)
            {
                return new BaseResponse(string.Format(idValidator.ErrorMessage, "Cloud save ID"), false);
            }
            return await service.SetPictureAsync(sessionKey, idValidator.ReturnedObject, picture);
        }
        
        /// <summary>
        /// Set a cloud saves picture
        /// </summary>
        [UsedImplicitly]
        public BaseResponse SetPicture(
            string sessionKey,
            Guid cloudSaveID,
            PictureData picture)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage, false);
            }

            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(sessionKey))
            {
                formData.Add("sessionKey", sessionKey);
            }

            // Picture by data
            if (picture.Bytes != null)
            {
                return Request.ExecuteMultiPartFormSyncRequest<BaseResponse>(
                    SetPictureAPIEndPoint,
                    service,
                    formData,
                    new Dictionary<string, ByteArrayContent>{ {"picture", new ByteArrayContent(picture.Bytes) } }
                );
            }

            // By URL
            if (picture.URL != null)
            {
                formData.Add("pictureURL", picture.URL.ToString());
                return Request.ExecuteSyncRequest<CloudSaveResponse>(
                    SetPictureAPIEndPoint,
                    service,
                    formData
                );
            }

            // By base 64
            if (!string.IsNullOrWhiteSpace(picture.Base64))
            {
                formData.Add("picture", picture.Base64);
                return Request.ExecuteSyncRequest<CloudSaveResponse>(
                    SetPictureAPIEndPoint,
                    service,
                    formData
                );
            }

            return new BaseResponse("No picture data provided.", false);
        }

        /// <summary>
        /// Set a cloud saves picture
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> SetPictureAsync(
            string sessionKey,
            Guid cloudSaveID,
            PictureData picture)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage, false);
            }

            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(sessionKey))
            {
                formData.Add("sessionKey", sessionKey);
            }

            // Picture by data
            if (picture.Bytes != null)
            {
                return await Request.ExecuteMultiPartFormAsyncRequest<BaseResponse>(
                    SetPictureAPIEndPoint,
                    service,
                    formData,
                    new Dictionary<string, ByteArrayContent>{ {"picture", new ByteArrayContent(picture.Bytes) } }
                );
            }

            // By URL
            if (picture.URL != null)
            {
                formData.Add("pictureURL", picture.URL.ToString());
                return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                    SetPictureAPIEndPoint,
                    service,
                    formData
                );
            }

            // By base 64
            if (!string.IsNullOrWhiteSpace(picture.Base64))
            {
                formData.Add("picture", picture.Base64);
                return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                    SetPictureAPIEndPoint,
                    service,
                    formData
                );
            }

            return new BaseResponse("No picture data provided.", false);
        }
    }
}