using System;
using System.Collections.Generic;
using System.Linq;
using ConstructServices.Authentication.Enums;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Objects;

[UsedImplicitly]
public sealed class ChangePasswordOptions
{
    private Guid? PlayerID { get; }
    private string SessionKey { get; }         
    private string NewPassword { get; }        
        
    public ChangePasswordOptions(string sessionKey, string newPassword)
    {
        SessionKey = sessionKey;
        NewPassword = newPassword;
    }
    public ChangePasswordOptions(Guid playerID, string newPassword)
    {
        PlayerID = playerID;
        NewPassword = newPassword;
    }
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "newPassword", NewPassword }
        };
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class ChangeUsernameOptions
{
    private Guid? PlayerID { get; }
    private string SessionKey { get; }         
    private string NewUsername { get; }        
        
    public ChangeUsernameOptions(string sessionKey, string newUsername)
    {
        SessionKey = sessionKey;
        NewUsername = newUsername;
    }
    public ChangeUsernameOptions(Guid playerID, string newUsername)
    {
        PlayerID = playerID;
        NewUsername = newUsername;
    }
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "username", NewUsername }
        };
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class SetUsernameAndPasswordOptions
{
    private Guid? PlayerID { get; }
    private string SessionKey { get; }         
    private string Username { get; }      
    private string Password { get; }       
        
    public SetUsernameAndPasswordOptions(string sessionKey, string username, string password)
    {
        SessionKey = sessionKey;
        Username = username;
        Password = password;
    }
    public SetUsernameAndPasswordOptions(Guid playerID, string username, string password)
    {
        PlayerID = playerID;
        Username = username;
        Password = password;
    }
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "username", Username },
            { "password", Password }
        };
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}
[UsedImplicitly]
public sealed class ChangePlayerNameOptions
{
    private Guid? PlayerID { get; }
    private string SessionKey { get; }         
    private string Name { get; }        
        
    public ChangePlayerNameOptions(string sessionKey, string name)
    {
        SessionKey = sessionKey;
        Name = name;
    }
    public ChangePlayerNameOptions(Guid playerID, string name)
    {
        PlayerID = playerID;
        Name = name;
    }
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "playerName", Name }
        };
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class DeletePlayerOptions
{
    private Guid? PlayerID { get; }
    private string SessionKey { get; }       
        
    public DeletePlayerOptions(string sessionKey)
    {
        SessionKey = sessionKey;
    }
    public DeletePlayerOptions(Guid playerID)
    {
        PlayerID = playerID;
    }
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class ForgottenPasswordOptions(string emailAddress)
{
    private string EmailAddress { get; } = emailAddress;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "emailAddress", EmailAddress }
        };
        return formData;
    }
}

[UsedImplicitly]
public sealed class GetPlayerOptions
{
    private Guid? PlayerID { get; }
    private string PlayerName { get; }       
        
    public GetPlayerOptions(string playerName)
    {
        PlayerName = playerName;
    }
    public GetPlayerOptions(Guid playerID)
    {
        PlayerID = playerID;
    }
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (!string.IsNullOrWhiteSpace(PlayerName))
        {
            formData.Add("playerName", PlayerName);
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class GetPlayersOptions
{
    private List<Guid> PlayerIDs { get; }    
        
    public GetPlayersOptions(List<Guid> playerIDs)
    {
        PlayerIDs = playerIDs;
    }
    public GetPlayersOptions(Guid playerID)
    {
        PlayerIDs = [playerID];
    }
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (PlayerIDs != null)
        {
            formData.Add("playerIDs", string.Join(",", PlayerIDs));
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class ListLoginProviderOptions(string sessionKey)
{
    private string SessionKey { get; } = sessionKey;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", SessionKey }
        };
        return formData;
    }
}


[UsedImplicitly]
public sealed class SetEmailAddressOptions
{
    private Guid? PlayerID { get; }
    private string SessionKey { get; }         
    private string EmailAddress { get; }        
        
    public SetEmailAddressOptions(string sessionKey, string emailAddress)
    {
        SessionKey = sessionKey;
        EmailAddress = emailAddress;
    }
    public SetEmailAddressOptions(Guid playerID, string emailAddress)
    {
        PlayerID = playerID;
        EmailAddress = emailAddress;
    }
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "emailAddress", EmailAddress }
        };
        if (PlayerID.HasValue)
        {
            formData.Add("playerID", PlayerID.Value.ToString());
        }
        if (!string.IsNullOrWhiteSpace(SessionKey))
        {
            formData.Add("sessionKey", SessionKey);
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class SetPlayerRestrictionsOptions(Guid playerID, List<PlayerRestriction> restrictions)
{
    private Guid PlayerID { get; } = playerID;
    private List<PlayerRestriction> Restrictions { get; } = restrictions;

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "playerID", PlayerID.ToString() }
        };
        if (Restrictions != null)
        {
            formData.Add("restrictedActions", string.Join(",", Restrictions.Select(c=> (int)c)));
        }
        return formData;
    }
}

[UsedImplicitly]
public sealed class CreatePlayerOptions(
    string playerName,
    string emailAddress,
    string username,
    string password,
    TimeSpan? sessionExpiry = null)
{
    private string PlayerName { get; } = playerName;
    private string Username { get; } = username;
    private string Password { get; } = password;
    private string EmailAddress { get; } = emailAddress;
    private TimeSpan? SessionExpiry { get; } = sessionExpiry;

    public CreatePlayerOptions(string playerName, TimeSpan? sessionExpiry = null) : this(playerName, null, null, null, null)
    {
    }
    public CreatePlayerOptions(string playerName, string emailAddress, TimeSpan? sessionExpiry = null) : this(playerName, emailAddress, null, null, null)
    {
    }
    public CreatePlayerOptions(string playerName, string username, string password, TimeSpan? sessionExpiry = null) : this(playerName, null, username, password)
    {
    }

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "playerName", PlayerName }
        };
        if (!string.IsNullOrWhiteSpace(EmailAddress))
        {
            formData.Add("emailAddress", EmailAddress);
        }
        if (!string.IsNullOrWhiteSpace(Username))
        {
            formData.Add("username", Username);
        }
        if (!string.IsNullOrWhiteSpace(Password))
        {
            formData.Add("password", Password);
        }
        if (SessionExpiry.HasValue)
        {
            formData.Add("expiryMins", Convert.ToInt32(SessionExpiry.Value.TotalMinutes).ToString());
        }
        return formData;
    }
}