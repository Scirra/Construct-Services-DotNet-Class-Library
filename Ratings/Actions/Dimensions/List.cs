using ConstructServices.Common;
using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

internal static partial class Dimensions
{
    extension(BaseService service)
    {
        internal DimensionsResponse ListDimensions(
            string apiEndPointPath,
            ListRatingDimensionOptions listRatingDimensionOptions)
        {
            return Request.ExecuteSyncRequest<DimensionsResponse>(
                apiEndPointPath,
                service,
                listRatingDimensionOptions.BuildFormData()
            );
        }

        internal async Task<DimensionsResponse> ListDimensionsAsync(
            string apiEndPointPath,
            ListRatingDimensionOptions listRatingDimensionOptions)
        {
            return await Request.ExecuteAsyncRequest<DimensionsResponse>(
                apiEndPointPath,
                service,
                listRatingDimensionOptions.BuildFormData()
            );
        }
    }
}