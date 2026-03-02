using System;
using System.Collections.Generic;
using System.Net.Http;
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
    
    [UsedImplicitly]
    public sealed class SetAvatarOptions
    {    
        private Guid? PlayerID { get; }
        private string SessionKey { get; }
        internal PictureData Picture { get; }
        
        public SetAvatarOptions(Guid playerID, PictureData picture)
        {
            PlayerID = playerID;
            Picture = picture;
        }
        public SetAvatarOptions(string sessionKey, PictureData picture)
        {
            SessionKey = sessionKey;
            Picture = picture;
        }
        internal Dictionary<string, ByteArrayContent> BuildBinaryFormData()
        {
            var postedBinaryData = new Dictionary<string, ByteArrayContent>();
            if (Picture?.Bytes != null)
            {
                postedBinaryData.Add("pictureData", new ByteArrayContent(Picture.Bytes));
            }
            return postedBinaryData;
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (PlayerID.HasValue)
            {
                formData.Add("playerID", PlayerID.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }
            if (Picture.URL != null)
            {
                formData.Add("avatarURL", Picture.URL.ToString());
            }
            else if (!string.IsNullOrWhiteSpace(Picture.Base64))
            {
                formData.Add("avatar", Picture.Base64);
            }
            return formData;
        }
    }
}