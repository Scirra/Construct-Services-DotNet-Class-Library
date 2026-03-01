using ConstructServices.Common;
using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

internal static partial class Rating
{
    extension(BaseService service)
    {
        /// <summary>
        /// Get all rating dimensions
        /// </summary>
        internal DimensionsResponse GetDimensions(
            string apiEndPointPath,
            ListRatingDimensionOptions listRatingDimensionOptions)
        {
            return Request.ExecuteSyncRequest<DimensionsResponse>(
                apiEndPointPath,
                service,
                listRatingDimensionOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get all rating dimensions
        /// </summary>
        internal async Task<DimensionsResponse> GetDimensionsAsync(
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