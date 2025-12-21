using System;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public ShadowBanResponse UnbanPlayerID(string playerID)
        {
            const string path = "/unshadowban.json";
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID }
                }
            );
        }

        [UsedImplicitly]
        public ShadowBanResponse UnbanIPAddress(string ipAddress)
        {
            const string path = "/unshadowban.json";
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "ipAddress", ipAddress }
                }
            );
        }

        [UsedImplicitly]
        public ShadowBanResponse UnbanScoreID(string strScoreID)
        {
            if (string.IsNullOrWhiteSpace(strScoreID))
                return new ShadowBanResponse("No Score ID was provided.", false);
            if (!Guid.TryParse(strScoreID, out var scoreID))
                return new ShadowBanResponse("Score ID was not a valid GUID.", false);
            return UnbanScoreID(service, scoreID);
        }
        
        [UsedImplicitly]
        public ShadowBanResponse UnbanScoreID(Guid scoreID)
        {
            const string path = "/unshadowban.json";
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "scoreID", scoreID.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public ShadowBanResponse UnbanIPHash(string strIPHash)
        {
            if (string.IsNullOrWhiteSpace(strIPHash))
                return new ShadowBanResponse("No IP Hash was provided.", false);
            if (!int.TryParse(strIPHash, out var ipHash))
                return new ShadowBanResponse("IP Hash was not a valid int.", false);
            return UnbanIPHash(service, ipHash);
        }
        
        [UsedImplicitly]
        public ShadowBanResponse UnbanIPHash(int ipHash)
        {
            const string path = "/unshadowban.json";
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "ipHash", ipHash.ToString() }
                }
            );
        }
    }
}