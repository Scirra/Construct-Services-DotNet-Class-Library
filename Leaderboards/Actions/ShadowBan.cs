using System;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    private const string ShadowBanAPIPath = "/shadowban.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public ShadowBanResponse BanPlayerID(string playerID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!idValidator.Successfull)
            {
                return new ShadowBanResponse(string.Format(idValidator.ErrorMessage, "Player ID"));
            }

            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                ShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID }
                }
            );
        }

        [UsedImplicitly]
        public async Task<ShadowBanResponse> BanPlayerIDAsync(string playerID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!idValidator.Successfull)
            {
                return new ShadowBanResponse(string.Format(idValidator.ErrorMessage, "Player ID"));
            }

            return await Request.ExecuteAsyncRequest<ShadowBanResponse>(
                ShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID }
                }
            );
        }

        [UsedImplicitly]
        public ShadowBanResponse BanIPAddress(string ipAddress)
        {
            if (!IPAddress.TryParse(ipAddress, out _))
            {
                return new ShadowBanResponse("Invalid IP address format.");
            }
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                ShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "ipAddress", ipAddress }
                }
            );
        }

        [UsedImplicitly]
        public async Task<ShadowBanResponse> BanIPAddressAsync(string ipAddress)
        {
            if (!IPAddress.TryParse(ipAddress, out _))
            {
                return new ShadowBanResponse("Invalid IP address format.");
            }
            return await Request.ExecuteAsyncRequest<ShadowBanResponse>(
                ShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "ipAddress", ipAddress }
                }
            );
        }

        [UsedImplicitly]
        public ShadowBanResponse BanScoreID(string strScoreID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strScoreID);
            if (!idValidator.Successfull)
            {
                return new ShadowBanResponse(string.Format(idValidator.ErrorMessage, "Score ID"));
            }
            return service.BanScoreID(idValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<ShadowBanResponse> BanScoreIDAsync(string strScoreID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strScoreID);
            if (!idValidator.Successfull)
            {
                return new ShadowBanResponse(string.Format(idValidator.ErrorMessage, "Score ID"));
            }
            return await service.BanScoreIDAsync(idValidator.ReturnedObject);
        }
        
        [UsedImplicitly]
        public ShadowBanResponse BanScoreID(Guid scoreID)
        {
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                ShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "scoreID", scoreID.ToString() }
                }
            );
        }
        
        [UsedImplicitly]
        public async Task<ShadowBanResponse> BanScoreIDAsync(Guid scoreID)
        {
            return await Request.ExecuteAsyncRequest<ShadowBanResponse>(
                ShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "scoreID", scoreID.ToString() }
                }
            );
        }

        [UsedImplicitly]
        public ShadowBanResponse BanIPHash(string strIPHash)
        {
            var validation = Common.Validations.IPHash.ValidateIPHash(strIPHash);
            if (!validation.Successfull)
            {
                return new ShadowBanResponse(validation.ErrorMessage);
            }
            return service.BanIPHash(validation.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<ShadowBanResponse> BanIPHashAsync(string strIPHash)
        {
            var validation = Common.Validations.IPHash.ValidateIPHash(strIPHash);
            if (!validation.Successfull)
            {
                return new ShadowBanResponse(validation.ErrorMessage);
            }
            return await service.BanIPHashAsync(validation.ReturnedObject);
        }
        
        [UsedImplicitly]
        public ShadowBanResponse BanIPHash(int ipHash)
        {
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                ShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "ipHash", ipHash.ToString() }
                }
            );
        }
        
        [UsedImplicitly]
        public async Task<ShadowBanResponse> BanIPHashAsync(int ipHash)
        {
            return await Request.ExecuteAsyncRequest<ShadowBanResponse>(
                ShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "ipHash", ipHash.ToString() }
                }
            );
        }
    }
}