using System;
using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;

namespace ConstructServices.Broadcasts.Actions;

public static partial class RatingDimensions
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Create a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(Guid bucketID,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
        {
            const string path = "/channelcreateratingdimension.json";
            return Ratings.Actions.Rating.CreateDimension(service, path, Thing.BroadcastChannel, bucketID, dimensionID, title, description, maxRating, languageISO);
        }

        /// <summary>
        /// Create a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(Channel channel,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
            => CreateRatingDimension(service, channel.ID, dimensionID, title, description, maxRating, languageISO);
    }
}