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
        /// Change a Players player name
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/change-player-name" />
        [UsedImplicitly]
        public BaseResponse ChangePlayerName(ChangePlayerNameOptions changePlayerNameOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.ChangePlayerName,
                service,
                changePlayerNameOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Change a Players player name
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/change-player-name" />
        [UsedImplicitly]
        public async Task<BaseResponse> ChangePlayerNameAsync(ChangePlayerNameOptions changePlayerNameOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.ChangePlayerName,
                service,
                changePlayerNameOptions.BuildFormData()
            );
        }
    }
}