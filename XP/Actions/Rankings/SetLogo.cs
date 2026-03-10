using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;
public static partial class Rankings
{        
    extension(XPService xpService)
    {        
        /// <summary>
        /// Set a logo for an XP rank
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/set-logo" />
        [UsedImplicitly]
        public BaseResponse SetRankLogo(Guid rankID, PictureData logo)
        {
            return Request.ExecuteMultiPartFormSyncRequest<BaseResponse>(
                Config.EndPointPaths.Rankings.SetLogo,
                xpService,
                SetXPRankLogoOptions.BuildFormData(rankID, logo),
                SetXPRankLogoOptions.BuildBinaryFormData(logo)
            );
        }

        /// <summary>
        /// Set a logo for an XP rank
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/set-logo" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetRankLogoLogoAsync(Guid rankID, PictureData logo)
        {
            return await Request.ExecuteMultiPartFormAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Rankings.SetLogo,
                xpService,
                SetXPRankLogoOptions.BuildFormData(rankID, logo),
                SetXPRankLogoOptions.BuildBinaryFormData(logo)
            );
        }
    }

    private static class SetXPRankLogoOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid rankID, PictureData logo)
        {
            var formData = new Dictionary<string, string>
            {
                { "rankID", rankID.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(logo.Base64))
            {
                formData.Add("logo", logo.Base64);
            }
            else if (logo.URL != null)
            {
                formData.Add("logoURL", logo.URL.ToString());
            }
            return formData;
        }

        internal static Dictionary<string, ByteArrayContent> BuildBinaryFormData(PictureData logo)
        {
            var postedBinaryData = new Dictionary<string, ByteArrayContent>();
            if (logo?.Bytes != null)
            {
                postedBinaryData.Add("logoData", new ByteArrayContent(logo.Bytes));
            }
            return postedBinaryData;
        }
    }
}