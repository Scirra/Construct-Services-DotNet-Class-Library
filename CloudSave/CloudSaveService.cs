using ConstructServices.Common;
using JetBrains.Annotations;
using System;

namespace ConstructServices.CloudSave;

[UsedImplicitly]
public class CloudSaveService : BaseService
{
    internal Guid GameID { get; private set; }

    /// <summary>
    /// Create a new instance of auth service
    /// </summary>
    /// <param name="gameID">Game ID service is for</param>
    /// <param name="aPIKey">API key</param>
    public CloudSaveService(Guid gameID, string aPIKey) : base(aPIKey)
    {
        GameID = gameID;
    }

    /// <summary>
    /// Create a new instance of auth service
    /// </summary>
    /// <param name="strGameID">Game ID service is for</param>
    /// <param name="aPIKey">API key</param>
    public CloudSaveService(string strGameID, string aPIKey) : base(aPIKey)
    {
        if(!Guid.TryParse(strGameID, out var gameID) || gameID == Guid.Empty)
        {
            throw new Exception("Passed game ID not a valid GUID.");
        }
        GameID = gameID;
    }

    /// <summary>
    /// Create a new instance of auth service
    /// </summary>
    /// <param name="gameID">Game ID service is for</param>
    public CloudSaveService(Guid gameID)
    {
        GameID = gameID;
    }
}