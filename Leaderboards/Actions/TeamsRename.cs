using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    private const string RenameTeamAPIEndPoint = "/renameteam.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public BaseResponse RenameTeam(
            string strTeamID,
            string teamName)
        {
            var teamIDValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!teamIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(teamIDValidator.ErrorMessage, "Team ID"));
            }
            return service.RenameTeam(teamIDValidator.ReturnedObject, teamName);
        }

        [UsedImplicitly]
        public async Task<BaseResponse> RenameTeamAsync(
            string strTeamID,
            string teamName)
        {
            var teamIDValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!teamIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(teamIDValidator.ErrorMessage, "Team ID"));
            }
            return await service.RenameTeamAsync(teamIDValidator.ReturnedObject, teamName);
        }
        
        [UsedImplicitly] 
        public BaseResponse RenameTeam(
            Guid teamID,
            string teamName)
        {
            var teamNameValidator = Common.Validations.TeamName.ValidateTeamName(teamName);
            if (!teamNameValidator.Successfull)
            {
                return new BaseResponse(teamNameValidator.ErrorMessage);
            }

            return Request.ExecuteSyncRequest<BaseResponse>(
                RenameTeamAPIEndPoint,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() },
                    { "teamName", teamName }
                }
            );
        }
        
        [UsedImplicitly] 
        public async Task<BaseResponse> RenameTeamAsync(
            Guid teamID,
            string teamName)
        {
            var teamNameValidator = Common.Validations.TeamName.ValidateTeamName(teamName);
            if (!teamNameValidator.Successfull)
            {
                return new BaseResponse(teamNameValidator.ErrorMessage);
            }

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                RenameTeamAPIEndPoint,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() },
                    { "teamName", teamName }
                }
            );
        }
    }
}