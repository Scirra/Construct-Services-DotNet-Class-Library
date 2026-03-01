using ConstructServices.Common;
using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

internal static partial class Dimensions
{
    extension(BaseService service)
    {
        internal DimensionResponse CreateDimension(
            string apiEndPointPath,
            CreateRatingDimensionOptions createRatingDimensionOptions)
        {
            return Request.ExecuteSyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                createRatingDimensionOptions.BuildFormData()
            );
        }
        internal async Task<DimensionResponse> CreateDimensionAsync(
            string apiEndPointPath,
            CreateRatingDimensionOptions createRatingDimensionOptions)
        {
            return await Request.ExecuteAsyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                createRatingDimensionOptions.BuildFormData()
            );
        }
    }
}