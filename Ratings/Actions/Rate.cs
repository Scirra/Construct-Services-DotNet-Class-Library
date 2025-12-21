using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructServices.Ratings.Actions;

internal static partial class Rating
{
    extension(BaseService service)
    {
        /// <summary>
        /// Rate an object
        /// </summary>
        internal RateResponse Rate(string apiEndPointPath,
            string sessionKey,
            Thing ratableThing,
            Guid thingID,
            Dictionary<string, byte> dimensionRatings)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new RateResponse(sessionKeyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey},
                { "thingTypeID", ((byte)ratableThing).ToString()},
                { "thingID", thingID.ToString()},
                { "value", string.Join(",", dimensionRatings.Select(c=> c.Key + "=" + c.Value))}
            };
            return Request.ExecuteSyncRequest<RateResponse>(
                apiEndPointPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Rate an object
        /// </summary>
        internal async Task<RateResponse> RateAsync(string apiEndPointPath,
            string sessionKey,
            Thing ratableThing,
            Guid thingID,
            Dictionary<string, byte> dimensionRatings)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new RateResponse(sessionKeyValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "sessionKey", sessionKey},
                { "thingTypeID", ((byte)ratableThing).ToString()},
                { "thingID", thingID.ToString()},
                { "value", string.Join(",", dimensionRatings.Select(c=> c.Key + "=" + c.Value))}
            };
            return await Request.ExecuteAsyncRequest<RateResponse>(
                apiEndPointPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Rate an object
        /// </summary>
        internal RateResponse Rate(string apiEndPointPath,
            string sessionKey,
            Thing ratableThing,
            Guid thingID,
            byte rating)
            =>
                service.Rate(sessionKey, apiEndPointPath, ratableThing, thingID,
                    new Dictionary<string, byte> { { string.Empty, rating } });

        /// <summary>
        /// Rate an object
        /// </summary>
        internal async Task<RateResponse> RateAsync(string apiEndPointPath,
            string sessionKey,
            Thing ratableThing,
            Guid thingID,
            byte rating)
            =>
                await service.RateAsync(sessionKey, apiEndPointPath, ratableThing, thingID,
                    new Dictionary<string, byte> { { string.Empty, rating } });
    }
}