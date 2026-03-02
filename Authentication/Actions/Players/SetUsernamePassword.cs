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
        /// Sets a Players username and password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public BaseResponse SetUsernameAndPassword(SetUsernameAndPasswordOptions setUsernameAndPasswordOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                setUsernameAndPasswordOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Sets a Players username and password
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-username-password" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetUsernameAndPasswordAsync(SetUsernameAndPasswordOptions setUsernameAndPasswordOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetUsernamePassword,
                service,
                setUsernameAndPasswordOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class SetUsernameAndPasswordOptions
    {
        private Guid? PlayerID { get; }
        private string SessionKey { get; }         
        private string Username { get; }      
        private string Password { get; }       
        
        public SetUsernameAndPasswordOptions(string sessionKey, string username, string password)
        {
            SessionKey = sessionKey;
            Username = username;
            Password = password;
        }
        public SetUsernameAndPasswordOptions(Guid playerID, string username, string password)
        {
            PlayerID = playerID;
            Username = username;
            Password = password;
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "username", Username },
                { "password", Password }
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
