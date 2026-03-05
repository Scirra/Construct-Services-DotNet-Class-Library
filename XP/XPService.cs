using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.XP;

[UsedImplicitly]
public class XPService : BaseService
{
    /// <summary>
    /// Create new service instance for requests that do not require any authentication
    /// </summary>
    /// <param name="gameID">ID of the game to run requests against</param>
    public XPService(Guid gameID) : base(gameID, Config.APIDomain) { }
    
    /// <summary>
    /// Create a new service instance for requests authenticated with a secret API key
    /// </summary>
    /// <param name="gameID">ID of the game to run requests against</param>
    /// <param name="aPIKey">Your games secret API key</param>
    public XPService(Guid gameID, SecretAPIKey aPIKey) : base(gameID, Config.APIDomain, aPIKey, null) { }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}