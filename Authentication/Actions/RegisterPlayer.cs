using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Authentication.Responses;

namespace ConstructServices.Authentication.Actions;
public static partial class Players
{
    public static RegisterPlayerResponse RegisterPlayer(
        this AuthenticationService service,
        string playerName)
    {
        const string path = "/registerplayer.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<RegisterPlayerResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerName", playerName }
            }
        )).Result;
    }
    public static RegisterPlayerResponse RegisterPlayer(
        this AuthenticationService service,
        string playerName,
        string username,
        string password)
    {
        const string path = "/registerplayer.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<RegisterPlayerResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerName", playerName },
                { "username", username },
                { "password", password }
            }
        )).Result;
    }
}