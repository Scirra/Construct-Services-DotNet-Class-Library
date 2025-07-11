using System;
using JetBrains.Annotations;

namespace ConstructServices.Authentication
{
    [UsedImplicitly]
    public class AuthenticationService
    {
        internal Guid GameID { get; private set; }
        internal string APIKey { get; private set; }
        
        /// <summary>
        /// Create a new instance of auth service
        /// </summary>
        /// <param name="gameID">Game ID service is for</param>
        /// <param name="aPIKey">API key</param>
        public AuthenticationService(Guid gameID, string aPIKey)
        {
            GameID = gameID;
            APIKey = aPIKey;
        }

        /// <summary>
        /// Create a new instance of auth service
        /// </summary>
        /// <param name="strGameID">Game ID service is for</param>
        /// <param name="aPIKey">API key</param>
        public AuthenticationService(string strGameID, string aPIKey)
        {
            if(!Guid.TryParse(strGameID, out var gameID) || gameID == Guid.Empty)
            {
                throw new Exception("Passed game ID not a valid GUID.");
            }
            GameID = gameID;
            APIKey = aPIKey;
        }
    }
}
