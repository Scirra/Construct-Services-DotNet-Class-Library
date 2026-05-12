using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Authentication;

public abstract class AuthenticationServiceBase : BaseService
{
    internal AuthenticationServiceBase(Guid gameID, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, httpTimeout)
    {
    }
    internal AuthenticationServiceBase(Guid gameID, SecretAPIKey aPiKey, SessionKey sessionKey, TimeSpan? httpTimeout = null) : base(gameID, Config.APIDomain, aPiKey, sessionKey, httpTimeout)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}

public sealed class AuthenticationService : AuthenticationServiceBase
{
    [UsedImplicitly]
    public AuthenticationService(Guid gameID, TimeSpan? httpTimeout = null) : base(gameID, httpTimeout) { }
    public AuthenticationService(Guid gameID, SecretAPIKey aPIKey, TimeSpan? httpTimeout = null) : base(gameID, aPIKey, null, httpTimeout) { }
}

[method: UsedImplicitly]
public sealed class PlayerAuthenticationService(Guid gameID, SessionKey sessionKey, TimeSpan? httpTimeout = null)
    : AuthenticationServiceBase(gameID, null, sessionKey, httpTimeout);
