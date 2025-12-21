using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Get
{    
    private const string GetChannelAPIPath = "/getchannel.json";
    
    extension(BroadcastService service)
    {
        /// <summary>
        /// Get all channels in this game
        /// </summary>
        [UsedImplicitly]
        public ChannelResponse GetChannel(string strChannelID)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new ChannelResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }

            return service.GetChannel(channelIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Get all channels in this game
        /// </summary>
        [UsedImplicitly]
        public async Task<ChannelResponse> GetChannelAsync(string strChannelID)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new ChannelResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }

            return await service.GetChannelAsync(channelIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Get all channels in this game
        /// </summary>
        [UsedImplicitly]
        public ChannelResponse GetChannel(Guid channelID)
        {
            var formData = new Dictionary<string, string>
            {
                {"channelID", channelID.ToString() }
            };
        
            return Request.ExecuteSyncRequest<ChannelResponse>(
                GetChannelAPIPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Get all channels in this game
        /// </summary>
        [UsedImplicitly]
        public async Task<ChannelResponse> GetChannelAsync(Guid channelID)
        {
            var formData = new Dictionary<string, string>
            {
                {"channelID", channelID.ToString() }
            };
        
            return await Request.ExecuteAsyncRequest<ChannelResponse>(
                GetChannelAPIPath,
                service,
                formData
            );
        }
    }
}