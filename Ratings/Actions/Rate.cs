using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

public static class Rating
{
    extension(BaseService service)
    {
        internal RateResponse Rate(
            Thing forThing,
            Guid thingID,
            string apiEndPointPath,
            RateObjectOptions rateObjectBase)
        {
            return Request.ExecuteSyncRequest<RateResponse>(
                apiEndPointPath,
                service,
                rateObjectBase.BuildFormData(forThing, thingID)
            );
        }

        internal async Task<RateResponse> RateAsync(
            Thing forThing,
            Guid thingID,
            string apiEndPointPath,
            RateObjectOptions rateObjectBase)
        {
            return await Request.ExecuteAsyncRequest<RateResponse>(
                apiEndPointPath,
                service,
                rateObjectBase.BuildFormData(forThing, thingID)
            );
        }
    }

    public class RateObjectOptions
    {
        [UsedImplicitly]
        public Dictionary<string, byte> Ratings { private get; set; }

        internal Dictionary<string, string> BuildFormData(Thing forThing, Guid forThingID)
        {
            var formData = new Dictionary<string, string>
            {
                { "thingTypeID", ((byte)forThing).ToString()},
                { "thingID", forThingID.ToString()}
            };
            if (Ratings != null)
            {
                formData.Add("value", string.Join(",", Ratings.Select(c=> c.Key + "=" + c.Value)));
            }
            return formData;
        }
    }
}