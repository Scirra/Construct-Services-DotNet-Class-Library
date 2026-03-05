using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Authentication;

[UsedImplicitly]
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

[UsedImplicitly]
public sealed class AuthenticationService : AuthenticationServiceBase
{
    public AuthenticationService(Guid gameID) : base(gameID) { }
    public AuthenticationService(Guid gameID, SecretAPIKey aPIKey) : base(gameID, aPIKey, null) { }
}

[UsedImplicitly]
public sealed class PlayerAuthenticationService : AuthenticationServiceBase
{
    public PlayerAuthenticationService(Guid gameID, SessionKey sessionKey) : base(gameID, null, sessionKey) { }
}
