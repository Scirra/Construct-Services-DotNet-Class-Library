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
        public GetPlayerResponse GetPlayer(GetPlayerOptions getPlayerOptions)
        {
            return Request.ExecuteSyncRequest<GetPlayerResponse>(
                Config.EndPointPaths.Players.GetPlayer,
                service,
                getPlayerOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-player" />
        [UsedImplicitly]
        public async Task<GetPlayerResponse> GetPlayerAsync(GetPlayerOptions getPlayerOptions)
        {
            return await Request.ExecuteAsyncRequest<GetPlayerResponse>(
                Config.EndPointPaths.Players.GetPlayer,
                service,
                getPlayerOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get expanded player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/list-players" />
        [UsedImplicitly]
        public GetExpandedPlayerResponse GetExpandedPlayer(Guid playerID)
        {
            var r = Request.ExecuteSyncRequest<GetPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                new GetPlayersOptions(playerID).BuildFormData()
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
            var r = await Request.ExecuteAsyncRequest<GetPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                new GetPlayersOptions(playerID).BuildFormData()
            );
            if (!r.Success)
            {
                return new GetExpandedPlayerResponse(r.ErrorMessage, r.ShouldRetry);
            }
            return new GetExpandedPlayerResponse(r.Players.SingleOrDefault());
        }

    }

    [UsedImplicitly]
    public sealed class GetPlayerOptions
    {
        private Guid? PlayerID { get; }
        private string PlayerName { get; }       
        
        public GetPlayerOptions(string playerName)
        {
            PlayerName = playerName;
        }
        public GetPlayerOptions(Guid playerID)
        {
            PlayerID = playerID;
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (PlayerID.HasValue)
            {
                formData.Add("playerID", PlayerID.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(PlayerName))
            {
                formData.Add("playerName", PlayerName);
            }
            return formData;
        }
    }
}