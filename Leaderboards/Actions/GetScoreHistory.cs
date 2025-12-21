using System;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    private const string GetScoreHistoryAPIPath = "/getscorehistory.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public GetScoreHistoryResponse GetPlayersScoreHistory(string playerID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!idValidator.Successfull)
            {
                return new GetScoreHistoryResponse(string.Format(idValidator.ErrorMessage, "Player ID"));
            }
            return service.GetPlayersScoreHistory(idValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<GetScoreHistoryResponse> GetPlayersScoreHistoryAsync(string playerID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!idValidator.Successfull)
            {
                return new GetScoreHistoryResponse(string.Format(idValidator.ErrorMessage, "Player ID"));
            }
            return await service.GetPlayersScoreHistoryAsync(idValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public GetScoreHistoryResponse GetPlayersScoreHistory(Guid playerID)
        {
            var formData = new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() }
            };
            return Request.ExecuteSyncRequest<GetScoreHistoryResponse>(
                GetScoreHistoryAPIPath,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<GetScoreHistoryResponse> GetPlayersScoreHistoryAsync(Guid playerID)
        {
            var formData = new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() }
            };
            return await Request.ExecuteAsyncRequest<GetScoreHistoryResponse>(
                GetScoreHistoryAPIPath,
                service,
                formData
            );
        }
        
        [UsedImplicitly]
        public GetScoreHistoryResponse GetScoreHistoryOnScoreID(string strScoreID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strScoreID);
            if (!idValidator.Successfull)
            {
                return new GetScoreHistoryResponse(string.Format(idValidator.ErrorMessage, "Score ID"));
            }
            return service.GetScoreHistoryOnScoreID(idValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<GetScoreHistoryResponse> GetScoreHistoryOnScoreIDAsync(string strScoreID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strScoreID);
            if (!idValidator.Successfull)
            {
                return new GetScoreHistoryResponse(string.Format(idValidator.ErrorMessage, "Score ID"));
            }
            return await service.GetScoreHistoryOnScoreIDAsync(idValidator.ReturnedObject);
        }
        
        [UsedImplicitly]
        public GetScoreHistoryResponse GetScoreHistoryOnScoreID(Guid scoreID)
        {
            var formData = new Dictionary<string, string>
            {
                { "scoreID", scoreID.ToString() }
            };
            return Request.ExecuteSyncRequest<GetScoreHistoryResponse>(
                GetScoreHistoryAPIPath,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<GetScoreHistoryResponse> GetScoreHistoryOnScoreIDAsync(Guid scoreID)
        {
            var formData = new Dictionary<string, string>
            {
                { "scoreID", scoreID.ToString() }
            };
            return await Request.ExecuteAsyncRequest<GetScoreHistoryResponse>(
                GetScoreHistoryAPIPath,
                service,
                formData
            );
        }
    }
}