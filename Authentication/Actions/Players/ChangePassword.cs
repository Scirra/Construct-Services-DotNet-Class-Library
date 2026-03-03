using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

[UsedImplicitly]
public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Change a Players password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public BaseResponse ChangePassword(ChangePasswordOptions changePasswordOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                changePasswordOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Change a Players password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public async Task<BaseResponse> ChangePasswordAsync(ChangePasswordOptions changePasswordOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                changePasswordOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class ChangePasswordOptions
    {
        private Guid? PlayerID { get; }
        private string SessionKey { get; }         
        private string NewPassword { get; }        
        
        public ChangePasswordOptions(string sessionKey, string newPassword)
        {
            SessionKey = sessionKey;
            NewPassword = newPassword;
        }
        public ChangePasswordOptions(Guid playerID, string newPassword)
        {
            PlayerID = playerID;
            NewPassword = newPassword;
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "password", NewPassword }
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