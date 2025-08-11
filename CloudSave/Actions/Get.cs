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
    /// Get a cloud save by its key
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse GetByKey(
        this CloudSaveService service,
        string cloudSaveKey)
    {
        var formData = new Dictionary<string, string>
        {
            { "key", cloudSaveKey }
        };
        const string path = "/getcloudsave.json";
        return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
            path,
            service,
            formData
        )).Result;
    }

    /// <summary>
    /// Get a cloud save in a bucket by its key
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse GetByID(
        this CloudSaveService service,
        Guid bucketID,
        string cloudSaveKey)
    {
        var formData = new Dictionary<string, string>
        {
            { "blobID", cloudSaveKey },
            { "bucketID", bucketID.ToString() }
        };
        const string path = "/getcloudsave.json";
        return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
            path,
            service,
            formData
        )).Result;
    }
    
    /// <summary>
    /// Get a cloud save in a bucket by its key
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse GetByID(
        this CloudSaveService service,
        string sessionKey,
        Guid bucketID,
        string cloudSaveKey)
    {
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", sessionKey },
            { "key", cloudSaveKey },
            { "bucketID", bucketID.ToString() }
        };
        const string path = "/getcloudsave.json";
        return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
            path,
            service,
            formData
        )).Result;
    }

    /// <summary>
    /// Get a cloud save by its key
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse GetByID(
        this CloudSaveService service,
        string sessionKey,
        string cloudSaveKey)
    {
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", sessionKey },
            { "key", cloudSaveKey }
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
    public static CloudSaveResponse GetByID(
        this CloudSaveService service,
        Guid cloudSaveID)
    {
        var formData = new Dictionary<string, string>
        {
            { "blobID", cloudSaveID.ToString() }
        };
        const string path = "/getcloudsave.json";
        return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
            path,
            service,
            formData
        )).Result;
    }

    /// <summary>
    /// Get a cloud save in a bucket by its ID
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse GetByID(
        this CloudSaveService service,
        Guid bucketID,
        Guid cloudSaveID)
    {
        var formData = new Dictionary<string, string>
        {
            { "blobID", cloudSaveID.ToString() },
            { "bucketID", bucketID.ToString() }
        };
        const string path = "/getcloudsave.json";
        return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
            path,
            service,
            formData
        )).Result;
    }
    
    /// <summary>
    /// Get a cloud save in a bucket by its ID
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse GetByID(
        this CloudSaveService service,
        string sessionKey,
        Guid bucketID,
        Guid cloudSaveID)
    {
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", sessionKey },
            { "blobID", cloudSaveID.ToString() },
            { "bucketID", bucketID.ToString() }
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
    public static CloudSaveResponse GetByID(
        this CloudSaveService service,
        string sessionKey,
        Guid cloudSaveID)
    {
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", sessionKey },
            { "blobID", cloudSaveID.ToString() }
        };
        const string path = "/getcloudsave.json";
        return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
            path,
            service,
            formData
        )).Result;
    }
}