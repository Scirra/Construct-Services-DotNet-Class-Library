using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse ChangePlayerName(Guid playerID,
            string newPlayerName)
        {
            const string path = "/changeplayername.json";

            return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "playerName", newPlayerName }
                }
            )).Result;
        }

        [UsedImplicitly]
        public BaseResponse ChangePlayerName(string sessionKey,
            string newPlayerName)
        {
            const string path = "/changeplayername.json";

            return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey },
                    { "playerName", newPlayerName }
                }
            )).Result;
        }
    }
}