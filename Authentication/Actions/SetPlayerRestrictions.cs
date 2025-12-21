using ConstructServices.Authentication.Enums;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string SetRestrictionsAPIPath = "/setplayerrestrictions.json";
    
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public BaseResponse SetPlayerRestrictions(
            string strPlayerID,
            List<PlayerRestriction> actions)
        {
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(strPlayerID);
            if (!playerIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"), false);
            }
            return service.SetPlayerRestrictions(playerIDValidator.ReturnedObject, actions);
        }

        [UsedImplicitly]
        public async Task<BaseResponse> SetPlayerRestrictionsAsync(
            string strPlayerID,
            List<PlayerRestriction> actions)
        {
            var playerIDValidator = Common.Validations.Guid.IsValidGuid(strPlayerID);
            if (!playerIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(playerIDValidator.ErrorMessage, "Player ID"), false);
            }
            return await service.SetPlayerRestrictionsAsync(playerIDValidator.ReturnedObject, actions);
        }

        [UsedImplicitly]
        public BaseResponse SetPlayerRestrictions(
            Guid playerID,
            List<PlayerRestriction> actions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                SetRestrictionsAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "restrictedActions", string.Join(",", actions.Select(c=> (int)c)) }
                }
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> SetPlayerRestrictionsAsync(
            Guid playerID,
            List<PlayerRestriction> actions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                SetRestrictionsAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "playerID", playerID.ToString() },
                    { "restrictedActions", string.Join(",", actions.Select(c=> (int)c)) }
                }
            );
        }
    }
}
