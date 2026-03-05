using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Set a Players email address
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-email-address" />
        [UsedImplicitly]
        public BaseResponse SetEmailAddress(Guid playerID, string newEmailAddress)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetEmailAddress,
                service,
                SetEmailAddressOptions.BuildFormData(playerID, newEmailAddress)
            );
        }

        /// <summary>
        /// Set a Players email address
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-email-address" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetEmailAddressAsync(Guid playerID, string newEmailAddress)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetEmailAddress,
                service,
                SetEmailAddressOptions.BuildFormData(playerID, newEmailAddress)
            );
        }        
    }

    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Set email address
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-email-address" />
        [UsedImplicitly]
        public BaseResponse SetEmailAddress(string newEmailAddress)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetEmailAddress,
                service,
                SetEmailAddressOptions.BuildFormData(newEmailAddress)
            );
        }

        /// <summary>
        /// Set email address
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-email-address" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetEmailAddressAsync(string newEmailAddress)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetEmailAddress,
                service,
                SetEmailAddressOptions.BuildFormData(newEmailAddress)
            );
        }        
    }

    private static class SetEmailAddressOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid playerID, string newEmailAddress)
        {
            return new Dictionary<string, string>
            {
                { "emailAddress", newEmailAddress },
                { "playerID", playerID.ToString() }
            };
        }
        internal static Dictionary<string, string> BuildFormData(string newEmailAddress)
        {
            return new Dictionary<string, string>
            {
                { "emailAddress", newEmailAddress }
            };
        }
    }
}
