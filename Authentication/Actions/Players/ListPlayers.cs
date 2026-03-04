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
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/list-players" />
        [UsedImplicitly]
        public GetPlayersResponse ListPlayers(GetPlayersOptions getPlayersOptions, PaginationOptions pagination)
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
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/list-players" />
        [UsedImplicitly]
        public async Task<GetPlayersResponse> ListPlayersAsync(GetPlayersOptions getPlayersOptions, PaginationOptions pagination)
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
    public sealed class GetPlayersOptions(List<Guid> playerIDs, PlayerOrdering? ordering = null)
    {
        private List<Guid> PlayerIDs { get; } = playerIDs;
        private PlayerOrdering? Ordering { get; } = ordering;

        public GetPlayersOptions(PlayerOrdering ordering) : this(null, ordering)
        {
        }
        public GetPlayersOptions(Guid playerID) : this([playerID])
        {
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