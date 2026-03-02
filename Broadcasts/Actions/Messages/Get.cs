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
        /// Get an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/get-message" />
        [UsedImplicitly]
        public MessageResponse GetMessage(GetMessageOptions getMessageOptions)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Get,
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
                Config.EndPointPaths.Messages.Get,
                service,
                getMessageOptions.BuildFormData()
            );
        }
    }

    
    [UsedImplicitly]
    public sealed class GetMessageOptions(string sessionKey, Guid messageID)
    {
        private string SessionKey { get; } = sessionKey;

        private Guid MessageID { get; } = messageID;

        public GetMessageOptions(Guid messageID) : this(null, messageID)
        {
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", MessageID.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }
            return formData;
        }
    }
}