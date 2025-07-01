using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConstructServices.Authentication
{
    internal static class Request
    {
        internal static async Task<T> ExecuteAuthenticationRequest<T>(
            string relativeEndPointPath,
            AuthenticationService service,
            Dictionary<string, string> formData) where T : BaseResponse
        {
            // Add form data
            if (formData == null) formData = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(service.APIKey))
                formData.Add("secret", service.APIKey);
            formData.Add("gameID", service.GameID.ToString());
            
            // Get URL to query
            string apiURL;
            {
                if (!relativeEndPointPath.StartsWith("/")) relativeEndPointPath = "/" + relativeEndPointPath;
                var domain = Config.APIDomain;
                apiURL = domain + relativeEndPointPath;
            }

            string json;
            using (var formContent = new FormUrlEncodedContent(formData))
            {
                try
                {
                    // Accept self-signed
                    if (GlobalConfig.DevMode)
                    {
                        var handler = new HttpClientHandler
                        {
                            ClientCertificateOptions = ClientCertificateOption.Manual,
                            ServerCertificateCustomValidationCallback = (_, _, _, _) => true
                        };
                        using (var httpClient = new HttpClient(handler))
                        {
                            using (var response = await httpClient.PostAsync(apiURL, formContent))
                            {
                                json = await response.Content.ReadAsStringAsync();
                            }
                        }
                    }
                    else
                    {
                        using (var httpClient = new HttpClient())
                        {
                            using (var response = await httpClient.PostAsync(apiURL, formContent))
                            {
                                json = await response.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return new BaseResponse(ex.Message, false) as T;
                }
            }
            if (!json.IsValidJson())
            {
                return (T)Activator.CreateInstance(typeof(T), "Response was not valid JSON.", false);
            }
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
