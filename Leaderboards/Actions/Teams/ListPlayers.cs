using System;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    
    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public GetTeamPlayersResponse GetTeamPlayers(PaginationOptions paginationOptions,
            string strTeamID,
            string order = null)
        {
            var teamIDValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!teamIDValidator.Successfull)
            {
                return new GetTeamPlayersResponse(string.Format(teamIDValidator.ErrorMessage, "Team ID"));
            }
            return service.GetTeamPlayers(paginationOptions, teamIDValidator.ReturnedObject, order);
        }

        [UsedImplicitly]
        public async Task<GetTeamPlayersResponse> GetTeamPlayersAsync(PaginationOptions paginationOptions,
            string strTeamID,
            string order = null)
        {
            var teamIDValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!teamIDValidator.Successfull)
            {
                return new GetTeamPlayersResponse(string.Format(teamIDValidator.ErrorMessage, "Team ID"));
            }
            return await service.GetTeamPlayersAsync(paginationOptions, teamIDValidator.ReturnedObject, order);
        }

        [UsedImplicitly]
        public GetTeamPlayersResponse GetTeamPlayers(PaginationOptions paginationOptions,
            Guid teamID,
            string order = null)
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", teamID.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(order))
            {
                formData.Add("order", order);
            }
            return Request.ExecuteSyncRequest<GetTeamPlayersResponse>(
                Config.EndPointPaths.Teams.ListPlayers,
                service,
                formData,
                paginationOptions
            );
        }

        [UsedImplicitly]
        public async Task<GetTeamPlayersResponse> GetTeamPlayersAsync(PaginationOptions paginationOptions,
            Guid teamID,
            string order = null)
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", teamID.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(order))
            {
                formData.Add("order", order);
            }
            return await Request.ExecuteAsyncRequest<GetTeamPlayersResponse>(
                Config.EndPointPaths.Teams.ListPlayers,
                service,
                formData,
                paginationOptions
            );
        }
    }
}