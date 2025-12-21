using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    private const string DeleteAPIEndPoint = "/delete.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete a cloud save
        /// </summary>
        [UsedImplicitly]
        public BaseResponse Delete(string strCloudSaveID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strCloudSaveID);
            if (!idValidator.Successfull)
            {
                return new BaseResponse(string.Format(idValidator.ErrorMessage, "Cloud save ID"), false);
            }
            return service.Delete(idValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete a cloud save
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteAsync(string strCloudSaveID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strCloudSaveID);
            if (!idValidator.Successfull)
            {
                return new BaseResponse(string.Format(idValidator.ErrorMessage, "Cloud save ID"), false);
            }
            return await service.DeleteAsync(idValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete a cloud save
        /// </summary>
        [UsedImplicitly]
        public BaseResponse Delete(Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() }
            };

            return Request.ExecuteSyncRequest<BaseResponse>(
                DeleteAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Delete a cloud save
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteAsync(Guid cloudSaveID)
        {
            var formData = new Dictionary<string, string>
            {
                { "blobID", cloudSaveID.ToString() }
            };

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeleteAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Delete a cloud save
        /// </summary>
        [UsedImplicitly]
        public BaseResponse Delete(
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
                { "sessionKey", sessionKey },
                { "blobID", cloudSaveID.ToString() }
            };

            return Request.ExecuteSyncRequest<BaseResponse>(
                DeleteAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Delete a cloud save
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteAsync(
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
                { "sessionKey", sessionKey },
                { "blobID", cloudSaveID.ToString() }
            };

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeleteAPIEndPoint,
                service,
                formData
            );
        }
    }
}