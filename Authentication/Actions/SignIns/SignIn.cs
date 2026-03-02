using ConstructServices.Authentication.Objects;
using ConstructServices.Authentication.Responses;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class SignIns
{
    extension(AuthenticationService service)
    {
        /// <summary>
        /// Create a new sign in request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in" />
        [UsedImplicitly]
        public SignInResponse SignIn(SignInOptions signInOptions)
        {
            return Common.Request.ExecuteSyncRequest<SignInResponse>(
                Config.EndPointPaths.SignIns.SignIn,
                service,
                signInOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Create a new sign in request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in" />
        [UsedImplicitly]
        public async Task<SignInResponse> SignInAsync(SignInOptions signInOptions)
        {
            return await Common.Request.ExecuteAsyncRequest<SignInResponse>(
                Config.EndPointPaths.SignIns.SignIn,
                service,
                signInOptions.BuildFormData()
            );
        }
    }
}