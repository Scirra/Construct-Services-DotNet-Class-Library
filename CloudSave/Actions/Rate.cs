using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    private const string RateAPIEndPoint = "/rate.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public RateResponse Rate(
            string sessionID,
            Guid cloudSaveID,
            Dictionary<string, byte> dimensionRatings)
        {
            return Ratings.Actions.Rating.Rate(service, RateAPIEndPoint, sessionID, Thing.CloudSaveBlob, cloudSaveID, dimensionRatings);
        }

        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public async Task<RateResponse> RateAsync(
            string sessionID,
            Guid cloudSaveID,
            Dictionary<string, byte> dimensionRatings)
        {
            return await Ratings.Actions.Rating.RateAsync(service, RateAPIEndPoint, sessionID, Thing.CloudSaveBlob, cloudSaveID, dimensionRatings);
        }
        
        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public RateResponse Rate(
            string sessionID,
            string strCloudSaveID,
            Dictionary<string, byte> dimensionRatings)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strCloudSaveID);
            if (!idValidator.Successfull)
            {
                return new RateResponse(string.Format(idValidator.ErrorMessage, "Cloud save ID"));
            }
            return Ratings.Actions.Rating.Rate(service, RateAPIEndPoint, sessionID, Thing.CloudSaveBlob, idValidator.ReturnedObject, dimensionRatings);
        }

        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public async Task<RateResponse> RateAsync(
            string sessionID,
            string strCloudSaveID,
            Dictionary<string, byte> dimensionRatings)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strCloudSaveID);
            if (!idValidator.Successfull)
            {
                return new RateResponse(string.Format(idValidator.ErrorMessage, "Cloud save ID"));
            }
            return await Ratings.Actions.Rating.RateAsync(service, RateAPIEndPoint, sessionID, Thing.CloudSaveBlob, idValidator.ReturnedObject, dimensionRatings);
        }

        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public RateResponse Rate(
            string sessionID,
            Guid cloudSaveID,
            byte rating)
            =>
                service.Rate(sessionID, cloudSaveID, new Dictionary<string, byte>{ { string.Empty, rating } });
        
        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public async Task<RateResponse> RateAsync(
            string sessionID,
            Guid cloudSaveID,
            byte rating)
            =>
                await service.RateAsync(sessionID, cloudSaveID, new Dictionary<string, byte>{ { string.Empty, rating } });
    }
}