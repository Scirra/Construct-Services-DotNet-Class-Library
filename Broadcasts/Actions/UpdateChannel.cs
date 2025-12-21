using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Update
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Update a channels settings
        /// </summary>
        [UsedImplicitly]
        public ChannelResponse UpdateChannel(
            Guid channelID,
            string channelName,
            string channelDescription,
            string languageISO,
            bool allowRatings)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() },
                { "name", channelName },
                { "description", channelDescription },
                { "language", languageISO },
                { "allowRatings", allowRatings.ToInt().ToString() }
            };

            const string path = "/updatechannel.json";
            return Task.Run(() => Request.ExecuteRequest<ChannelResponse>(
                path,
                service,
                formData
            )).Result;
        }

        /// <summary>
        /// Update a channels settings
        /// </summary>
        [UsedImplicitly]
        public ChannelResponse UpdateChannel(
            Channel channel,
            string channelName,
            string channelDescription,
            string languageISO,
            bool allowRatings)
            => UpdateChannel(service, channel.ID, channelName, channelDescription, languageISO, allowRatings);
    }
}