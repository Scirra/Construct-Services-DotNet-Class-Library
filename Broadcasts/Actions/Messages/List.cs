using System;
using System.Collections.Generic;
using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Messages
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// List all Broadcast Messages in a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/get-messages" />
        [UsedImplicitly]
        public MessagesResponse ListMessages(ListMessagesOptions listMessagesOptions, PaginationOptions paginationOptions = null)
        {
            return Request.ExecuteSyncRequest<MessagesResponse>(
                Config.EndPointPaths.Messages.List,
                service,
                listMessagesOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List all Broadcast Messages in a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/get-messages" />
        [UsedImplicitly]
        public async Task<MessagesResponse> ListMessagesAsync(ListMessagesOptions listMessagesOptions, PaginationOptions paginationOptions = null)
        {
            return await Request.ExecuteAsyncRequest<MessagesResponse>(
                Config.EndPointPaths.Messages.List,
                service,
                listMessagesOptions.BuildFormData(),
                paginationOptions
            );
        }
    }

    
    [UsedImplicitly]
    public sealed class ListMessagesOptions
    {
        private Guid ChannelID { get; }
    
        public ListMessagesOptions(string strChannelID)
        {
            ChannelID = Guid.Parse(strChannelID);
        }
        public ListMessagesOptions(Guid channelID)
        {
            ChannelID = channelID;
        }
        public ListMessagesOptions(Channel channel)
        {
            ChannelID = channel.ID;
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", ChannelID.ToString() }
            };
            return formData;
        }
    }
}