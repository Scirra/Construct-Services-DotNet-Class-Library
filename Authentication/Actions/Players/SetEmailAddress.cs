using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Set a Players email address
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-email-address" />
        [UsedImplicitly]
        public BaseResponse SetEmailAddress(SetEmailAddressOptions setEmailAddressOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetEmailAddress,
                service,
                setEmailAddressOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Set a Players email address
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-email-address" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetEmailAddressAsync(SetEmailAddressOptions setEmailAddressOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetEmailAddress,
                service,
                setEmailAddressOptions.BuildFormData()
            );
        }        
    }

    [UsedImplicitly]
    public sealed class SetEmailAddressOptions
    {
        private Guid? PlayerID { get; }
        private string SessionKey { get; }         
        private string EmailAddress { get; }        
        
        public SetEmailAddressOptions(string sessionKey, string emailAddress)
        {
            SessionKey = sessionKey;
            EmailAddress = emailAddress;
        }
        public SetEmailAddressOptions(Guid playerID, string emailAddress)
        {
            PlayerID = playerID;
            EmailAddress = emailAddress;
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "emailAddress", EmailAddress }
            };
            if (PlayerID.HasValue)
            {
                formData.Add("playerID", PlayerID.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }
            return formData;
        }
    }
}
