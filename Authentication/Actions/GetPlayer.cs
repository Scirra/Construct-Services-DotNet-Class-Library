using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Authentication.Responses;

namespace ConstructServices.Authentication.Actions
{
    public static partial class Players
    {
        public static GetPlayerResponse GetPlayer(
            this AuthenticationService service,
            string username)
        {
            const string path = "/getplayer.json";

            return Task.Run(() => Request.ExecuteAuthenticationRequest<GetPlayerResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "username", username },
                }
            )).Result;
        }
    }
}
