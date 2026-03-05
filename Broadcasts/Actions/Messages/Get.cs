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
        /// Get an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/get-message" />
        [UsedImplicitly]
        public MessageResponse GetMessage(Guid messageID)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Get,
                service,
                GetMessageOptions.BuildFormData(messageID)
            );
        }

        /// <summary>
        /// Get an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/get-message" />
        [UsedImplicitly]
        public async Task<MessageResponse> GetMessageAsync(Guid messageID)
        {
            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Get,
                service,
                GetMessageOptions.BuildFormData(messageID)
            );
        }
    }
    
    private static class GetMessageOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid messageID)
        {
            return new Dictionary<string, string>
            {
                { "messageID", messageID.ToString() }
            };
        }
    }
}