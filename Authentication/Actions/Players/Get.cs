using System;
using System.Collections.Generic;
using ConstructServices.Authentication.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Get a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-player" />
        [UsedImplicitly]
        public GetPlayerResponse GetPlayer(GetPlayerOptions getPlayerOptions)
        {
            return Common.Request.ExecuteSyncRequest<GetPlayerResponse>(
                Config.EndPointPaths.Players.GetPlayer,
                service,
                getPlayerOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/get-player" />
        [UsedImplicitly]
        public async Task<GetPlayerResponse> GetPlayerAsync(GetPlayerOptions getPlayerOptions)
        {
            return await Common.Request.ExecuteAsyncRequest<GetPlayerResponse>(
                Config.EndPointPaths.Players.GetPlayer,
                service,
                getPlayerOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class GetPlayerOptions
    {
        private Guid? PlayerID { get; }
        private string PlayerName { get; }       
        
        public GetPlayerOptions(string playerName)
        {
            PlayerName = playerName;
        }
        public GetPlayerOptions(Guid playerID)
        {
            PlayerID = playerID;
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (PlayerID.HasValue)
            {
                formData.Add("playerID", PlayerID.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(PlayerName))
            {
                formData.Add("playerName", PlayerName);
            }
            return formData;
        }
    }
}