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
        /// Delete an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/delete-message" />
        [UsedImplicitly]
        public BaseResponse DeleteMessage(DeleteMessageOptions deleteMessageOptions)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.DeleteMessageAPIPath,
                service,
                deleteMessageOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Delete an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/delete-message" />
        public async Task<BaseResponse> DeleteMessageAsync(DeleteMessageOptions deleteMessageOptions)
        {
            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.DeleteMessageAPIPath,
                service,
                deleteMessageOptions.BuildFormData()
            );
        }
    }
}