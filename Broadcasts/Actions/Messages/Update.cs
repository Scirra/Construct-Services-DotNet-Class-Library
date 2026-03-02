using System;
using System.Collections.Generic;
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
        public BaseResponse UpdateMessage(Guid messageID, UpdateMessageOptions updateMessageOptions)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Update,
                service,
                updateMessageOptions.BuildFormData(messageID)
            );
        }

        /// <summary>
        /// Update an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/update-message" />
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateMessageAsync(Guid messageID, UpdateMessageOptions updateMessageOptions)
        {
            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Update,
                service,
                updateMessageOptions.BuildFormData(messageID)
            );
        }
    }

    [UsedImplicitly]
    public sealed class UpdateMessageOptions
    {
        [UsedImplicitly]
        public string Title { get; set; }

        [UsedImplicitly]
        public string Text { get; set; }

        [UsedImplicitly]
        public string LanguageISO { get; set; }
    
        internal Dictionary<string, string> BuildFormData(Guid messageID)
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", messageID.ToString() },
                { "title", Title },
                { "text", Text },
                { "language", LanguageISO }
            };
            return formData;
        }
    }
}