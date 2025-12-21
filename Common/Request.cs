using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConstructServices.Common.Validations;

namespace ConstructServices.Common;

internal static class Request
{
    internal static T ExecuteMultiPartFormSyncRequest<T>(
        string relativeEndPointPath,
        BaseService service,
        Dictionary<string, string> formData,
        Dictionary<string, ByteArrayContent> files) where T : BaseResponse
    {           
        return ExecuteMultiPartFormAsyncRequest<T>(
            relativeEndPointPath,
            service,
            formData,
            files
        ).GetAwaiter().GetResult();
    }  
    internal static async Task<T> ExecuteMultiPartFormAsyncRequest<T>(
        string relativeEndPointPath,
        BaseService service,
        Dictionary<string, string> formData,
        Dictionary<string, ByteArrayContent> files) where T : BaseResponse
    {
        // Get URL to query
        string apiURL;
        {
            if (!relativeEndPointPath.StartsWith("/", StringComparison.Ordinal))
                relativeEndPointPath = "/" + relativeEndPointPath;
            apiURL = service.APIHost + relativeEndPointPath;
        }

        string json;
        using (var formContent = new MultipartFormDataContent())
        {
            // Add form data
            if (service.APIKey != null)
                formContent.Add(new StringContent(service.APIKey.Key), "secret");
            formContent.Add(new StringContent(service.GameID.ToString()), "gameID");
            if (formData != null)
            {
                service.AddServiceSpecificFormData(formData);
                foreach (var kvp in formData)
                {
                    formContent.Add(new StringContent(kvp.Value), kvp.Key);
                }
            }

            var i = 0;
            foreach (var file in files)
            {
                var fileName = "file" + i;
                if (!string.IsNullOrWhiteSpace(file.Key))
                {
                    fileName = file.Key;
                }

                formContent.Add(file.Value, fileName, fileName);
                i++;
            }

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
                    using var httpClient = new HttpClient(handler);
                    using (var response = await httpClient.PostAsync(apiURL, formContent))
                    {
                        json = await response.Content.ReadAsStringAsync();
                    }
                }
                else
                {
                    using var httpClient = new HttpClient();
                    using (var response = await httpClient.PostAsync(apiURL, formContent))
                    {
                        json = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message) as T;
            }
        }

        if (!json.IsValidJson())
        {
            return (T)Activator.CreateInstance(typeof(T), "Response was not valid JSON.", false);
        }

        return JsonConvert.DeserializeObject<T>(json);
    }

    internal static T ExecuteSyncRequest<T>(
        string relativeEndPointPath,
        BaseService service,
        Dictionary<string, string> formData,
        PaginationOptions paginationOptions = null) where T : BaseResponse
    {           
        return ExecuteAsyncRequest<T>(
            relativeEndPointPath,
            service,
            formData,
            paginationOptions
        ).GetAwaiter().GetResult();
    }  

    internal static async Task<T> ExecuteAsyncRequest<T>(
        string relativeEndPointPath,
        BaseService service,
        Dictionary<string, string> formData,
        PaginationOptions paginationOptions = null) where T : BaseResponse
    {
        // Add form data
        formData ??= new Dictionary<string, string>();
        if (service.APIKey != null)
            formData.Add("secret", service.APIKey.Key);
        formData.Add("gameID", service.GameID.ToString());
        service.AddServiceSpecificFormData(formData);

        if (!string.IsNullOrWhiteSpace(service.RequestedLanguage))
        {
            formData.Add("requestedLanguage", service.RequestedLanguage.Trim());
        }
        if (service.Culture != null)
        {
            formData.Add("culture", service.Culture.ToString());
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
            if (!relativeEndPointPath.StartsWith("/", StringComparison.Ordinal)) relativeEndPointPath = "/" + relativeEndPointPath;
            apiURL = service.APIHost + relativeEndPointPath;
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
                    using var httpClient = new HttpClient(handler);
                    using (var response = await httpClient.PostAsync(apiURL, formContent))
                    {
                        json = await response.Content.ReadAsStringAsync();
                    }
                }
                else
                {
                    using var httpClient = new HttpClient();
                    using (var response = await httpClient.PostAsync(apiURL, formContent))
                    {
                        json = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message) as T;
            }
        }
        if (!json.IsValidJson())
        {
            return (T)Activator.CreateInstance(typeof(T), "Response was not valid JSON.", false);
        }
        return JsonConvert.DeserializeObject<T>(json);
    }
    internal static async Task<byte[]> DownloadBytes(
        Uri absolutePath,
        BaseService service,
        string sessionKey = null)
    {        
        // Add form data
        var formData = new Dictionary<string, string>();
        if (service.APIKey != null)
            formData.Add("secret", service.APIKey.Key);
        formData.Add("gameID", service.GameID.ToString());
        if (!string.IsNullOrWhiteSpace(sessionKey))
            formData.Add("sessionKey", sessionKey);
        service.AddServiceSpecificFormData(formData);

        byte[] r;
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
                    using var httpClient = new HttpClient(handler);
                    using (var response = await httpClient.PostAsync(absolutePath, formContent))
                    {
                        r = await response.Content.ReadAsByteArrayAsync();
                    }
                }
                else
                {
                    using var httpClient = new HttpClient();
                    using (var response = await httpClient.PostAsync(absolutePath, formContent))
                    {
                        r = await response.Content.ReadAsByteArrayAsync();
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        return r;
    }
}