using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    private const string RateAPIEndPoint = "/rate.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public RateResponse Rate(RateCloudSaveOptions rateCloudSaveOptions)
        {
            return Ratings.Actions.Rating.Rate(service, RateAPIEndPoint, rateCloudSaveOptions);
        }

        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public async Task<RateResponse> RateAsync(RateCloudSaveOptions rateCloudSaveOptions)
        {
            return await Ratings.Actions.Rating.RateAsync(service, RateAPIEndPoint, rateCloudSaveOptions);
        }
    }
}