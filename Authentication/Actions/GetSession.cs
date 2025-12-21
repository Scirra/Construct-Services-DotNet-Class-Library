using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static GetSessionResponse GetSession(
        this AuthenticationService service,
        string sessionKey)
    {
        const string path = "/getsession.json";

        return Task.Run(() => Common.Request.ExecuteRequest<GetSessionResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            }
        )).Result;
    }
}