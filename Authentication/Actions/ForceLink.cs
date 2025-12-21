using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    private const string ForceLinkAPIPath = "/forcelink.json";
    
    extension(AuthenticationService service)
    {
        [UsedImplicitly]
        public LinkLoginProviderResponse ForceLinkLoginProvider(string forceLinkCode)
        {
            var validator = Common.Validations.ForceLinkCode.ValidateForceLinkCode(forceLinkCode);
            if (!validator.Successfull)
            {
                return new LinkLoginProviderResponse(validator.ErrorMessage, false);
            }

            return Request.ExecuteSyncRequest<LinkLoginProviderResponse>(
                ForceLinkAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "code", forceLinkCode }
                }
            );
        }

        [UsedImplicitly]
        public async Task<LinkLoginProviderResponse> ForceLinkLoginProviderAsync(string forceLinkCode)
        {
            var validator = Common.Validations.ForceLinkCode.ValidateForceLinkCode(forceLinkCode);
            if (!validator.Successfull)
            {
                return new LinkLoginProviderResponse(validator.ErrorMessage, false);
            }

            return await Request.ExecuteAsyncRequest<LinkLoginProviderResponse>(
                ForceLinkAPIPath,
                service,
                new Dictionary<string, string>
                {
                    { "code", forceLinkCode }
                }
            );
        }
    }
}