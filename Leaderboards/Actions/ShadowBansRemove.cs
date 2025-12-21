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
    private const string UnShadowBanAPIPath = "/unshadowban.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public ShadowBanResponse UnbanPlayerID(string playerID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!idValidator.Successfull)
            {
                return new ShadowBanResponse(string.Format(idValidator.ErrorMessage, "Player ID"));
            }

            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                UnShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID }
                }
            );
        }

        [UsedImplicitly]
        public async Task<ShadowBanResponse> UnbanPlayerIDAsync(string playerID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(playerID);
            if (!idValidator.Successfull)
            {
                return new ShadowBanResponse(string.Format(idValidator.ErrorMessage, "Player ID"));
            }

            return await Request.ExecuteAsyncRequest<ShadowBanResponse>(
                UnShadowBanAPIPath,
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
            if (!IPAddress.TryParse(ipAddress, out _))
            {
                return new ShadowBanResponse("Invalid IP address format.");
            }

            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                UnShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "ipAddress", ipAddress }
                }
            );
        }

        [UsedImplicitly]
        public async Task<ShadowBanResponse> UnbanIPAddressAsync(string ipAddress)
        {
            if (!IPAddress.TryParse(ipAddress, out _))
            {
                return new ShadowBanResponse("Invalid IP address format.");
            }

            return await Request.ExecuteAsyncRequest<ShadowBanResponse>(
                UnShadowBanAPIPath,
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
            var idValidator = Common.Validations.Guid.IsValidGuid(strScoreID);
            if (!idValidator.Successfull)
            {
                return new ShadowBanResponse(string.Format(idValidator.ErrorMessage, "Score ID"));
            }
            return service.UnbanScoreID(idValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<ShadowBanResponse> UnbanScoreIDAsync(string strScoreID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strScoreID);
            if (!idValidator.Successfull)
            {
                return new ShadowBanResponse(string.Format(idValidator.ErrorMessage, "Score ID"));
            }
            return await service.UnbanScoreIDAsync(idValidator.ReturnedObject);
        }
        
        [UsedImplicitly]
        public ShadowBanResponse UnbanScoreID(Guid scoreID)
        {
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                UnShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "scoreID", scoreID.ToString() }
                }
            );
        }
        
        [UsedImplicitly]
        public async Task<ShadowBanResponse> UnbanScoreIDAsync(Guid scoreID)
        {
            return await Request.ExecuteAsyncRequest<ShadowBanResponse>(
                UnShadowBanAPIPath,
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
            var validation = Common.Validations.IPHash.ValidateIPHash(strIPHash);
            if (!validation.Successfull)
            {
                return new ShadowBanResponse(validation.ErrorMessage);
            }
            return service.UnbanIPHash(validation.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<ShadowBanResponse> UnbanIPHashAsync(string strIPHash)
        {
            var validation = Common.Validations.IPHash.ValidateIPHash(strIPHash);
            if (!validation.Successfull)
            {
                return new ShadowBanResponse(validation.ErrorMessage);
            }
            return await service.UnbanIPHashAsync(validation.ReturnedObject);
        }
        
        [UsedImplicitly]
        public ShadowBanResponse UnbanIPHash(int ipHash)
        {
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                UnShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "ipHash", ipHash.ToString() }
                }
            );
        }
        
        [UsedImplicitly]
        public async Task<ShadowBanResponse> UnbanIPHashAsync(int ipHash)
        {
            return await Request.ExecuteAsyncRequest<ShadowBanResponse>(
                UnShadowBanAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "ipHash", ipHash.ToString() }
                }
            );
        }
    }
}