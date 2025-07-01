using System;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions
{
    public static partial class ShadowBans
    {
        public static ShadowBanResponse BanPlayerID(
            this LeaderboardService service,
            string playerID)
        {
            const string path = "/shadowban.json";
            return Task.Run(() => Request.ExecuteLeaderboardRequest<ShadowBanResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID },
                }
            )).Result;
        }

        public static ShadowBanResponse BanIPAddress(
            this LeaderboardService service,
            string ipAddress)
        {
            const string path = "/shadowban.json";
            return Task.Run(() => Request.ExecuteLeaderboardRequest<ShadowBanResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "ipAddress", ipAddress },
                }
            )).Result;
        }
        
        public static ShadowBanResponse BanScoreID(
            this LeaderboardService service,
            string strScoreID)
        {
            if (string.IsNullOrWhiteSpace(strScoreID))
                return new ShadowBanResponse("No Score ID was provided.", false);
            if (!Guid.TryParse(strScoreID, out var scoreID))
                return new ShadowBanResponse("Score ID was not a valid GUID.", false);
            return BanScoreID(service, scoreID);
        }
        public static ShadowBanResponse BanScoreID(
            this LeaderboardService service,
            Guid scoreID)
        {
            const string path = "/shadowban.json";

            return Task.Run(() => Request.ExecuteLeaderboardRequest<ShadowBanResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "scoreID", scoreID.ToString() },
                }
            )).Result;
        }
        
        public static ShadowBanResponse BanIPHash(
            this LeaderboardService service,
            string strIPHash)
        {
            if (string.IsNullOrWhiteSpace(strIPHash))
                return new ShadowBanResponse("No IP Hash was provided.", false);
            if (!int.TryParse(strIPHash, out var ipHash))
                return new ShadowBanResponse("IP Hash was not a valid int.", false);
            return BanIPHash(service, ipHash);
        }
        public static ShadowBanResponse BanIPHash(
            this LeaderboardService service,
            int ipHash)
        {
            const string path = "/shadowban.json";
            return Task.Run(() => Request.ExecuteLeaderboardRequest<ShadowBanResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "ipHash", ipHash.ToString() },
                }
            )).Result;
        }
    }
}
