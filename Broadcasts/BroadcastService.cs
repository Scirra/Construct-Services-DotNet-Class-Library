using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Broadcasts;

[UsedImplicitly]
public class BroadcastService : BaseService
{
    /// <summary>
    /// Create a new instance of the broadcast service
    /// </summary>
    /// <param name="gameID">Game ID service is for</param>
    /// <param name="aPIKey">API key</param>
    public BroadcastService(Guid gameID, string aPIKey) : base(gameID, Config.APIDomain, aPIKey)
    {
    }

    /// <summary>
    /// Create a new instance of the broadcast service
    /// </summary>
    /// <param name="gameID">Game ID service is for</param>
    public BroadcastService(Guid gameID) : base(gameID, Config.APIDomain)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}