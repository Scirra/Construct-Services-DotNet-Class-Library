using System;
using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;

namespace ConstructServices.XP.Actions;
public static partial class Rankings
{        
    private const string GetRanksAPIPath = "/listranks.json";
    
    extension(XPService xpService)
    {
        /// <summary>
        /// Retrieve all existing ranks
        /// </summary>
        [UsedImplicitly]
        public RanksResponse ListAllRanks(Guid id)
        {
            return Request.ExecuteSyncRequest<RanksResponse>(
                GetRanksAPIPath,
                xpService,
                []
            );
        }

        /// <summary>
        /// Retrieve all existing ranks
        /// </summary>
        [UsedImplicitly]
        public async Task<RanksResponse> ListAllRanksAsync(Guid id)
        {
            return await Request.ExecuteAsyncRequest<RanksResponse>(
                GetRanksAPIPath,
                xpService,
                []
            );
        }
    }
}