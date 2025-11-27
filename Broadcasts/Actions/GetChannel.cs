using ConstructServices.Broadcasts.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ConstructServices.Common;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Get
{    
    /// <summary>
    /// Get all channels in this game
    /// </summary>
    [UsedImplicitly]
    private static ChannelResponse DoGetChannel(
        BroadcastService service,
        Guid channelID,
        string requestedLanguage,
        CultureInfo culture)
    {
        var formData = new Dictionary<string, string>
        {
            {"channelID", channelID.ToString() }
        };
        if (!string.IsNullOrEmpty(requestedLanguage))
        {
            formData.Add("requestedLanguage", requestedLanguage);
        }
        if (culture != null)
        {
            formData.Add("culture", culture.ToString());
        }
        
        const string path = "/getchannel.json";
        return Task.Run(() => Request.ExecuteRequest<ChannelResponse>(
            path,
            service,
            formData
        )).Result;
    }

    extension(BroadcastService service)
    {
        /// <summary>
        /// Get all channels in this game
        /// </summary>
        [UsedImplicitly]
        public ChannelResponse GetChannel(Guid channelID)
            => DoGetChannel(service, channelID, null, null);
        
        /// <summary>
        /// Get all channels in this game returning the translatable elements as requestedLanguage if possible.
        /// </summary>
        [UsedImplicitly]
        public ChannelResponse GetChannel(Guid channelID, string requestedLanguage)
            => DoGetChannel(service, channelID, requestedLanguage, null);
        
        /// <summary>
        /// Get all channels in this game returning the translatable elements as requestedLanguage if possible
        /// and data returned formatted to a specified culture.
        /// </summary>
        [UsedImplicitly]
        public ChannelResponse GetChannel(Guid channelID, string requestedLanguage, CultureInfo inCulture)
            => DoGetChannel(service, channelID, requestedLanguage, inCulture);

        /// <summary>
        /// Get all channels in this game with data returned formatted to a specified culture.
        /// </summary>
        [UsedImplicitly]
        public ChannelResponse GetChannel(Guid channelID, CultureInfo inCulture)
            => DoGetChannel(service, channelID, null, inCulture);
    }
}