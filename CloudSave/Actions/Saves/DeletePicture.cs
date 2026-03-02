using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

[UsedImplicitly]
public static partial class Saves
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete a picture on an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/delete-picture" />
        [UsedImplicitly]
        public BaseResponse DeletePicture(DeleteCloudSavePictureOptions deleteCloudSavePictureOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Saves.DeletePicture,
                service,
                deleteCloudSavePictureOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Delete a picture on an existing Cloud Save
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/cloud-saves/delete-picture" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeletePictureAsync(DeleteCloudSavePictureOptions deleteCloudSavePictureOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Saves.DeletePicture,
                service,
                deleteCloudSavePictureOptions.BuildFormData()
            );
        }
    }
}