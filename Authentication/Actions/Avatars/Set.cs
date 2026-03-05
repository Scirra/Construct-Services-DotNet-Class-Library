using System;
using System.Collections.Generic;
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
        public BaseResponse SetAvatar(Guid playerID, PictureData avatar)
        {
            if (avatar.Bytes != null)
            {
                return Request.ExecuteMultiPartFormSyncRequest<BaseResponse>(
                    Config.EndPointPaths.Avatars.SetAvatar,
                    service,
                    SetAvatarOptions.BuildFormData(playerID, avatar),
                    PictureData.BuildBinaryFormData(avatar)
                );
            }
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.SetAvatar,
                service,
                SetAvatarOptions.BuildFormData(playerID, avatar)
            );
        }

        /// <summary>
        /// Set a Players avatar
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/set-avatar" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetAvatarAsync(Guid playerID, PictureData avatar)
        {
            if (avatar.Bytes != null)
            {
                return await Request.ExecuteMultiPartFormAsyncRequest<BaseResponse>(
                    Config.EndPointPaths.Avatars.SetAvatar,
                    service,
                    SetAvatarOptions.BuildFormData(playerID, avatar),
                    PictureData.BuildBinaryFormData(avatar)
                );
            }
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.SetAvatar,
                service,
                SetAvatarOptions.BuildFormData(playerID, avatar)
            );
        }
    }

    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Set avatar
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/set-avatar" />
        [UsedImplicitly]
        public BaseResponse SetAvatar(PictureData avatar)
        {
            if (avatar.Bytes != null)
            {
                return Request.ExecuteMultiPartFormSyncRequest<BaseResponse>(
                    Config.EndPointPaths.Avatars.SetAvatar,
                    service,
                    SetAvatarOptions.BuildFormData(avatar),
                    PictureData.BuildBinaryFormData(avatar)
                );
            }
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.SetAvatar,
                service,
                SetAvatarOptions.BuildFormData(avatar)
            );
        }

        /// <summary>
        /// Set avatar
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/set-avatar" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetAvatarAsync(PictureData avatar)
        {
            if (avatar.Bytes != null)
            {
                return await Request.ExecuteMultiPartFormAsyncRequest<BaseResponse>(
                    Config.EndPointPaths.Avatars.SetAvatar,
                    service,
                    SetAvatarOptions.BuildFormData(avatar),
                    PictureData.BuildBinaryFormData(avatar)
                );
            }
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.SetAvatar,
                service,
                SetAvatarOptions.BuildFormData(avatar)
            );
        }
    }
    
    private static class SetAvatarOptions
    { 
        internal static Dictionary<string, string> BuildFormData(Guid playerID, PictureData avatar)
        {
            var formData = PictureData.BuildBaseFormData(avatar);
            formData.Add("playerID", playerID.ToString());
            return formData;
        }
        internal static Dictionary<string, string> BuildFormData(PictureData avatar)
        {
            var formData = PictureData.BuildBaseFormData(avatar);
            return formData;
        }
    }
}