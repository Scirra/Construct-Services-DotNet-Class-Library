using ConstructServices.Common;
using System.Threading.Tasks;
using ConstructServices.Ratings.Objects;

namespace ConstructServices.Ratings.Actions;
internal static partial class Dimensions
{
    extension(BaseService service)
    {
        internal BaseResponse DeleteDimension(
            string apiEndPointPath,
            DeleteRatingDimensionOptions deleteRatingDimensionOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                apiEndPointPath,
                service,
                deleteRatingDimensionOptions.BuildFormData()
            );
        }

        internal async Task<BaseResponse> DeleteDimensionAsync(
            string apiEndPointPath,
            DeleteRatingDimensionOptions deleteRatingDimensionOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                apiEndPointPath,
                service,
                deleteRatingDimensionOptions.BuildFormData()
            );
        }
    }
}