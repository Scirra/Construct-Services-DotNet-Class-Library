using ConstructServices.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards;

internal static class Request
{
    internal static async Task<T> ExecuteLeaderboardRequest<T>(
        string relativeEndPointPath,
        LeaderboardService service,
        Dictionary<string, string> formData,
        RequestPerspective requestPerspective = null,
        PaginationOptions paginationOptions = null) where T : BaseResponse
    {
        // Add form data
        if (formData == null) formData = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(service.APIKey))
            formData.Add("secret", service.APIKey);
        formData.Add("leaderboardID", service.LeaderboardID.ToString());
        if(service.Culture != null) formData.Add("culture", service.Culture.ToString());

        // Add perspective
        if (requestPerspective != null)
        {
            formData.Add("requesterIP", requestPerspective.RequesterIP);
            if (requestPerspective.RequesterPlayerID.HasValue)
            {
                formData.Add("requesterPlayerID", requestPerspective.RequesterPlayerID.Value.ToString());
            }
        }

        // Pagination
        if (paginationOptions != null)
        {
            formData.Add("page", paginationOptions.RequestedPage.ToString());
            if (paginationOptions.RecordsPerPage.HasValue)
            {
                formData.Add("perPage", paginationOptions.RecordsPerPage.Value.ToString());
            }
        }

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