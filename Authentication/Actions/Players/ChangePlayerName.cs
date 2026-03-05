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
        public BaseResponse ChangePlayerName(Guid playerID, string playerName)
        {
            var playerNameValidation = Common.Validations.Authentication.Functions.IsPlayerNameValid(playerName);
            if (!playerNameValidation.Valid) return new BaseResponse(playerNameValidation.ErrorMessage);

            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.ChangePlayerName,
                service,
                ChangePlayerNameOptions.BuildFormData(playerID, playerName)
            );
        }

        /// <summary>
        /// Change a Players player name
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/change-player-name" />
        [UsedImplicitly]
        public async Task<BaseResponse> ChangePlayerNameAsync(Guid playerID, string playerName)
        {
            var playerNameValidation = Common.Validations.Authentication.Functions.IsPlayerNameValid(playerName);
            if (!playerNameValidation.Valid) return new BaseResponse(playerNameValidation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.ChangePlayerName,
                service,
                ChangePlayerNameOptions.BuildFormData(playerID, playerName)
            );
        }
    }

    extension(PlayerAuthenticationService service)
    {
        /// <summary>
        /// Change player name
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/change-player-name" />
        [UsedImplicitly]
        public BaseResponse ChangePlayerName(string playerName)
        {
            var playerNameValidation = Common.Validations.Authentication.Functions.IsPlayerNameValid(playerName);
            if (!playerNameValidation.Valid) return new BaseResponse(playerNameValidation.ErrorMessage);

            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.ChangePlayerName,
                service,
                ChangePlayerNameOptions.BuildFormData(playerName)
            );
        }

        /// <summary>
        /// Change player name
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/change-player-name" />
        [UsedImplicitly]
        public async Task<BaseResponse> ChangePlayerNameAsync(string playerName)
        {
            var playerNameValidation = Common.Validations.Authentication.Functions.IsPlayerNameValid(playerName);
            if (!playerNameValidation.Valid) return new BaseResponse(playerNameValidation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.ChangePlayerName,
                service,
                ChangePlayerNameOptions.BuildFormData(playerName)
            );
        }
    }

    private static class ChangePlayerNameOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid playerID, string playerName)
        {
            return new Dictionary<string, string>
            {
                { "playerName", playerName },
                { "playerID", playerID.ToString() }
            };
        }
        internal static Dictionary<string, string> BuildFormData(string playerName)
        {
            return new Dictionary<string, string>
            {
                { "playerName", playerName }
            };
        }
    }
}