using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Authentication.Objects;

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
        public BaseResponse SetEmailAddress(SetEmailAddressOptions setEmailAddressOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetEmailAddress,
                service,
                setEmailAddressOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Set a Players email address
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-email-address" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetEmailAddressAsync(SetEmailAddressOptions setEmailAddressOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetEmailAddress,
                service,
                setEmailAddressOptions.BuildFormData()
            );
        }        
    }
}
