using System;
using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public GetPlayerResponse GetPlayer(string playerName)
        {
            const string path = "/getplayer.json";

            return Common.Request.ExecuteSyncRequest<GetPlayerResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "playerName", playerName }
                }
            );
        }

        [UsedImplicitly]
        public GetPlayerResponse GetPlayer(Guid playerID)
        {
            const string path = "/getplayer.json";

            return Common.Request.ExecuteSyncRequest<GetPlayerResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() }
                }
            );
        }
    }
}