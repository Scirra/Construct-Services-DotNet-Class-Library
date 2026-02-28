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
        public MessagesResponse ListMessages(ListMessagesOptions listMessagesOptions)
        {
            return Request.ExecuteSyncRequest<MessagesResponse>(
                Config.GetMessagesAPIPath,
                service,
                listMessagesOptions.BuildFormData(),
                listMessagesOptions.PaginationOptions
            );
        }

        /// <summary>
        /// List all Broadcast Messages in a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/get-messages" />
        [UsedImplicitly]
        public async Task<MessagesResponse> ListMessagesAsync(ListMessagesOptions listMessagesOptions)
        {
            return await Request.ExecuteAsyncRequest<MessagesResponse>(
                Config.GetMessagesAPIPath,
                service,
                listMessagesOptions.BuildFormData(),
                listMessagesOptions.PaginationOptions
            );
        }
    }
}