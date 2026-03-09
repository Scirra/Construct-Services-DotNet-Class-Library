# Authentication Service

For full documentation, please refer to the [full Construct Game Services docs][cgs-docs].  Please note, this library may contain some overload methods for convenience that do not have specific listed end points in the documentation.

> [!NOTE]
> A lot of these examples can be called from both an API key authenticated service, or player authenticated service.  The method call for each service may require additional parameters (for example, most requests authenticated with an API key require a player ID parameter).  In the interests of being concise, we have not given code examples for both types of services.

All methods are available as synchronous calls, and asynchronous calls.  All methods return an object that lets you know if the request succeeded or not.

# Authentication Service Examples

 - [The Authentication Service object][internal-service]  
   Create this object to make requests against this service

 - [Player examples][internal-players]  
   Register, list and update players

 - [Avatar examples][internal-avatars]  
   Set or delete a players avatar image

 - [Link Login Provider examples][internal-link]  
   Add additional login methods to an existing player

 - [Session examples][internal-sessions]  
   Refresh or end existing player sessions
   

# The Authentication Service Object

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

There are a few ways to construct a service object depending on your intentions:

### Requests where a secret API key is required

> [!WARNING]
> **Never** use the following code client side.  You are doing something wrong and potentially dangerous if you do this.

Pass in your game ID as a Guid, and your secret API key.  You can create API keys from your [CGS account][cgs-account].

```C#
var service = new AuthenticationService(
    yourGameID, 
    new SecretAPIKey("your-secret-key")
);
```

### Requests as a logged in player

> [!TIP]
> This is safe to use client side as well as server side.

If you are making requests on behalf of a logged in player, create a new Player service object passing in the players session key as follows:

```C#
var service = new PlayerAuthenticationService(
    yourGameID,
    new SessionKey("players-session-key")
);
```

### Requests where no authentication is required

Some requests do not require a secret key, or a player to be logged in.  You probably don't need to use this method, as the above two service objects can still call the end points that do not need authentication.

```C#
var service = new AuthenticationService(
    yourGameID
);
```

## A note on Player Names and Usernames

A player name is one that is shown to other players.  A username is optional, and is used for signing in.

# Players

## Register New Player

```C#
var registerPlayerResponse = service.RegisterPlayer(new RegisterPlayerOptions
{
    PlayerName = "Battle Pig",
    Username = "BattlePig86",
    Password = "MySecurePassword123!",
    EmailAddress = "test@test.com"
});
if (registerPlayerResponse.Success)
{
    var newPlayer = registerPlayerResponse.Player;
    var session = registerPlayerResponse.Session;
}
```

## Get a Player
```C#
// By player ID
var getPlayerByIDResponse = service.GetPlayer(playerID);
if (getPlayerByIDResponse.Success)
{
    var player = getPlayerByIDResponse.Player;
}

// By player name
var getPlayerByPlayerNameResponse = service.GetPlayer("Gamer Pig");
if (getPlayerByPlayerNameResponse.Success)
{
    var player = getPlayerByPlayerNameResponse.Player;
}

// Get expanded player (contains more properties in results)
var getExpandedPlayerResponse = service.GetExpandedPlayer(playerID);
if (getExpandedPlayerResponse.Success)
{
    var player = getExpandedPlayerResponse.Player;
}
```

## List Players
```C#
var listRecentlyActivePlayers = service.ListPlayers(
    new ListPlayersOptions {
        Ordering = PlayerOrdering.MostRecentlyActive
    }, 
    new PaginationOptions(1, 20)
);
if (listRecentlyActivePlayers.Success)
{
    var players = listRecentlyActivePlayers.Players;
}

// Get specific player IDs
var listPlayersByIDResponse = service.ListPlayers(
    new ListPlayersOptions {
        PlayerIDs = new[]
        {
            PlayerID1,
            PlayerID2
        },
    }, 
    new PaginationOptions(1, 20)
);
if (listPlayersByIDResponse.Success)
{
    var players = listPlayersByIDResponse.Players;
}
```

## Change Player Name
```C#
var changePlayerNameResponse = service.ChangePlayerName("Gamer Pig");
if (changePlayerNameResponse.Success)
{
    // Player name was updated
}
```

## Set Email Address
> [!TIP]
> This will send the player an email asking them to verify their email address.
> If your plan doesn't support emails, this request will fail.
```C#
var setEmailAddressResponse = service.SetEmailAddress("test@test.com");
if (setEmailAddressResponse.Success)
{
    // Email was set in unverified state
    // Email despatched for player to verify the email address
}
```

