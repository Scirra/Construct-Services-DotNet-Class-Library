using ConstructServices.Common;
using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;
internal static partial class Dimensions
{
    extension(BaseService service)
    {
        internal DimensionResponse UpdateDimension(
            string apiEndPointPath,
            UpdateRatingDimensionBase updateRatingDimensionBase)
        {
            return Request.ExecuteSyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                updateRatingDimensionBase.BuildFormData()
            );
        }

        internal async Task<DimensionResponse> UpdateDimensionAsync(
            string apiEndPointPath,
            UpdateRatingDimensionBase updateRatingDimensionBase)
        {
            return await Request.ExecuteAsyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                updateRatingDimensionBase.BuildFormData()
            );
        }
    }
}