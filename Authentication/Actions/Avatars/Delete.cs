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
        public BaseResponse DeleteAvatar(Guid playerID)
        {
            if (!playerID.IsValidGuid()) return new BaseResponse(Validations.InvalidGuidError);

            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.DeleteAvatar,
                service,
                new Dictionary<string, string>{{"playerID", playerID.ToString()}}
            );
        }

        /// <summary>
        /// Delete a players avatar
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/delete-avatar" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteAvatarAsync(Guid playerID)
        {
            if (!playerID.IsValidGuid()) return new BaseResponse(Validations.InvalidGuidError);

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.DeleteAvatar,
                service,
                new Dictionary<string, string>{{"playerID", playerID.ToString()}}
            );
        }
    }

    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Delete avatar
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/delete-avatar" />
        [UsedImplicitly]
        public BaseResponse DeleteAvatar()
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.DeleteAvatar,
                service
            );
        }

        /// <summary>
        /// Delete avatar
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/avatars/delete-avatar" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteAvatarAsync(Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Avatars.DeleteAvatar,
                service
            );
        }
    }
}