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
        /// Change a Players username
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public BaseResponse ChangeUsername(ChangeUsernameOptions changeUsernameOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                changeUsernameOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Change a Players username
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public async Task<BaseResponse> ChangeUsernameAsync(ChangeUsernameOptions changeUsernameOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                changeUsernameOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class ChangeUsernameOptions
    {
        private Guid? PlayerID { get; }
        private string SessionKey { get; }         
        private string NewUsername { get; }        
        
        public ChangeUsernameOptions(string sessionKey, string newUsername)
        {
            SessionKey = sessionKey;
            NewUsername = newUsername;
        }
        public ChangeUsernameOptions(Guid playerID, string newUsername)
        {
            PlayerID = playerID;
            NewUsername = newUsername;
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "username", NewUsername }
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