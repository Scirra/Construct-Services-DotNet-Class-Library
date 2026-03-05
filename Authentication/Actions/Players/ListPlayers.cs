using System;
using System.Collections.Generic;
using System.Linq;
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
        /// List Players
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/list-players" />
        [UsedImplicitly]
        public ListPlayersResponse ListPlayers(ListPlayersOptions getPlayersOptions, PaginationOptions pagination)
        {
            return Request.ExecuteSyncRequest<ListPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                getPlayersOptions.BuildFormData(),
                pagination
            );
        }

        /// <summary>
        /// List Players
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/list-players" />
        [UsedImplicitly]
        public async Task<ListPlayersResponse> ListPlayersAsync(ListPlayersOptions getPlayersOptions, PaginationOptions pagination)
        {
            return await Request.ExecuteAsyncRequest<ListPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                getPlayersOptions.BuildFormData(),
                pagination
            );
        }
    }

    [UsedImplicitly]
    public sealed class ListPlayersOptions
    {
        [UsedImplicitly]
        public List<Guid> PlayerIDs { private get; set; }

        [UsedImplicitly]
        public PlayerOrdering? Ordering { private get; set; }

        public ListPlayersOptions() { }
        internal ListPlayersOptions(Guid playerID)
        {
            PlayerIDs = [playerID];
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (PlayerIDs != null)
            {
                formData.Add("playerIDs", string.Join(",", PlayerIDs.Distinct()));
            }
            if (Ordering.HasValue)
            {
                formData.Add("order", Ordering.Value.ToString());
            }
            return formData;
        }
    }
}