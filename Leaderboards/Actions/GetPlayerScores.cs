using System;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    private const string GetPlayerScoresAPIPath = "/getplayerscores.json";
    
    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public GetScoreResponse GetPlayerScores(string playerID,
            PaginationOptions paginationOptions)
        {
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!playerIDValidator.Successfull)
            {
                return new GetScoreResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"));
            }
            return service.GetPlayerScores(playerIDValidator.ReturnedObject, paginationOptions);
        }

        [UsedImplicitly]
        public async Task<GetScoreResponse> GetPlayerScoresAsync(string playerID,
            PaginationOptions paginationOptions)
        {
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!playerIDValidator.Successfull)
            {
                return new GetScoreResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"));
            }
            return await service.GetPlayerScoresAsync(playerIDValidator.ReturnedObject, paginationOptions);
        }

        [UsedImplicitly]
        public GetScoreResponse GetPlayerScores(Guid playerID,
            PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() }
            };
            return Request.ExecuteSyncRequest<GetScoreResponse>(
                GetPlayerScoresAPIPath,
                service,
                formData,
                paginationOptions
            );
        }

        [UsedImplicitly]
        public async Task<GetScoreResponse> GetPlayerScoresAsync(Guid playerID,
            PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() }
            };
            return await Request.ExecuteAsyncRequest<GetScoreResponse>(
                GetPlayerScoresAPIPath,
                service,
                formData,
                paginationOptions
            );
        }
    }
}