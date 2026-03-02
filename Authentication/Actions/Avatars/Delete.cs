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

    [UsedImplicitly]
    public sealed class DeleteAvatarOptions
    {    
        private Guid? PlayerID { get; }
        private string SessionKey { get; }
        
        public DeleteAvatarOptions(Guid playerID)
        {
            PlayerID = playerID;
        }
        public DeleteAvatarOptions(string sessionKey)
        {
            SessionKey = sessionKey;
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
            return formData;
        }
    }
}