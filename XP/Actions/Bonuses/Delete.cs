using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{

    extension(XPService xpService)
    {        
        /// <summary>Deletes an existing XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/delete-bonus" />
        [UsedImplicitly]
        public BaseResponse DeleteBonus(DeleteXPBonusOptions deleteXPBonusOptions)
        {            
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Bonuses.Delete,
                xpService,
                deleteXPBonusOptions.BuildFormData()
            );
        }

        /// <summary>Deletes an existing XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/delete-bonus" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteBonusAsync(DeleteXPBonusOptions deleteXPBonusOptions)
        {       
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Bonuses.Delete,
                xpService,
                deleteXPBonusOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class DeleteXPBonusOptions
    {
        private Guid BonusID { get; }
    
        public DeleteXPBonusOptions(string strBonusID)
        {
            BonusID = Guid.Parse(strBonusID);
        }
        public DeleteXPBonusOptions(Guid bonusID)
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
