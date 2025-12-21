using System;
using System.Collections.Generic;
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

            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "playerName", newPlayerName }
                }
            );
        }

        [UsedImplicitly]
        public BaseResponse ChangePlayerName(string sessionKey,
            string newPlayerName)
        {
            const string path = "/changeplayername.json";

            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey },
                    { "playerName", newPlayerName }
                }
            );
        }
    }
}