using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

[UsedImplicitly]
public static partial class CloudSaves
{
    private const string DeletePictureAPIEndPoint = "/deletepicture.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete a picture associated with a cloud save
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeletePicture(
            string sessionKey,
            string strCloudSaveID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strCloudSaveID);
            if (!idValidator.Successfull)
            {
                return new BaseResponse(string.Format(idValidator.ErrorMessage, "Cloud save ID"), false);
            }
            return service.DeletePicture(sessionKey, idValidator.ReturnedObject);
        }
        
        /// <summary>
        /// Delete a picture associated with a cloud save
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeletePictureAsync(
            string sessionKey,
            string strCloudSaveID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strCloudSaveID);
            if (!idValidator.Successfull)
            {
                return new BaseResponse(string.Format(idValidator.ErrorMessage, "Cloud save ID"), false);
            }
            return await service.DeletePictureAsync(sessionKey, idValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete a picture associated with a cloud save
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeletePicture(Guid cloudSaveID)
            => service.DeletePicture(null, cloudSaveID);

        /// <summary>
        /// Delete a picture associated with a cloud save
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeletePictureAsync(Guid cloudSaveID)
            => await service.DeletePictureAsync(null, cloudSaveID);

        /// <summary>
        /// Delete a picture associated with a cloud save
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeletePicture(
            string sessionKey,
            Guid cloudSaveID)
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
            return Request.ExecuteSyncRequest<BaseResponse>(
                DeletePictureAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Delete a picture associated with a cloud save
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeletePictureAsync(
            string sessionKey,
            Guid cloudSaveID)
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
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeletePictureAPIEndPoint,
                service,
                formData
            );
        }
    }
}