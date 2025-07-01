using System;

namespace ConstructServices.Authentication
{
    public class AuthenticationService
    {
        internal Guid GameID { get; private set; }
        internal string APIKey { get; private set; }

        /// <summary>
        /// Create a new instance of auth service
        /// </summary>
        /// <param name="gameID">Game ID service is for</param>
        /// <param name="aPIKey">Optional API key, may be required for some request types and should never be exposed client side.</param>
        public AuthenticationService(Guid gameID, string aPIKey = null)
        {
            GameID = gameID;
            APIKey = aPIKey;
        }

        /// <summary>
        /// Create a new instance of auth service
        /// </summary>
        /// <param name="strGameID">Game ID service is for.  Should be parsable as a GUID or will throw an exception.</param>
        /// <param name="aPIKey">Optional API key, may be required for some request types and should never be exposed client side.</param>
        public AuthenticationService(string strGameID, string aPIKey = null)
        {
            if(!Guid.TryParse(strGameID, out var gameID))
            {
                throw new Exception("Passed game ID not a valid GUID.");
            }
            GameID = gameID;
            APIKey = aPIKey;
        }
    }
}
