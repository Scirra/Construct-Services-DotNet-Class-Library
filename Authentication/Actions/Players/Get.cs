using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Get a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-player" />
        [UsedImplicitly]
        public GetPlayerResponse GetPlayer(string playerName)
        {
            var playerNameValidation = Common.Validations.Authentication.Functions.IsPlayerNameValid(playerName);
            if (!playerNameValidation.Valid) return new GetPlayerResponse(playerNameValidation.ErrorMessage);

            return Request.ExecuteSyncRequest<GetPlayerResponse>(
                Config.EndPointPaths.Players.GetPlayer,
                service,
                GetPlayerOptions.BuildFormData(playerName)
            );
        }

        /// <summary>
        /// Get a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-player" />
        [UsedImplicitly]
        public async Task<GetPlayerResponse> GetPlayerAsync(string playerName)
        {
            var playerNameValidation = Common.Validations.Authentication.Functions.IsPlayerNameValid(playerName);
            if (!playerNameValidation.Valid) return new GetPlayerResponse(playerNameValidation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<GetPlayerResponse>(
                Config.EndPointPaths.Players.GetPlayer,
                service,
                GetPlayerOptions.BuildFormData(playerName)
            );
        }

        /// <summary>
        /// Get a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-player" />
        [UsedImplicitly]
        public GetPlayerResponse GetPlayer(Guid playerID)
        {
            return Request.ExecuteSyncRequest<GetPlayerResponse>(
                Config.EndPointPaths.Players.GetPlayer,
                service,
                GetPlayerOptions.BuildFormData(playerID)
            );
        }

        /// <summary>
        /// Get a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-player" />
        [UsedImplicitly]
        public async Task<GetPlayerResponse> GetPlayerAsync(Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<GetPlayerResponse>(
                Config.EndPointPaths.Players.GetPlayer,
                service,
                GetPlayerOptions.BuildFormData(playerID)
            );
        }

        /// <summary>
        /// Get expanded player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/list-players" />
        [UsedImplicitly]
        public GetExpandedPlayerResponse GetExpandedPlayer(Guid playerID)
        {
            var r = Request.ExecuteSyncRequest<ListPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                new ListPlayersOptions(playerID).BuildFormData()
            );
            if (!r.Success)
            {
                return new GetExpandedPlayerResponse(r.ErrorMessage, r.ShouldRetry);
            }
            return new GetExpandedPlayerResponse(r.Players.SingleOrDefault());
        }

        /// <summary>
        /// Get expanded player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/list-players" />
        [UsedImplicitly]
        public async Task<GetExpandedPlayerResponse> GetExpandedPlayerAsync(Guid playerID)
        {
            var r = await Request.ExecuteAsyncRequest<ListPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                new ListPlayersOptions(playerID).BuildFormData()
            );
            if (!r.Success)
            {
                return new GetExpandedPlayerResponse(r.ErrorMessage, r.ShouldRetry);
            }
            return new GetExpandedPlayerResponse(r.Players.SingleOrDefault());
        }
    }

    internal static class GetPlayerOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid playerID)
        {
            return new Dictionary<string, string> { { "playerID", playerID.ToString() } };
        }
        internal static Dictionary<string, string> BuildFormData(string playerName)
        {
            return new Dictionary<string, string> { { "playerName", playerName } };
        }
    }
}