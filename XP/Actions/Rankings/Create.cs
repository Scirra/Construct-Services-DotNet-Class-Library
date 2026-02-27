using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Rankings
{        
    private const string CreateRankAPIPath = "/createrank.json";
    
    extension(XPService xpService)
    {
        /// <summary>
        /// Create a new XP ranking
        /// </summary>
        /// <param name="atXP">The XP level required to achieve this rank.</param>
        /// <param name="title">A title for the rank, for example 'General'.</param>
        /// <param name="description">A description for the rank.</param>
        /// <param name="language">The language that the title and description are written in.  Defaults to your games default language if not specified.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public RankResponse CreateRank(
            long atXP,
            string title, 
            string description = null, 
            Language language = null)
        {
            var formData = new Dictionary<string, string>
            {
                {"xp", atXP.ToString() },
                {"title", title },
                {"description", description ?? string.Empty },
                {"language", language?.ISO ?? string.Empty }
            };
        
            return Request.ExecuteSyncRequest<RankResponse>(
                CreateRankAPIPath,
                xpService,
                formData
            );
        }

        /// <summary>
        /// Create a new XP ranking
        /// </summary>
        /// <param name="atXP">The XP level required to achieve this rank.</param>
        /// <param name="title">A title for the rank, for example 'General'.</param>
        /// <param name="description">A description for the rank.</param>
        /// <param name="language">The language that the title and description are written in.  Defaults to your games default language if not specified.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public async Task<RankResponse> CreateRankAsync(
            long atXP,
            string title, 
            string description = null, 
            Language language = null)
        {
            var formData = new Dictionary<string, string>
            {
                {"xp", atXP.ToString() },
                {"title", title },
                {"description", description ?? string.Empty },
                {"language", language?.ISO ?? string.Empty }
            };
        
            return await Request.ExecuteAsyncRequest<RankResponse>(
                CreateRankAPIPath,
                xpService,
                formData
            );
        }
    }
}