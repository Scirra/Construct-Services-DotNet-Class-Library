using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Sets a Players username and password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public BaseResponse SetUsernameAndPassword(SetUsernameAndPasswordOptions setUsernameAndPasswordOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                setUsernameAndPasswordOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Sets a Players username and password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetUsernameAndPasswordAsync(SetUsernameAndPasswordOptions setUsernameAndPasswordOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                setUsernameAndPasswordOptions.BuildFormData()
            );
        }
    }
}
