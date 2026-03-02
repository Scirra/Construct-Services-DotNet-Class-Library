using ConstructServices.Common;
using ConstructServices.Leaderboards.Enums;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    
    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public GetTeamsResponse GetAllTeams(GetTeamsOrdering ordering,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<GetTeamsResponse>(
                Config.EndPointPaths.Teams.List,
                service,
                new Dictionary<string, string>
                {
                    { "order", ordering.ToString() }
                },
                paginationOptions
            );
        }

        [UsedImplicitly]
        public async Task<GetTeamsResponse> GetAllTeamsAsync(GetTeamsOrdering ordering,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<GetTeamsResponse>(
                Config.EndPointPaths.Teams.List,
                service,
                new Dictionary<string, string>
                {
                    { "order", ordering.ToString() }
                },
                paginationOptions
            );
        }
    }
}