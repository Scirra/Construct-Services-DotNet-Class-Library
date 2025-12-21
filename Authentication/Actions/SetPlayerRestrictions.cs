using ConstructServices.Authentication.Enums;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static BaseResponse SetPlayerRestrictions(
        this AuthenticationService service,
        Guid playerID,
        List<PlayerRestriction> actions)
    {
        const string path = "/setplayerrestrictions.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() },
                { "restrictedActions", string.Join(",", actions.Select(c=> (int)c)) }
            }
        )).Result;
    }
}
