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
        public GetTeamResponse GetTeam(string strTeamID)
        {
            if (string.IsNullOrWhiteSpace(strTeamID))
                return new GetTeamResponse("No Team ID was provided.", false);
            if (!Guid.TryParse(strTeamID, out var teamID))
                return new GetTeamResponse("Team ID was not a valid GUID.", false);
            return GetTeam(service, teamID);
        }
        
        [UsedImplicitly]
        public GetTeamResponse GetTeam(Guid teamID)
        {
            const string path = "/getteam.json";
            var formData = new Dictionary<string, string>
            {
                { "teamID", teamID.ToString() }
            };
            return Task.Run(() => Request.ExecuteRequest<GetTeamResponse>(
                path,
                service,
                formData
            )).Result;
        }
    }
}