using ConstructServices.Authentication.Enums;
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
        [UsedImplicitly]
        public GetPlayersResponse GetPlayers(
            PlayerOrdering ordering,
            PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>
            {
                { "order", ordering.ToString() }
            };

            return Request.ExecuteSyncRequest<GetPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                formData,
                paginationOptions
            );
        }

        [UsedImplicitly]
        public async Task<GetPlayersResponse> GetPlayersAsync(
            PlayerOrdering ordering,
            PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>
            {
                { "order", ordering.ToString() }
            };

            return await Request.ExecuteAsyncRequest<GetPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                formData,
                paginationOptions
            );
        }
        
        [UsedImplicitly]
        public GetPlayersResponse GetPlayers(Guid playerID)
            => service.GetPlayers([playerID]);

        [UsedImplicitly]
        public async Task<GetPlayersResponse> GetPlayersAsync(Guid playerID)
            => await service.GetPlayersAsync([playerID]);

        [UsedImplicitly]
        public GetPlayersResponse GetPlayers(List<Guid> playerIDs)
        {
            if (!playerIDs.Any())
            {
                return new GetPlayersResponse("No player ID's provided.");
            }

            var formData = new Dictionary<string, string>
            {
                { "playerIDs", string.Join(",", playerIDs) }
            };
            return Request.ExecuteSyncRequest<GetPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<GetPlayersResponse> GetPlayersAsync(List<Guid> playerIDs)
        {
            if (!playerIDs.Any())
            {
                return new GetPlayersResponse("No player ID's provided.");
            }

            var formData = new Dictionary<string, string>
            {
                { "playerIDs", string.Join(",", playerIDs) }
            };
            return await Request.ExecuteAsyncRequest<GetPlayersResponse>(
                Config.EndPointPaths.Players.ListPlayers,
                service,
                formData
            );
        }
    }
}