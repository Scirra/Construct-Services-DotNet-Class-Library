using System;
using System.Collections.Generic;
using ConstructServices.Leaderboards.Responses;
using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Enums;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    extension(LeaderboardService service)
    {
        /// <summary>
        /// List all Players on an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/team-players" />
        [UsedImplicitly]
        public GetTeamPlayersResponse ListTeamPlayers(
            ListTeamPlayersOptions listTeamPlayersOptions,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<GetTeamPlayersResponse>(
                Config.EndPointPaths.Teams.ListPlayers,
                service,
                listTeamPlayersOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List all Players on an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/team-players" />
        [UsedImplicitly]
        public async Task<GetTeamPlayersResponse> ListTeamPlayersAsync(
            ListTeamPlayersOptions listTeamPlayersOptions,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<GetTeamPlayersResponse>(
                Config.EndPointPaths.Teams.ListPlayers,
                service,
                listTeamPlayersOptions.BuildFormData(),
                paginationOptions
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class ListTeamPlayersOptions
    {
        private Guid TeamID { get; }
        private TeamPlayersOrdering? Ordering { get; }
    
        public ListTeamPlayersOptions(Guid teamID, TeamPlayersOrdering ordering)
        {
            TeamID = teamID;
            Ordering = ordering;
        } 
        public ListTeamPlayersOptions(Guid teamID)
        {
            TeamID = teamID;
        } 

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", TeamID.ToString() }
            };
            if (Ordering.HasValue) formData.Add("order", Ordering.Value.ToString());
            return formData;
        }
    }
}