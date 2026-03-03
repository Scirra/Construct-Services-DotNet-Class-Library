using System;
using System.Collections.Generic;
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
        public BaseResponse DeleteMessage(Guid messageID)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Delete,
                service,
                DeleteMessageOptions.BuildFormData(messageID)
            );
        }
        
        /// <summary>
        /// Delete an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/delete-message" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteMessageAsync(Guid messageID)
        {
            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Delete,
                service,
                DeleteMessageOptions.BuildFormData(messageID)
            );
        }
    }
    
    private static class DeleteMessageOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid messageID)
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", messageID.ToString() }
            };
            return formData;
        }
    }
}