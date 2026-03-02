using ConstructServices.CloudSave.Objects;
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
}