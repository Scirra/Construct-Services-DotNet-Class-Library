using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

public static partial class Dimensions
{
    extension(BaseService service)
    {
        internal BaseResponse DeleteDimension(
            Thing forThing,
            Guid forThingID,
            string dimensionID,
            string apiEndPointPath)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                apiEndPointPath,
                service,
                DeleteRatingDimensionOptions.BuildFormData(forThing, forThingID, dimensionID)
            );
        }

        internal async Task<BaseResponse> DeleteDimensionAsync(
            Thing forThing,
            Guid forThingID,
            string dimensionID,
            string apiEndPointPath)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                apiEndPointPath,
                service,
                DeleteRatingDimensionOptions.BuildFormData(forThing, forThingID, dimensionID)
            );
        }
    }
    
    private static class DeleteRatingDimensionOptions
    {
        internal static Dictionary<string, string> BuildFormData(Thing forThing, Guid forThingID, string dimensionID)
        {
            var formData = new Dictionary<string, string>
            {
                { "thingTypeID", ((byte)forThing).ToString() },
                { "thingID", forThingID.ToString() },
                { "dimensionID", dimensionID }
            };
            return formData;
        }
    }
}