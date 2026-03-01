using ConstructServices.Common;
using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

internal static class Rating
{
    extension(BaseService service)
    {
        internal RateResponse Rate(
            string apiEndPointPath,
            RateObjectBase rateObjectBase)
        {
            return Request.ExecuteSyncRequest<RateResponse>(
                apiEndPointPath,
                service,
                rateObjectBase.BuildFormData()
            );
        }

        internal async Task<RateResponse> RateAsync(
            string apiEndPointPath,
            RateObjectBase rateObjectBase)
        {
            return await Request.ExecuteAsyncRequest<RateResponse>(
                apiEndPointPath,
                service,
                rateObjectBase.BuildFormData()
            );
        }
    }
}