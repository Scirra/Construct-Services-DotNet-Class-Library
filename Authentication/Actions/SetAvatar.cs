using ConstructServices.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string SetAvatarAPIPath = "/setavatar.json";
    
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse SetAvatar(
            string sessionKey,
            PictureData picture)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage, false);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            };

            if (picture.Bytes != null)
            {
                return Request.ExecuteMultiPartFormSyncRequest<BaseResponse>(
                    SetAvatarAPIPath,
                    service,
                    formData,
                    new Dictionary<string, ByteArrayContent>{ {"picture", new ByteArrayContent(picture.Bytes) } }
                );
            }
            if (picture.URL != null)
            {
                formData.Add("avatarURL", picture.URL.ToString());
            }
            else if (!string.IsNullOrWhiteSpace(picture.Base64))
            {
                formData.Add("avatar", picture.Base64);
            }
            else
            {
                return new BaseResponse("No picture data in request.", false);
            }
            return Request.ExecuteSyncRequest<BaseResponse>(
                SetAvatarAPIPath,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> SetAvatarAsync(
            string sessionKey,
            PictureData picture)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new BaseResponse(sessionKeyValidator.ErrorMessage, false);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            };

            if (picture.Bytes != null)
            {
                return await Request.ExecuteMultiPartFormAsyncRequest<BaseResponse>(
                    SetAvatarAPIPath,
                    service,
                    formData,
                    new Dictionary<string, ByteArrayContent>{ {"picture", new ByteArrayContent(picture.Bytes) } }
                );
            }
            if (picture.URL != null)
            {
                formData.Add("avatarURL", picture.URL.ToString());
            }
            else if (!string.IsNullOrWhiteSpace(picture.Base64))
            {
                formData.Add("avatar", picture.Base64);
            }
            else
            {
                return new BaseResponse("No picture data in request.", false);
            }
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                SetAvatarAPIPath,
                service,
                formData
            );
        }
    }
}