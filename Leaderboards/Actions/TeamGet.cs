using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    private const string GetTeamAPIPath = "/getteam.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public GetTeamResponse GetTeam(string strTeamID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!idValidator.Successfull)
            {
                return new GetTeamResponse(string.Format(idValidator.ErrorMessage, "Team ID"));
            }
            return service.GetTeam(idValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<GetTeamResponse> GetTeamAsync(string strTeamID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strTeamID);
            if (!idValidator.Successfull)
            {
                return new GetTeamResponse(string.Format(idValidator.ErrorMessage, "Team ID"));
            }
            return await service.GetTeamAsync(idValidator.ReturnedObject);
        }
        
        [UsedImplicitly]
        public GetTeamResponse GetTeam(Guid teamID)
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", teamID.ToString() }
            };
            return Request.ExecuteSyncRequest<GetTeamResponse>(
                GetTeamAPIPath,
                service,
                formData
            );
        }
        
        [UsedImplicitly]
        public async Task<GetTeamResponse> GetTeamAsync(Guid teamID)
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", teamID.ToString() }
            };
            return await Request.ExecuteAsyncRequest<GetTeamResponse>(
                GetTeamAPIPath,
                service,
                formData
            );
        }
    }
}