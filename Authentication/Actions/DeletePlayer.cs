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
        public BaseResponse DeletePlayer(Guid playerID)
        {
            const string path = "/deleteplayer.json";

            return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() }
                }
            )).Result;
        }

        [UsedImplicitly]
        public BaseResponse DeletePlayer(string sessionKey)
        {
            const string path = "/deleteplayer.json";

            return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey }
                }
            )).Result;
        }
    }
}