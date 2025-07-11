using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    public static BaseResponse RefreshSession(
        this AuthenticationService service,
        string sessionKey)
    {
        const string path = "/refreshsession.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            }
        )).Result;
    }
}