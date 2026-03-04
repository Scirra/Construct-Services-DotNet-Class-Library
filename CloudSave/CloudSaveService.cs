using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.CloudSave;

[UsedImplicitly]
public class CloudSaveService : BaseService
{
    /// <summary>
    /// Create new service instance for requests that do not require any authentication
    /// </summary>
    /// <param name="gameID">ID of the game to run requests against</param>
    public CloudSaveService(Guid gameID) : base(gameID, Config.APIDomain) { }
    
    /// <summary>
    /// Create a new service instance for requests authenticated with a secret API key
    /// </summary>
    /// <param name="gameID">ID of the game to run requests against</param>
    /// <param name="aPIKey">Your games secret API key</param>
    public CloudSaveService(Guid gameID, SecretAPIKey aPIKey) : base(gameID, Config.APIDomain, aPIKey) { }
    
    /// <summary>
    /// Create a new service instance for requests authenticated with a players session key
    /// </summary>
    /// <param name="gameID">ID of the game to run requests against</param>
    /// <param name="sessionKey">The players session key</param>
    public CloudSaveService(Guid gameID, SessionKey sessionKey) : base(gameID, Config.APIDomain, sessionKey) { }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}