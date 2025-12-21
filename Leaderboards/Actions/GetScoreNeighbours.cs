using ConstructServices.Leaderboards.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    private const string GetScoreNeighboursAPIPath = "/getscoreneighbours.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public GetScoreNeighboursResponse GetPlayersScoreNeighbours(
            string playerID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!idValidator.Successfull)
            {
                return new GetScoreNeighboursResponse(string.Format(idValidator.ErrorMessage, "Player ID"), false);
            }
            return service.GetPlayersScoreNeighbours(idValidator.ReturnedObject, range, compareRanks, requestPerspective);
        }

        [UsedImplicitly]
        public async Task<GetScoreNeighboursResponse> GetPlayersScoreNeighboursAsync(
            string playerID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!idValidator.Successfull)
            {
                return new GetScoreNeighboursResponse(string.Format(idValidator.ErrorMessage, "Player ID"), false);
            }
            return await service.GetPlayersScoreNeighboursAsync(idValidator.ReturnedObject, range, compareRanks, requestPerspective);
        }

        [UsedImplicitly]
        public GetScoreNeighboursResponse GetPlayersScoreNeighbours(
            Guid playerID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
            => Execute(service, playerID.ToString(), null, range, compareRanks, requestPerspective);

        [UsedImplicitly]
        public async Task<GetScoreNeighboursResponse> GetPlayersScoreNeighboursAsync(
            Guid playerID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
            => await ExecuteAsync(service, playerID.ToString(), null, range, compareRanks, requestPerspective);
        
        [UsedImplicitly]
        public GetScoreNeighboursResponse GetScoreNeighbours(
            string strScoreID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strScoreID);
            if (!idValidator.Successfull)
            {
                return new GetScoreNeighboursResponse(string.Format(idValidator.ErrorMessage, "Score ID"), false);
            }
            return service.GetScoreNeighbours(idValidator.ReturnedObject, range, compareRanks, requestPerspective);
        }

        [UsedImplicitly]
        public async Task<GetScoreNeighboursResponse> GetScoreNeighboursAsync(
            string strScoreID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strScoreID);
            if (!idValidator.Successfull)
            {
                return new GetScoreNeighboursResponse(string.Format(idValidator.ErrorMessage, "Score ID"), false);
            }
            return await service.GetScoreNeighboursAsync(idValidator.ReturnedObject, range, compareRanks, requestPerspective);
        }

        [UsedImplicitly]
        public GetScoreNeighboursResponse GetScoreNeighbours(
            Guid scoreID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
            => Execute(service, null, scoreID, range, compareRanks, requestPerspective);

        [UsedImplicitly]
        public async Task<GetScoreNeighboursResponse> GetScoreNeighboursAsync(
            Guid scoreID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
            => await ExecuteAsync(service, null, scoreID, range, compareRanks, requestPerspective);
    }
    
    private static GetScoreNeighboursResponse Execute(
        LeaderboardService service,
        string playerID,
        Guid? scoreID,
        int range,
        int? compareRanks = null,
        RequestPerspective requestPerspective = null)
    {
        var formData = new Dictionary<string, string>
        {
            { "range", range.ToString() }
        };
        if (!string.IsNullOrWhiteSpace(playerID))
        {
            formData.Add("playerID", playerID);
        }
        if (scoreID.HasValue)
        {
            formData.Add("scoreID", scoreID.Value.ToString());
        }
        if (compareRanks.HasValue)
        {
            formData.Add("compareRanks", compareRanks.Value.ToString());
        }

        LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

        return Request.ExecuteSyncRequest<GetScoreNeighboursResponse>(
            GetScoreNeighboursAPIPath,
            service,
            formData
        );
    }
    private static async Task<GetScoreNeighboursResponse> ExecuteAsync(
        LeaderboardService service,
        string playerID,
        Guid? scoreID,
        int range,
        int? compareRanks = null,
        RequestPerspective requestPerspective = null)
    {
        var formData = new Dictionary<string, string>
        {
            { "range", range.ToString() }
        };
        if (!string.IsNullOrWhiteSpace(playerID))
        {
            formData.Add("playerID", playerID);
        }
        if (scoreID.HasValue)
        {
            formData.Add("scoreID", scoreID.Value.ToString());
        }
        if (compareRanks.HasValue)
        {
            formData.Add("compareRanks", compareRanks.Value.ToString());
        }

        LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

        return await Request.ExecuteAsyncRequest<GetScoreNeighboursResponse>(
            GetScoreNeighboursAPIPath,
            service,
            formData
        );
    }
}