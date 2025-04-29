namespace ConstructServices.Leaderboards
{
    public class RequestPerspective
    {
        internal string RequesterIP { get; set; }
        internal string RequesterPlayerID { get; set; }
        
        public RequestPerspective(string requesterIP)
        {
            RequesterIP = requesterIP;
        }
        public RequestPerspective(string requesterIP, string requesterPlayerID)
        {
            RequesterIP = requesterIP;
            RequesterPlayerID = requesterPlayerID;
        }
    }
}
