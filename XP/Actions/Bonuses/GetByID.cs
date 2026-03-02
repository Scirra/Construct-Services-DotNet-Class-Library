using System;
using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    extension(XPService xpService)
    {
        /// <summary>Get a XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/get-bonus" />
        [UsedImplicitly]
        public BonusResponse GetBonus(GetBonusOptions getBonusOptions)
        {              
            return Request.ExecuteSyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Get,
                xpService,
                getBonusOptions.BuildFormData()
            );
        }        
        
        /// <summary>Get a XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/get-bonus" />
        [UsedImplicitly]
        public async Task<BonusResponse> GetBonusAsync(GetBonusOptions getBonusOptions)
        {                    
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Get,
                xpService,
                getBonusOptions.BuildFormData()
            );
        }
    }
    [UsedImplicitly]
    public sealed class GetBonusOptions
    {
        private Guid BonusID { get; }

        public GetBonusOptions(string strBonusID)
        {
            BonusID = Guid.Parse(strBonusID);
        }
        public GetBonusOptions(Guid bonusID)
        {
            BonusID = bonusID;
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "bonusID", BonusID.ToString() }
            };
            return formData;
        }
    }
}