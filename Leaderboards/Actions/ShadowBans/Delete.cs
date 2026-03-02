using System;
using System.Collections.Generic;
using System.Net;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    extension(LeaderboardService service)
    {
        /// <summary>
        /// Delete a Shadow Ban
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/remove-shadow-ban" />
        [UsedImplicitly]
        public ShadowBanResponse UnbanIPHash(DeleteShadowBanBase deleteShadowBanOptions)
        {
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                Config.EndPointPaths.ShadowBans.Delete,
                service,
                deleteShadowBanOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Delete a Shadow Ban
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/remove-shadow-ban" />
        [UsedImplicitly]
        public async Task<ShadowBanResponse> UnbanIPHashAsync(DeleteShadowBanBase deleteShadowBanOptions)
        {
            return await Request.ExecuteAsyncRequest<ShadowBanResponse>(
                Config.EndPointPaths.ShadowBans.Delete,
                service,
                deleteShadowBanOptions.BuildFormData()
            );
        }
    }
    public abstract class DeleteShadowBanBase(
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
    public sealed class DeleteIPShadowBanOptions : DeleteShadowBanBase
    {
        public DeleteIPShadowBanOptions(Guid leaderboardID, string ipAddress) 
            : base(null, null, ipAddress) { }
        public DeleteIPShadowBanOptions(Guid leaderboardID, IPAddress ipAddress) 
            : base(null, null, ipAddress.ToString()) { }
        public DeleteIPShadowBanOptions(Guid leaderboardID, int ipHash) 
            : base(null, null, null, ipHash) { }
    }

    [UsedImplicitly]
    public sealed class DeletePlayerShadowBanOptions(Guid playerID)
        : DeleteShadowBanBase(null, playerID);

    [UsedImplicitly]
    public sealed class DeleteScoreShadowBanOptions(Guid scoreID)
        : DeleteShadowBanBase(scoreID);

}