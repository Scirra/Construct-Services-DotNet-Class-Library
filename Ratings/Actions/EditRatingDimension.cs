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
        /// Update a rating dimension
        /// </summary>
        internal DimensionResponse EditDimension(
            string apiEndPointPath,
            UpdateRatingDimensionBase updateRatingDimensionBase)
        {
            return Request.ExecuteSyncRequest<DimensionResponse>(
                apiEndPointPath,
                service,
                updateRatingDimensionBase.BuildFormData()
            );
        }

        /// <summary>
        /// Update a rating dimension
        /// </summary>
        internal async Task<DimensionResponse> EditDimensionAsync(
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