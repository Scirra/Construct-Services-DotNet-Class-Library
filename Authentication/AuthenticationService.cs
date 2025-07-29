using ConstructServices.Common;
using JetBrains.Annotations;
using System;

namespace ConstructServices.Authentication;

[UsedImplicitly]
public class AuthenticationService : BaseService
{
    /// <summary>
    /// Create a new instance of auth service
    /// </summary>
    /// <param name="gameID">Game ID service is for</param>
    /// <param name="aPIKey">API key</param>
    public AuthenticationService(Guid gameID, string aPIKey) : base(gameID, Config.APIDomain, aPIKey)
    {

    }
    
    /// <summary>
    /// Create a new instance of auth service
    /// </summary>
    /// <param name="gameID">Game ID service is for</param>
    public AuthenticationService(Guid gameID) : base(gameID, Config.APIDomain)
    {
    }
}