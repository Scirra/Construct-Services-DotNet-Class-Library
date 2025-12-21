using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    private const string RemoveTeamPlayerAPIEndPoint = "/removeplayerfromteam.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public BaseResponse RemovePlayerFromTeam(
            string strTeamID,
            string strPlayerID)
        {
            var teamIDValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!teamIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(teamIDValidator.ErrorMessage, "Team ID"));
            }
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(strPlayerID);
            if (!playerIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"));
            }
            return service.RemovePlayerFromTeam(teamIDValidator.ReturnedObject, playerIDValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<BaseResponse> RemovePlayerFromTeamAsync(
            string strTeamID,
            string strPlayerID)
        {
            var teamIDValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!teamIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(teamIDValidator.ErrorMessage, "Team ID"));
            }
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(strPlayerID);
            if (!playerIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"));
            }
            return await service.RemovePlayerFromTeamAsync(teamIDValidator.ReturnedObject, playerIDValidator.ReturnedObject);
        }
        
        [UsedImplicitly]
        public BaseResponse RemovePlayerFromTeam(
            Guid teamID,
            Guid playerID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                RemoveTeamPlayerAPIEndPoint,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() },
                    { "playerID", playerID.ToString() }
                }
            );
        }
        
        [UsedImplicitly]
        public async Task<BaseResponse> RemovePlayerFromTeamAsync(
            Guid teamID,
            Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                RemoveTeamPlayerAPIEndPoint,
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