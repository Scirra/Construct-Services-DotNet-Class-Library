using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}