## Request Forgotten Password
> [!TIP]
> This will only send an email to the player if they have previously verified their email address.
> If your plan doesn't support emails, this request will fail.
```C#
var requestForgottenPasswordResponse = service.RequestForgottenPasswordEmail(
    "test@test.com"
);
if (requestForgottenPasswordResponse.Success)
{
    // Email despatched with link to reset password
}
```

## Delete Player
> [!WARNING]
> This is a permanent and irreversible action.  It is important for data privacy to always allow logged in players the ability to delete their account.
```C#
var deletePlayerResponse = service.DeletePlayer();
if (deletePlayerResponse.Success)
{
    // Player was deleted
}
```

# Avatars

## Set Players avatar

```C#
// Set from image URL
var setAvatarByURLResponse = service.SetAvatar(
    new PictureData(new Uri("https://www.example.com/picture.png"))
);
if (setAvatarByURLResponse.Success)
{
    // Avatar was set
}

// Set from base-64 encoded image data
var setAvatarByBase64DataResponse = service.SetAvatar(
    new PictureData(base64String)
);
if (setAvatarByBase64DataResponse.Success)
{
    // Avatar was set
}

// Set from binary picture data
byte[] data = getData();
var setAvatarByBinaryDataResponse = service.SetAvatar(
    new PictureData(data)
);
if (setAvatarByBinaryDataResponse.Success)
{
    // Avatar was set
}
```

## Delete Players Avatar
```C#
var deleteAvatarResponse = service.DeleteAvatar();
if (deleteAvatarResponse.Success)
{
    // Avatar was deleted
}
```

# Login

## Login Player
> [!NOTE]
> This returns a poll token and a redirect URL.  See the [sign in flow documentation][sign-in-flow] for instructions on how to use the returned properties.
```C#
var loginResponse = service.Login(LoginProvider.Discord);
if (loginResponse.Success)
{
    var redirectURL = loginResponse.RedirectToURL;
    var pollToken = loginResponse.PollToken;
}
```

## Login Poll
> [!NOTE]
> Periodically call this method with the poll token provided from the login request.  When the player completes the sign in process, a session key will be returned.
```C#
var loginPollResponse = service.LoginPoll(pollToken);
if (loginPollResponse.Session != null)
{
    var sessionKey = loginPollResponse.Session.Key;
}
```

## Set Username & Password
```C#
var setUsernamePasswordResponse = service.SetUsernameAndPassword(
    "Username", 
    "P455w0rD"
);
if (setUsernamePasswordResponse.Success)
{
    // Username and password set
}
```

## Change Password
```C#
var changePasswordResponse = service.ChangePassword("P455w0rD2");
if (changePasswordResponse.Success)
{
    // Password was updated
}
```

## Change Username
```C#
var changeUsernameResponse = service.ChangeUsername("NewUsername");
if (changeUsernameResponse.Success)
{
    // Username was updated
}
```

## Disconnect Login Provider
> [!NOTE]
> Prevents the Player from being able to login with this login provider in the future.
```C#
var disconnectResponse = service.DisconnectLoginProvider(LoginProvider.Discord);
if (disconnectResponse.Success)
{
    // Login provider now disconnected
}
```

# Link Login Provider

## Link Login Provider
> [!NOTE]
> Call this with a signed in player to add another login method to their Player account.  This method returns a poll token and a redirect URL.
```C#
var linkLoginProviderResponse = service.LinkLoginProvider(LoginProvider.Github);
if (linkLoginProviderResponse.Success)
{
    var redirectToURL = linkLoginProviderResponse.RedirectToURL;
    var linkPollToken = linkLoginProviderResponse.PollToken;
}
```

## Link Poll
> [!NOTE]
> Periodically call this method with the poll token provided from the link request.  Read the [link poll documentatio][link-poll-docs] for how to handle the response.
```C#
var linkPollResponse = service.LinkPoll(pollToken);
if (linkPollResponse.Linked)
{
    // Link completed!
}
```

# Sessions

## Refresh Session
> [!NOTE]
> Call periodically with a Player to keep their session alive.
```C#
var refreshSessionResponse = service.RefreshSession();
if (refreshSessionResponse.Success)
{
    // Session was refreshed
}
```

## End Session
```C#
var endSessionResponse = service.EndSession();
if (endSessionResponse.Success)
{
    // Session now ended
}
```

[cgs-account]: https://cgs.construct.net
[cgs-docs]: https://www.construct.net/en/game-services/manuals/game-services/authentication/concepts
[sign-in-flow]: https://www.construct.net/en/game-services/manuals/game-services/authentication/sign-in-flow
[link-poll-docs]: https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/link-poll
[internal-service]: #the-authentication-service-object
[internal-players]: #players
[internal-avatars]: #avatars
[internal-link]: #link-login-provider
[internal-sessions]: #sessions