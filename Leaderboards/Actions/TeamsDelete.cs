using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    private const string DeleteTeamAPIPath = "/deleteteam.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public BaseResponse DeleteExistingTeam(string strTeamID)
        {
            var teamIDValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!teamIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(teamIDValidator.ErrorMessage, "Team ID"));
            }
            return service.DeleteExistingTeam(teamIDValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<BaseResponse> DeleteExistingTeamAsync(string strTeamID)
        {
            var teamIDValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!teamIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(teamIDValidator.ErrorMessage, "Team ID"));
            }
            return await service.DeleteExistingTeamAsync(teamIDValidator.ReturnedObject);
        }
        
        [UsedImplicitly]
        public BaseResponse DeleteExistingTeam(Guid teamID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                DeleteTeamAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() }
                }
            );
        }
        
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteExistingTeamAsync(Guid teamID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeleteTeamAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() }
                }
            );
        }
    }
}