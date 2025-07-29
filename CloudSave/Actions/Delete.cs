using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    /// <summary>
    /// Delete a cloud save
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse Delete(
        this CloudSaveService service,
        Guid cloudSaveID)
    {
        var formData = new Dictionary<string, string>
        {
            { "blobID", cloudSaveID.ToString() }
        };

        const string path = "/delete.json";
        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            formData
        )).Result;
    }

    /// <summary>
    /// Delete a cloud save
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse Delete(
        this CloudSaveService service,
        string sessionKey,
        Guid cloudSaveID)
    {
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", sessionKey },
            { "blobID", cloudSaveID.ToString() }
        };

        const string path = "/delete.json";
        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            formData
        )).Result;
    }
}