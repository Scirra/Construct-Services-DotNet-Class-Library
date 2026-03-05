using System;
using System.Collections.Generic;
using ConstructServices.Authentication.Objects;
using ConstructServices.Authentication.Responses;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Logins
{
    extension(AuthenticationServiceBase service)
    {
        /// <summary>
        /// Create a new login request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in" />
        [UsedImplicitly]
        public LoginResponse Login(LoginProvider provider, LoginOptions loginOptions = null)
        {
            return provider switch
            {
                LoginProvider.UsernamePassword =>
                    throw new Exception("Call Login(username, password) method instead."),
                LoginProvider.Email => throw new Exception("Call Login(emailAddress) method instead."),
                _ => Request.ExecuteSyncRequest<LoginResponse>(Config.EndPointPaths.Logins.Login, service,
                    LoginOptions.BuildFormData(provider, loginOptions))
            };
        }

        /// <summary>
        /// Create a new login request
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in" />
        [UsedImplicitly]
        public async Task<LoginResponse> LoginAsync(LoginProvider provider, LoginOptions loginOptions = null)
        {
            return provider switch
            {
                LoginProvider.UsernamePassword =>
                    throw new Exception("Call Login(username, password) method instead."),
                LoginProvider.Email => throw new Exception("Call Login(emailAddress) method instead."),
                _ => await Request.ExecuteAsyncRequest<LoginResponse>(Config.EndPointPaths.Logins.Login,
                    service, LoginOptions.BuildFormData(provider, loginOptions))
            };
        }

        /// <summary>
        /// Create a new login request with a username and password.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in" />
        [UsedImplicitly]
        public LoginResponse Login(string username, string password, LoginOptions loginOptions = null)
        {
            var usernameValidation = Common.Validations.Authentication.Functions.IsPasswordValid(username);
            if (!usernameValidation.Valid) return new LoginResponse(usernameValidation.ErrorMessage);

            var passwordValidation = Common.Validations.Authentication.Functions.IsPasswordValid(password);
            if (!passwordValidation.Valid) return new LoginResponse(passwordValidation.ErrorMessage);

            return Request.ExecuteSyncRequest<LoginResponse>(
                Config.EndPointPaths.Logins.Login,
                service,
                LoginOptions.BuildFormData(username, password, loginOptions)
            );
        }

        /// <summary>
        /// Create a new login request with a username and password.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in" />
        [UsedImplicitly]
        public async Task<LoginResponse> LoginAsync(string username, string password, LoginOptions loginOptions = null)
        {
            var usernameValidation = Common.Validations.Authentication.Functions.IsPasswordValid(username);
            if (!usernameValidation.Valid) return new LoginResponse(usernameValidation.ErrorMessage);

            var passwordValidation = Common.Validations.Authentication.Functions.IsPasswordValid(password);
            if (!passwordValidation.Valid) return new LoginResponse(passwordValidation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<LoginResponse>(
                Config.EndPointPaths.Logins.Login,
                service,
                LoginOptions.BuildFormData(username, password, loginOptions)
            );
        }

        /// <summary>
        /// Create a new login request with an email address
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in" />
        [UsedImplicitly]
        public LoginResponse Login(string emailAddress, LoginOptions loginOptions = null)
        {
            var emailValidation = Common.Validations.Authentication.Functions.IsEmailAddressValid(emailAddress);
            if (!emailValidation.Valid) return new LoginResponse(emailValidation.ErrorMessage);

            return Request.ExecuteSyncRequest<LoginResponse>(
                Config.EndPointPaths.Logins.Login,
                service,
                LoginOptions.BuildFormData(emailAddress, loginOptions)
            );
        }

        /// <summary>
        /// Create a new login request with an email address
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/players/sign-in" />
        [UsedImplicitly]
        public async Task<LoginResponse> LoginAsync(string emailAddress, LoginOptions loginOptions = null)
        {
            var emailValidation = Common.Validations.Authentication.Functions.IsEmailAddressValid(emailAddress);
            if (!emailValidation.Valid) return new LoginResponse(emailValidation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<LoginResponse>(
                Config.EndPointPaths.Logins.Login,
                service,
                LoginOptions.BuildFormData(emailAddress, loginOptions)
            );
        }
    }
    
    [UsedImplicitly]
    public class LoginOptions
    {
        [UsedImplicitly]
        public TimeSpan? SessionExpiry { private get; set; }
        
        internal static Dictionary<string, string> BuildFormData(LoginProvider provider, LoginOptions options)
        {
            var formData = new Dictionary<string, string>
            {
                { "provider", provider.ToString() }
            };
            if (options?.SessionExpiry != null)
            {
                formData.Add("expiryMins", Convert.ToInt32(options.SessionExpiry.Value.TotalMinutes).ToString());
            }
            return formData;
        }
        internal static Dictionary<string, string> BuildFormData(string username, string password, LoginOptions options)
        {
            var formData = new Dictionary<string, string>
            {
                { "provider", nameof(LoginProvider.UsernamePassword) },
                { "username", username },
                { "password", password }
            };
            if (options?.SessionExpiry != null)
            {
                formData.Add("expiryMins", Convert.ToInt32(options.SessionExpiry.Value.TotalMinutes).ToString());
            }
            return formData;
        }
        internal static Dictionary<string, string> BuildFormData(string emailAddress, LoginOptions options)
        {
            var formData = new Dictionary<string, string>
            {
                { "provider", nameof(LoginProvider.Email) },
                { "emailAddress", emailAddress }
            };
            if (options?.SessionExpiry != null)
            {
                formData.Add("expiryMins", Convert.ToInt32(options.SessionExpiry.Value.TotalMinutes).ToString());
            }
            return formData;
        }
    }
}