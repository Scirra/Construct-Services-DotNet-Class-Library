using ConstructServices.Common;
using System.Threading.Tasks;
using ConstructServices.Ratings.Objects;

namespace ConstructServices.Ratings.Actions;
internal static partial class Rating
{
    extension(BaseService service)
    {
        /// <summary>
        /// Delete a rating dimension
        /// </summary>
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

        /// <summary>
        /// Delete a rating dimension
        /// </summary>
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