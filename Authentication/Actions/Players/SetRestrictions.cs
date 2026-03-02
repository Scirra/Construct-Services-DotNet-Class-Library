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
        public BaseResponse SetPlayerRestrictions(SetPlayerRestrictionsOptions setPlayerRestrictionsOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetRestrictions,
                service,
                setPlayerRestrictionsOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Set restrictions for a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/set-player-restrictions" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetPlayerRestrictionsAsync(SetPlayerRestrictionsOptions setPlayerRestrictionsOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Players.SetRestrictions,
                service,
                setPlayerRestrictionsOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class SetPlayerRestrictionsOptions(Guid playerID, List<PlayerRestriction> restrictions)
    {
        private Guid PlayerID { get; } = playerID;
        private List<PlayerRestriction> Restrictions { get; } = restrictions;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "playerID", PlayerID.ToString() }
            };
            if (Restrictions != null)
            {
                formData.Add("restrictedActions", string.Join(",", Restrictions.Select(c=> (int)c)));
            }
            return formData;
        }
    }
}
