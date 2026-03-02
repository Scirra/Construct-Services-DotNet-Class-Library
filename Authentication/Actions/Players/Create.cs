using ConstructServices.Authentication.Objects;
using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;
public static partial class Players
{

    extension(AuthenticationService service)
    {
        /// <summary>
        /// Create a new Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/register-player" />
        [UsedImplicitly]
        public RegisterPlayerResponse CreatePlayer(CreatePlayerOptions createPlayerOptions)
        {
            return Request.ExecuteSyncRequest<RegisterPlayerResponse>(
                Config.EndPointPaths.Players.Register,
                service,
                createPlayerOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Create a new Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/register-player" />
        [UsedImplicitly]
        public async Task<RegisterPlayerResponse> CreatePlayerAsync(CreatePlayerOptions createPlayerOptions)
        {
            return await Request.ExecuteAsyncRequest<RegisterPlayerResponse>(
                Config.EndPointPaths.Players.Register,
                service,
                createPlayerOptions.BuildFormData()
            );
        }
    }
}