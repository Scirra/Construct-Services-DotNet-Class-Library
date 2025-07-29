using ConstructServices.CloudSave.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    /// <summary>
    /// Get a cloud save by its ID
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse Get(
        this CloudSaveService service,
        Guid cloudSaveID)
    {
        var formData = new Dictionary<string, string>
        {
            { "cloudSaveID", cloudSaveID.ToString() }
        };
        const string path = "/getcloudsave.json";
        return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
            path,
            service,
            formData
        )).Result;
    }
    /// <summary>
    /// Get a cloud save by its ID
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse Get(
        this CloudSaveService service,
        string sessionKey,
        Guid cloudSaveID)
    {
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", sessionKey },
            { "cloudSaveID", cloudSaveID.ToString() }
        };
        const string path = "/getcloudsave.json";
        return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
            path,
            service,
            formData
        )).Result;
    }
}