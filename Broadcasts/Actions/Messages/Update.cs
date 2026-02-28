using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Common;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Messages
{    
    extension(BroadcastService service)
    {
        /// <summary>
        /// Update an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/update-message" />
        [UsedImplicitly]
        public BaseResponse UpdateMessage(UpdateMessageOptions updateMessageOptions)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.UpdateMessageAPIPath,
                service,
                updateMessageOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Update an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/update-message" />
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateMessageAsync(UpdateMessageOptions updateMessageOptions)
        {
            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.UpdateMessageAPIPath,
                service,
                updateMessageOptions.BuildFormData()
            );
        }
    }
}