using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public RateResponse Rate(string sessionID,
            Guid cloudSaveID,
            Dictionary<string, byte> dimensionRatings)
        {
            const string path = "/rate.json";
            return Ratings.Actions.Rating.Rate(service, path, sessionID, Thing.CloudSaveBlob, cloudSaveID, dimensionRatings);
        }

        /// <summary>
        /// Rate a cloud save
        /// </summary>
        [UsedImplicitly]
        public RateResponse Rate(string sessionID,
            Guid cloudSaveID,
            byte rating)
            =>
                service.Rate(sessionID, cloudSaveID, new Dictionary<string, byte>{ { string.Empty, rating } });
    }
}