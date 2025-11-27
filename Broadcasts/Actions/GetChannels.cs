using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Broadcasts.Actions;

public static class Get
{
    /// <summary>
    /// Get all channels in this game
    /// </summary>
    [UsedImplicitly]
    private static ChannelsResponse DoGetChannels(
        BroadcastService service,
        string requestedLanguage,
        CultureInfo culture)
    {
        var formData = new Dictionary<string, string>();
        if (!string.IsNullOrEmpty(requestedLanguage))
        {
            formData.Add("requestedLanguage", requestedLanguage);
        }
        if (culture != null)
        {
            formData.Add("culture", culture.ToString());
        }

        const string path = "/getchannels.json";
        return Task.Run(() => Request.ExecuteRequest<ChannelsResponse>(
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
        public ChannelsResponse GetChannels()
            => DoGetChannels(service, null, null);
        
        /// <summary>
        /// Get all channels in this game returning the translatable elements as requestedLanguage if possible.
        /// </summary>
        [UsedImplicitly]
        public ChannelsResponse GetChannels(string requestedLanguage)
            => DoGetChannels(service, requestedLanguage, null);
        
        /// <summary>
        /// Get all channels in this game returning the translatable elements as requestedLanguage if possible
        /// and data returned formatted to a specified culture.
        /// </summary>
        [UsedImplicitly]
        public ChannelsResponse GetChannels(string requestedLanguage, CultureInfo inCulture)
            => DoGetChannels(service, requestedLanguage, inCulture);

        /// <summary>
        /// Get all channels in this game with data returned formatted to a specified culture.
        /// </summary>
        [UsedImplicitly]
        public ChannelsResponse GetChannels(CultureInfo inCulture)
            => DoGetChannels(service, null, inCulture);
    }
}