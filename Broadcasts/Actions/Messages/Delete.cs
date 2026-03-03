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
        public BaseResponse DeleteMessage(DeleteMessageOptions deleteMessageOptions)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Delete,
                service,
                deleteMessageOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Delete an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/delete-message" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteMessageAsync(DeleteMessageOptions deleteMessageOptions)
        {
            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Delete,
                service,
                deleteMessageOptions.BuildFormData()
            );
        }
    }

    
    [UsedImplicitly]
    public sealed class DeleteMessageOptions
    {
        private Guid MessageID { get; }
    
        public DeleteMessageOptions(string strMessageID)
        {
            MessageID = Guid.Parse(strMessageID);
        }
        public DeleteMessageOptions(Guid messageID)
        {
            MessageID = messageID;
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", MessageID.ToString() }
            };
            return formData;
        }
    }
}