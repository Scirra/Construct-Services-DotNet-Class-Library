using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Avatars
{

    extension(AuthenticationService service)
    {
        /// <summary>
        /// Delete a players avatar
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/delete-avatar" />
        [UsedImplicitly]
        public BaseResponse DeleteAvatar(DeleteAvatarOptions deleteAvatarOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.DeleteAvatar,
                service,
                deleteAvatarOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Delete a players avatar
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/delete-avatar" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteAvatarAsync(DeleteAvatarOptions deleteAvatarOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.DeleteAvatar,
                service,
                deleteAvatarOptions.BuildFormData()
            );
        }
    }
}