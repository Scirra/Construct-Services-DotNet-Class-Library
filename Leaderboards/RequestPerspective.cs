using System;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards;

[UsedImplicitly]
public sealed class RequestPerspective(string requesterIP, Guid? requesterPlayerID = null)
{
    internal string RequesterIP { get; } = requesterIP;
    internal Guid? RequesterPlayerID { get; } = requesterPlayerID;
}