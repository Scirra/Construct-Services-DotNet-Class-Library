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
    public static ChannelsResponse GetChannels(
        this BroadcastService service,
        string requestedLanguage = null,
        CultureInfo culture = null)
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
}