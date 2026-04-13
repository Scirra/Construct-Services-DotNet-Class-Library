using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Authentication;

public abstract class AuthenticationServiceBase : BaseService
{
    internal AuthenticationServiceBase(Guid gameID) : base(gameID, Config.APIDomain)
    {
    }
    internal AuthenticationServiceBase(Guid gameID, SecretAPIKey aPiKey, SessionKey sessionKey) : base(gameID, Config.APIDomain, aPiKey, sessionKey)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}

public sealed class AuthenticationService : AuthenticationServiceBase
{
    [UsedImplicitly]
    public AuthenticationService(Guid gameID) : base(gameID) { }
    public AuthenticationService(Guid gameID, SecretAPIKey aPIKey) : base(gameID, aPIKey, null) { }
}

[method: UsedImplicitly]
public sealed class PlayerAuthenticationService(Guid gameID, SessionKey sessionKey)
    : AuthenticationServiceBase(gameID, null, sessionKey);
