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
        /// Get an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/get-message" />
        [UsedImplicitly]
        public MessageResponse GetMessage(GetMessageOptions getMessageOptions)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.GetMessageAPIPath,
                service,
                getMessageOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/get-message" />
        [UsedImplicitly]
        public async Task<MessageResponse> GetMessageAsync(GetMessageOptions getMessageOptions)
        {
            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.GetMessageAPIPath,
                service,
                getMessageOptions.BuildFormData()
            );
        }
    }
}