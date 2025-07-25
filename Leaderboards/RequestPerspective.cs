using System;

namespace ConstructServices.Leaderboards;

public class RequestPerspective
{
    internal string RequesterIP { get; set; }
    internal Guid? RequesterPlayerID { get; set; }
        
    public RequestPerspective(string requesterIP)
    {
        RequesterIP = requesterIP;
        RequesterPlayerID = null;
    }
    public RequestPerspective(string requesterIP, Guid? requesterPlayerID)
    {
        RequesterIP = requesterIP;
        RequesterPlayerID = requesterPlayerID;
    }
}