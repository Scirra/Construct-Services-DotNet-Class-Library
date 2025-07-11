using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    public static GetSessionResponse GetSession(
        this AuthenticationService service,
        string sessionKey)
    {
        const string path = "/getsession.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<GetSessionResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            }
        )).Result;
    }
}