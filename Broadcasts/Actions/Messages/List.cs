using System;
using System.Collections.Generic;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Messages
{
    extension(BroadcastServiceBase service)
    {
        /// <summary>
        /// List all Broadcast Messages in a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/get-messages" />
        [UsedImplicitly]
        public MessagesResponse ListMessages(Guid channelID, PaginationOptions pagination)
        {
            return Request.ExecuteSyncRequest<MessagesResponse>(
                Config.EndPointPaths.Messages.List,
                service,
                ListMessagesOptions.BuildFormData(channelID),
                pagination
            );
        }

        /// <summary>
        /// List all Broadcast Messages in a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/get-messages" />
        [UsedImplicitly]
        public async Task<MessagesResponse> ListMessagesAsync(Guid channelID, PaginationOptions pagination)
        {
            return await Request.ExecuteAsyncRequest<MessagesResponse>(
                Config.EndPointPaths.Messages.List,
                service,
                ListMessagesOptions.BuildFormData(channelID),
                pagination
            );
        }
    }

    private static class ListMessagesOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid channelID)
        {
            return new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() }
            };
        }
    }
}