using System;
using System.Collections.Generic;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Saves
{
    extension(CloudSaveServiceBase service)
    {
        /// <summary>
        /// Set a picture on an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/set-picture" />
        [UsedImplicitly]
        public BaseResponse SetPicture(Guid cloudSaveID, PictureData picture)
        {
            if (picture.Bytes != null)
            {
                return Request.ExecuteMultiPartFormSyncRequest<BaseResponse>(
                    Config.EndPointPaths.Saves.SetPicture,
                    service,
                    SetCloudSavePictureOptions.BuildFormData(cloudSaveID, picture),
                    PictureData.BuildBinaryFormData(picture)
                );
            }
            return Request.ExecuteSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.SetPicture,
                service,
                SetCloudSavePictureOptions.BuildFormData(cloudSaveID, picture)
            );
        }

        /// <summary>
        /// Set a picture on an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/set-picture" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetPictureAsync(Guid cloudSaveID, PictureData picture)
        {
            if (picture.Bytes != null)
            {
                return await Request.ExecuteMultiPartFormAsyncRequest<BaseResponse>(
                    Config.EndPointPaths.Saves.SetPicture,
                    service,
                    SetCloudSavePictureOptions.BuildFormData(cloudSaveID, picture),
                    PictureData.BuildBinaryFormData(picture)
                );
            }
            return await Request.ExecuteAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.SetPicture,
                service,
                SetCloudSavePictureOptions.BuildFormData(cloudSaveID, picture)
            );
        }
    }
    
    private static class SetCloudSavePictureOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid cloudSaveID, PictureData picture)
        {
            var formData = PictureData.BuildBaseFormData(picture);
            formData.Add("blobID", cloudSaveID.ToString());
            return formData;
        }
    }
}