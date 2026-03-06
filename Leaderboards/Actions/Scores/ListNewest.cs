using ConstructServices.Common;
using ConstructServices.Common.Languages;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common.Countries;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    extension(LeaderboardServiceBase service)
    {
        /// <summary>
        /// List the newest Scores in a Leaderboard
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-newest-scores" />
        [UsedImplicitly]
        public ScoresResponse ListNewestScores(
            ListNewestScoresOptions listNewestScoresOptions,
            PaginationOptions paginationOptions,
            RequestPerspective requestPerspective = null)
        {
            var validation = listNewestScoresOptions.Validate();
            if (!validation.Valid) return new ScoresResponse(validation.ErrorMessage);

            var formData = listNewestScoresOptions.BuildFormData();

            LeaderboardServiceBase.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListNewest,
                service,
                formData,
                paginationOptions
            );
        }

        /// <summary>
        /// List the newest Scores in a Leaderboard
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-newest-scores" />
        [UsedImplicitly]
        public async Task<ScoresResponse> ListNewestScoresAsync(
            ListNewestScoresOptions listNewestScoresOptions,
            PaginationOptions paginationOptions,
            RequestPerspective requestPerspective = null)
        {
            var validation = listNewestScoresOptions.Validate();
            if (!validation.Valid) return new ScoresResponse(validation.ErrorMessage);

            var formData = listNewestScoresOptions.BuildFormData();

            LeaderboardServiceBase.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListNewest,
                service,
                formData,
                paginationOptions
            );
        }
    }
    

    [UsedImplicitly]
    public sealed class ListNewestScoresOptions
    {
        [UsedImplicitly]
        public string CountryISO { private get; set; }

        [UsedImplicitly]
        public Country Country {
            set => CountryISO = value.ISOAlpha2();
        }
        
        internal Common.Validations.Responses.ValidationResponseBase Validate()
        {
            if (!string.IsNullOrWhiteSpace(CountryISO))
            {
                var countryValidation = Common.Validations.Common.Functions.IsCountryISOAlpha2Valid(CountryISO);
                if (!countryValidation.Valid) return countryValidation;
            }
            return new Common.Validations.Responses.SuccessfullValidation();
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(CountryISO))
            {
                formData.Add("country", CountryISO);
            }
            return formData;
        }
    }
}