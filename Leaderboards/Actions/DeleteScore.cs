using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    private const string DeleteScoresAPIPath = "/deletescores.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public DeleteScoresResponse DeleteAllPlayerIDScores(string playerID)
        {
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!playerIDValidator.Successfull)
            {
                return new DeleteScoresResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"));
            }
            return service.DeleteAllPlayerIDScores(playerIDValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<DeleteScoresResponse> DeleteAllPlayerIDScoresAsync(string playerID)
        {
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!playerIDValidator.Successfull)
            {
                return new DeleteScoresResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"));
            }
            return await service.DeleteAllPlayerIDScoresAsync(playerIDValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public DeleteScoresResponse DeleteAllPlayerIDScores(Guid playerID)
        {
            return Request.ExecuteSyncRequest<DeleteScoresResponse>(
                DeleteScoresAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public async Task<DeleteScoresResponse> DeleteAllPlayerIDScoresAsync(Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<DeleteScoresResponse>(
                DeleteScoresAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public DeleteScoresResponse DeleteScoreByID(string strScoreID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strScoreID);
            if (!idValidator.Successfull)
            {
                return new DeleteScoresResponse(string.Format(idValidator.ErrorMessage, "Score ID"));
            }
            return service.DeleteScoreByID(idValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<DeleteScoresResponse> DeleteScoreByIDAsync(string strScoreID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strScoreID);
            if (!idValidator.Successfull)
            {
                return new DeleteScoresResponse(string.Format(idValidator.ErrorMessage, "Score ID"));
            }
            return await service.DeleteScoreByIDAsync(idValidator.ReturnedObject);
        }
        
        [UsedImplicitly]
        public DeleteScoresResponse DeleteScoreByID(Guid scoreID)
        {
            return Request.ExecuteSyncRequest<DeleteScoresResponse>(
                DeleteScoresAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "scoreID", scoreID.ToString() }
                }
            );
        }
        
        [UsedImplicitly]
        public async Task<DeleteScoresResponse> DeleteScoreByIDAsync(Guid scoreID)
        {
            return await Request.ExecuteAsyncRequest<DeleteScoresResponse>(
                DeleteScoresAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "scoreID", scoreID.ToString() }
                }
            );
        }
    }
}