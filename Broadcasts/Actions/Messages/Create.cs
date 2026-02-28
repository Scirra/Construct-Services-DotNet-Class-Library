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
        /// Creates a new Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/create-message" />
        [UsedImplicitly]
        public MessageResponse CreateMessage(CreateMessageOptions createMessageOptions)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.CreateMessageAPIPath,
                service,
                createMessageOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Creates a new Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/create-message" />
        [UsedImplicitly]
        public async Task<MessageResponse> CreateMessageAsync(CreateMessageOptions createMessageOptions)
        {
            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.CreateMessageAPIPath,
                service,
                createMessageOptions.BuildFormData()
            );
        }
    }
}