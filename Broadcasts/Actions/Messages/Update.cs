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
        public BaseResponse UpdateMessage(UpdateMessageOptions updateMessageOptions)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Update,
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
                Config.EndPointPaths.Messages.Update,
                service,
                updateMessageOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class UpdateMessageOptions
    {
        private Guid MessageID { get; }

        [UsedImplicitly]
        public string Title { get; set; }

        [UsedImplicitly]
        public string Text { get; set; }

        [UsedImplicitly]
        public string LanguageISO { get; set; }
    
        public UpdateMessageOptions(Guid messageID)
        {
            MessageID = messageID;
        }
        public UpdateMessageOptions(string strMessageID)
        {
            MessageID = Guid.Parse(strMessageID);
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", MessageID.ToString() },
                { "title", Title },
                { "text", Text },
                { "language", LanguageISO },
            };
            return formData;
        }
    }
}