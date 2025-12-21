using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    [UsedImplicitly]
    public static CreateTeamResponse CreateNewTeam(
        this LeaderboardService service,
        string teamName)
    {
        const string path = "/createteam.json";
        return Request.ExecuteSyncRequest<CreateTeamResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "teamName", teamName }
            }
        );
    }
}