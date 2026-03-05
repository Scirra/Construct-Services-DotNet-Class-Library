using System;
using System.Collections.Generic;
using System.Linq;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Authentication.Enums;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Set restrictions for a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-player-restrictions" />
        [UsedImplicitly]
        public BaseResponse SetPlayerRestrictions(Guid playerID, IEnumerable<PlayerRestriction> restrictions)
        {
            if (!playerID.IsValidGuid()) return new BaseResponse(Validations.InvalidGuidError);

            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetRestrictions,
                service,
                SetPlayerRestrictionsOptions.BuildFormData(playerID, restrictions)
            );
        }

        /// <summary>
        /// Set restrictions for a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-player-restrictions" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetPlayerRestrictionsAsync(Guid playerID, IEnumerable<PlayerRestriction> restrictions)
        {
            if (!playerID.IsValidGuid()) return new BaseResponse(Validations.InvalidGuidError);

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetRestrictions,
                service,
                SetPlayerRestrictionsOptions.BuildFormData(playerID, restrictions)
            );
        }
    }

    private static class SetPlayerRestrictionsOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid playerID, IEnumerable<PlayerRestriction> restrictions)
        {
            var formData = new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() }
            };
            if (restrictions != null)
            {
                formData.Add("restrictedActions", string.Join(",", restrictions.Distinct().Select(c=> (int)c)));
            }
            return formData;
        }
    }
}
