using ConstructServices.Authentication.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string GetPlayerAPIPath = "/getplayer.json";

    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public GetPlayerResponse GetPlayer(string playerName)
        {
            var validator = Common.Validations.PlayerName.ValidatePlayerName(playerName);
            if (!validator.Successfull)
            {
                return new GetPlayerResponse(validator.ErrorMessage, false);
            }
            return Common.Request.ExecuteSyncRequest<GetPlayerResponse>(
                GetPlayerAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerName", playerName }
                }
            );
        }

        [UsedImplicitly]
        public async Task<GetPlayerResponse> GetPlayerAsync(string playerName)
        {
            var validator = Common.Validations.PlayerName.ValidatePlayerName(playerName);
            if (!validator.Successfull)
            {
                return new GetPlayerResponse(validator.ErrorMessage, false);
            }
            return await Common.Request.ExecuteAsyncRequest<GetPlayerResponse>(
                GetPlayerAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerName", playerName }
                }
            );
        }

        [UsedImplicitly]
        public GetPlayerResponse GetPlayer(Guid playerID)
        {
            return Common.Request.ExecuteSyncRequest<GetPlayerResponse>(
                GetPlayerAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public async Task<GetPlayerResponse> GetPlayerAsync(Guid playerID)
        {
            return await Common.Request.ExecuteAsyncRequest<GetPlayerResponse>(
                GetPlayerAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() }
                }
            );
        }
    }
}