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
        public BaseResponse DeleteAvatar(Guid playerID)
        {
            const string path = "/deleteavatar.json";

            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public BaseResponse DeleteAvatar(string sessionKey)
        {
            const string path = "/deleteavatar.json";

            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            );
        }
    }
}