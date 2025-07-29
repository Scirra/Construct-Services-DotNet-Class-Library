using System;
using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static GetPlayerResponse GetPlayer(
        this AuthenticationService service,
        string playerName)
    {
        const string path = "/getplayer.json";

        return Task.Run(() => Common.Request.ExecuteRequest<GetPlayerResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerName", playerName }
            }
        )).Result;
    }
    [UsedImplicitly]
    public static GetPlayerResponse GetPlayer(
        this AuthenticationService service,
        Guid playerID)
    {
        const string path = "/getplayer.json";

        return Task.Run(() => Common.Request.ExecuteRequest<GetPlayerResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() }
            }
        )).Result;
    }
}