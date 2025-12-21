using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    private const string CreateTeamAPIPath = "/createteam.json";
    
    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public CreateTeamResponse CreateNewTeam(string teamName)
        {
            var nameValidator = Common.Validations.TeamName.ValidateTeamName(teamName);
            if (!nameValidator.Successfull)
            {
                return new CreateTeamResponse(nameValidator.ErrorMessage);
            }

            return Request.ExecuteSyncRequest<CreateTeamResponse>(
                CreateTeamAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "teamName", teamName }
                }
            );
        }

        [UsedImplicitly]
        public async Task<CreateTeamResponse> CreateNewTeamAsync(string teamName)
        {
            var nameValidator = Common.Validations.TeamName.ValidateTeamName(teamName);
            if (!nameValidator.Successfull)
            {
                return new CreateTeamResponse(nameValidator.ErrorMessage);
            }

            return await Request.ExecuteAsyncRequest<CreateTeamResponse>(
                CreateTeamAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "teamName", teamName }
                }
            );
        }
    }
}