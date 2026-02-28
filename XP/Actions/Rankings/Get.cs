using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;

namespace ConstructServices.XP.Actions;
public static partial class Rankings
{        
    extension(XPService xpService)
    {
        /// <summary>
        /// Retrieve all existing ranks
        /// </summary>
        [UsedImplicitly]
        public RanksResponse ListAllRanks()
        {
            return Request.ExecuteSyncRequest<RanksResponse>(
                Config.GetRanksAPIPath,
                xpService,
                []
            );
        }

        /// <summary>
        /// Retrieve all existing ranks
        /// </summary>
        [UsedImplicitly]
        public async Task<RanksResponse> ListAllRanksAsync()
        {
            return await Request.ExecuteAsyncRequest<RanksResponse>(
                Config.GetRanksAPIPath,
                xpService,
                []
            );
        }
    }
}