using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Ratings
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public RateResponse Rate(RateCloudSaveOptions rateCloudSaveOptions)
        {
            return global::ConstructServices.Ratings.Actions.Rating.Rate(service, Config.EndPointPaths.Ratings.Rate, rateCloudSaveOptions);
        }

        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public async Task<RateResponse> RateAsync(RateCloudSaveOptions rateCloudSaveOptions)
        {
            return await global::ConstructServices.Ratings.Actions.Rating.RateAsync(service, Config.EndPointPaths.Ratings.Rate, rateCloudSaveOptions);
        }
    }
}