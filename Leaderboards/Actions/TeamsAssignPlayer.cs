using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    private const string AssignPlayerToTeamAPIPath = "/getteam.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public BaseResponse AssignPlayerToTeam(
            string strTeamID,
            string strPlayerID)
        {
            var teamIDValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!teamIDValidator.Successfull)
            {
                return new GetTeamResponse(string.Format(teamIDValidator.ErrorMessage, "Team ID"));
            }
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(strPlayerID);
            if (!playerIDValidator.Successfull)
            {
                return new GetTeamResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"));
            }
            return service.AssignPlayerToTeam(teamIDValidator.ReturnedObject, playerIDValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<BaseResponse> AssignPlayerToTeamAsync(
            string strTeamID,
            string strPlayerID)
        {
            var teamIDValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!teamIDValidator.Successfull)
            {
                return new GetTeamResponse(string.Format(teamIDValidator.ErrorMessage, "Team ID"));
            }
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(strPlayerID);
            if (!playerIDValidator.Successfull)
            {
                return new GetTeamResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"));
            }
            return await service.AssignPlayerToTeamAsync(teamIDValidator.ReturnedObject, playerIDValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public BaseResponse AssignPlayerToTeam(
            Guid teamID,
            Guid playerID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                AssignPlayerToTeamAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() },
                    { "playerID", playerID.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> AssignPlayerToTeamAsync(
            Guid teamID,
            Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                AssignPlayerToTeamAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() },
                    { "playerID", playerID.ToString() }
                }
            );
        }
    }
}