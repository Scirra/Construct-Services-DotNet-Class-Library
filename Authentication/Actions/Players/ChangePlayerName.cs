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
        /// Change a Players player name
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/change-player-name" />
        [UsedImplicitly]
        public BaseResponse ChangePlayerName(ChangePlayerNameOptions changePlayerNameOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.ChangePlayerName,
                service,
                changePlayerNameOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Change a Players player name
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/change-player-name" />
        [UsedImplicitly]
        public async Task<BaseResponse> ChangePlayerNameAsync(ChangePlayerNameOptions changePlayerNameOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.ChangePlayerName,
                service,
                changePlayerNameOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class ChangePlayerNameOptions
    {
        private Guid? PlayerID { get; }
        private string SessionKey { get; }         
        private string Name { get; }        
        
        public ChangePlayerNameOptions(string sessionKey, string name)
        {
            SessionKey = sessionKey;
            Name = name;
        }
        public ChangePlayerNameOptions(Guid playerID, string name)
        {
            PlayerID = playerID;
            Name = name;
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "playerName", Name }
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