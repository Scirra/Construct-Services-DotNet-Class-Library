using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string SetEmailAddressAPIPath = "/setemailaddress.json";

    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse RemoveEmailAddress(string sessionKey)
            => service.SetEmailAddress(sessionKey, string.Empty);

        [UsedImplicitly]
        public BaseResponse SetEmailAddress(
            string sessionKey,
            string emailAddress)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                SetEmailAddressAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey },
                    { "emailAddress", emailAddress }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> RemoveEmailAddressAsync(string sessionKey)
            => await service.SetEmailAddressAsync(sessionKey, string.Empty);

        [UsedImplicitly]
        public async Task<BaseResponse> SetEmailAddressAsync(
            string sessionKey,
            string emailAddress)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                SetEmailAddressAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "sessionKey", sessionKey },
                    { "emailAddress", emailAddress }
                }
            );
        }

        [UsedImplicitly]
        public BaseResponse RemoveEmailAddress(Guid playerID)
            => service.SetEmailAddress(playerID, string.Empty);

        [UsedImplicitly]
        public BaseResponse SetEmailAddress(
            Guid playerID,
            string emailAddress)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                SetEmailAddressAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "emailAddress", emailAddress }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> RemoveEmailAddressAsync(Guid playerID)
            => await service.SetEmailAddressAsync(playerID, string.Empty);

        [UsedImplicitly]
        public async Task<BaseResponse> SetEmailAddressAsync(
            Guid playerID,
            string emailAddress)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                SetEmailAddressAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "emailAddress", emailAddress }
                }
            );
        }        
    }
}
