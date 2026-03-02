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
        /// Set a Players avatar
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/set-avatar" />
        [UsedImplicitly]
        public BaseResponse SetAvatar(SetAvatarOptions setAvatarOptions)
        {
            if (setAvatarOptions.Picture.Bytes != null)
            {
                return Request.ExecuteMultiPartFormSyncRequest<BaseResponse>(
                    Config.EndPointPaths.Avatars.SetAvatar,
                    service,
                    setAvatarOptions.BuildFormData(),
                    setAvatarOptions.BuildBinaryFormData()
                );
            }
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.SetAvatar,
                service,
                setAvatarOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Set a Players avatar
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/set-avatar" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetAvatarAsync(SetAvatarOptions setAvatarOptions)
        {
            if (setAvatarOptions.Picture.Bytes != null)
            {
                return await Request.ExecuteMultiPartFormAsyncRequest<BaseResponse>(
                    Config.EndPointPaths.Avatars.SetAvatar,
                    service,
                    setAvatarOptions.BuildFormData(),
                    setAvatarOptions.BuildBinaryFormData()
                );
            }
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.SetAvatar,
                service,
                setAvatarOptions.BuildFormData()
            );
        }
    }
}