using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Leaderboards.Enums;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    extension(LeaderboardService service)
    {
        /// <summary>
        /// List all Teams
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/get-teams" />
        [UsedImplicitly]
        public GetTeamsResponse ListTeams(
            ListTeamOptions listTeamOptions,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<GetTeamsResponse>(
                Config.EndPointPaths.Teams.List,
                service,
                listTeamOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List all Teams
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/get-teams" />
        [UsedImplicitly]
        public async Task<GetTeamsResponse> ListTeamsAsync(
            ListTeamOptions listTeamOptions,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<GetTeamsResponse>(
                Config.EndPointPaths.Teams.List,
                service,
                listTeamOptions.BuildFormData(),
                paginationOptions
            );
        }
    }

    [UsedImplicitly]
    public sealed class ListTeamOptions
    {
        private GetTeamsOrdering? Ordering { get; }
    
        public ListTeamOptions(GetTeamsOrdering ordering)
        {
            Ordering = ordering;
        } 
        public ListTeamOptions()
        {
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (Ordering.HasValue) formData.Add("order", Ordering.Value.ToString());
            return formData;
        }
    }
}