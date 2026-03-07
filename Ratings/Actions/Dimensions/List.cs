using System;
using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

public static partial class Dimensions
{
    extension(BaseService service)
    {
        internal DimensionsResponse ListDimensions(
            Thing forThing,
            Guid forThingID,
            string apiEndPointPath)
        {
            return Request.ExecuteSyncRequest<DimensionsResponse>(
                apiEndPointPath,
                service,
                ListRatingDimensionOptions.BuildFormData(forThing, forThingID)
            );
        }

        internal async Task<DimensionsResponse> ListDimensionsAsync(
            Thing forThing,
            Guid forThingID,
            string apiEndPointPath)
        {
            return await Request.ExecuteAsyncRequest<DimensionsResponse>(
                apiEndPointPath,
                service,
                ListRatingDimensionOptions.BuildFormData(forThing, forThingID)
            );
        }
    }
    
    private static class ListRatingDimensionOptions
    {
        internal static Dictionary<string, string> BuildFormData(Thing forThing, Guid forThingID)
        {
            var formData = new Dictionary<string, string>
            {
                { "thingTypeID", ((byte)forThing).ToString() },
                { "thingID", forThingID.ToString() }
            };
            return formData;
        }
    }
}