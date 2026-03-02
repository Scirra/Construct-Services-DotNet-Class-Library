using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{

    extension(LeaderboardService service)
    {        
        /// <summary>
        /// List Score neighbours for a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-neighbours" />
        [UsedImplicitly]
        public GetScoreNeighboursResponse ListPlayersScoreNeighbours(
            ListPlayerScoreNeighboursOptions listPlayerScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listPlayerScoreNeighboursOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<GetScoreNeighboursResponse>(
                Config.EndPointPaths.Scores.ListScoreNeighbours,
                service,
                formData
            );
        }        
        
        /// <summary>
        /// List Score neighbours for a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-neighbours" />
        [UsedImplicitly]
        public async Task<GetScoreNeighboursResponse> ListPlayersScoreNeighboursAsync(
            ListPlayerScoreNeighboursOptions listPlayerScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listPlayerScoreNeighboursOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<GetScoreNeighboursResponse>(
                Config.EndPointPaths.Scores.ListScoreNeighbours,
                service,
                formData
            );
        }        
        
        /// <summary>
        /// List Score neighbours for a Score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-neighbours" />
        [UsedImplicitly]
        public GetScoreNeighboursResponse ListScoreNeighbours(
            ListScoreNeighboursOptions listScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listScoreNeighboursOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<GetScoreNeighboursResponse>(
                Config.EndPointPaths.Scores.ListScoreNeighbours,
                service,
                formData
            );
        }

        /// <summary>
        /// List Score neighbours for a Score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-neighbours" />
        [UsedImplicitly]
        public async Task<GetScoreNeighboursResponse> ListScoreNeighboursAsync(
            ListScoreNeighboursOptions listScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listScoreNeighboursOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<GetScoreNeighboursResponse>(
                Config.EndPointPaths.Scores.ListScoreNeighbours,
                service,
                formData
            );
        }
    }
}