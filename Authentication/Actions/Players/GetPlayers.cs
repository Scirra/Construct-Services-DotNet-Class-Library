using System;
using System.Collections.Generic;
using ConstructServices.Authentication.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Authentication.Enums;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Get multiple Players
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-players" />
        [UsedImplicitly]
        public GetPlayersResponse GetPlayers(GetPlayersOptions getPlayersOptions, PaginationOptions pagination = null)
        {
            return Request.ExecuteSyncRequest<GetPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                getPlayersOptions.BuildFormData(),
                pagination
            );
        }

        /// <summary>
        /// Get multiple Players
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-players" />
        [UsedImplicitly]
        public async Task<GetPlayersResponse> GetPlayersAsync(GetPlayersOptions getPlayersOptions, PaginationOptions pagination = null)
        {
            return await Request.ExecuteAsyncRequest<GetPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                getPlayersOptions.BuildFormData(),
                pagination
            );
        }
    }

    [UsedImplicitly]
    public sealed class GetPlayersOptions
    {
        private List<Guid> PlayerIDs { get; }    
        private PlayerOrdering? Ordering { get; }
        
        public GetPlayersOptions(List<Guid> playerIDs, PlayerOrdering? ordering = null)
        {
            PlayerIDs = playerIDs;
            Ordering = ordering;
        }
        public GetPlayersOptions(PlayerOrdering ordering)
        {
            Ordering = ordering;
        }
        public GetPlayersOptions(Guid playerID)
        {
            PlayerIDs = [playerID];
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (PlayerIDs != null)
            {
                formData.Add("playerIDs", string.Join(",", PlayerIDs));
            }
            if (Ordering.HasValue)
            {
                formData.Add("order", Ordering.Value.ToString());
            }
            return formData;
        }
    }
}