using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    extension(LeaderboardService service)
    {
        /// <summary>
        /// Create a new Shadow Ban
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/create-shadow-ban" />
        [UsedImplicitly]
        public BaseResponse CreateShadowBan(CreateIPShadowBanOptions createShadowBanOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.ShadowBans.Create,
                service,
                createShadowBanOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Create a new Shadow Ban
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/create-shadow-ban" />
        [UsedImplicitly]
        public async Task<BaseResponse> CreateShadowBanAsync(CreateIPShadowBanOptions createShadowBanOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.ShadowBans.Create,
                service,
                createShadowBanOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Create a new Shadow Ban
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/create-shadow-ban" />
        [UsedImplicitly]
        public BaseResponse CreateShadowBan(CreatePlayerShadowBanOptions createShadowBanOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.ShadowBans.Create,
                service,
                createShadowBanOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Create a new Shadow Ban
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/create-shadow-ban" />
        [UsedImplicitly]
        public async Task<BaseResponse> CreateShadowBanAsync(CreatePlayerShadowBanOptions createShadowBanOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.ShadowBans.Create,
                service,
                createShadowBanOptions.BuildFormData()
            );
        }
    }
    
    public abstract class CreateShadowBanBase(
        Guid? scoreID = null,
        Guid? playerID = null,
        string ipAddress = null,
        int? ipHash = null)
    { 
        private Guid? ScoreID { get; } = scoreID;
        private Guid? PlayerID { get; } = playerID;
        private string IPAddress { get; } = ipAddress;
        private int? IPHash { get; } = ipHash;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (ScoreID.HasValue)
            {
                formData.Add("scoreID", ScoreID.Value.ToString());
            }
            if (PlayerID.HasValue)
            {
                formData.Add("playerID", PlayerID.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(IPAddress))
            {
                formData.Add("ipAddress", IPAddress);
            }
            if (IPHash.HasValue)
            {
                formData.Add("ipHash", IPHash.Value.ToString());
            }
            return formData;
        }
    }

    [UsedImplicitly]
    public sealed class CreateIPShadowBanOptions : CreateShadowBanBase
    {
        public CreateIPShadowBanOptions(string ipAddress) 
            : base(null, null, ipAddress) { }
        public CreateIPShadowBanOptions(IPAddress ipAddress) 
            : base(null, null, ipAddress.ToString()) { }
        public CreateIPShadowBanOptions(int ipHash) 
            : base(null, null, null, ipHash) { }
    }

    [UsedImplicitly]
    public sealed class CreatePlayerShadowBanOptions(Guid playerID)
        : CreateShadowBanBase(null, playerID);

    [UsedImplicitly]
    public sealed class CreateScoreShadowBanOptions(Guid scoreID)
        : CreateShadowBanBase(scoreID);
}