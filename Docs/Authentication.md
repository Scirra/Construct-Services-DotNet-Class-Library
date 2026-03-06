# Authentication Requests

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

There are a few ways to construct a service object depending on your intentions:

## Requests where a secret API key is required

> [!WARNING]
> **Never** use the following code client side.  You are doing something wrong and potentially dangerous if you do this.

Pass in your game ID as a Guid, and your secret API key.  You can create API keys from your [CGS account][cgs-account].

```C#
var service = new AuthenticationService(
    yourGameID, 
    new SecretAPIKey("your-secret-key")
);
```

## Requests as a logged in player

> [!TIP]
> This is safe to use client side as well as server side.

If you are making requests on behalf of a logged in player, create a new Player service object passing in the players session key as follows:

```C#
var service = new PlayerAuthenticationService(
    yourGameID,
    new SessionKey("players-session-key")
);
```

## Requests where no authentication is required

Some requests do not require a secret key, or a player to be logged in.  You probably don't need to use this method, as the above two service objects can still call the end points that do not need authentication.

```C#
var service = new AuthenticationService(
    yourGameID
);
```

# A note on Player Names and Usernames

A player name is one that is shown to other players.  A username is optional, and is used for signing in.

# Example Code

For full documentation, please refer to the [full Construct Game Services docs][cgs-docs].  Please note, this library may contain some overload methods for convenience that do not have specific listed end points in the documentation.

> [!NOTE]
> A lot of these examples can be called from both an API key authenticated service, or player authenticated service.  The method call for each service may require additional parameters (for example, most requests authenticated with an API key require a player ID parameter).  In the interests of being concise, we have not given code examples for both types of services.

All methods are available as synchronous calls, and asynchronous calls.  All methods return an object that lets you know if the request succeeded or not.  If you're requesting data, the requested data will also be returned in this object.  A typically pattern when using this API would be:
```C#
var result = service.GetSomething();
if (!result.Success)
{
    var errorMessage = result.ErrorMessage;    
    // Retry or handle the error
}
else
{
    var thing = result.Thing;
}
```

## Register New Player

```C#
service.RegisterPlayer(new RegisterPlayerOptions
{
    PlayerName = "Battle Pig",
    Username = "BattlePig86",
    Password = "MySecurePassword123!",
    EmailAddress = "test@test.com"
});
```

## Delete Player
> [!WARNING]
> This is a permanent and irreversible action.  It is important for data privacy to always allow logged in players the ability to delete their account.
```C#
service.DeletePlayer();
```

## Set Players avatar

```C#
// Set from image URL
service.SetAvatar(new PictureData(new Uri("https://www.example.com/picture.png")));

// Set from base-64 encoded image data
service.SetAvatar(new PictureData(base64String));

// Set from binary picture data
byte[] data = getData();
service.SetAvatar(new PictureData(data));
```

## Delete Players Avatar
```C#
service.DeleteAvatar();
```

## Change Player Name
```C#
service.ChangePlayerName("Gamer Pig");
```

## Set Username & Password
```C#
service.SetUsernameAndPassword("Username", "P455w0rD");
```

## Change Password
```C#
service.ChangePassword("P455w0rD2");
```

## Change Username
```C#
service.ChangeUsername("NewUsername");
```

## Set Email Address
> [!TIP]
> This will send the player an email asking them to verify their email address
```C#
service.SetEmailAddress("test@test.com");
```

## Request Forgotten Password
> [!TIP]
> This will only send an email to the player if they have previously verified their email address
```C#
service.SetEmailAddress("test@test.com");
```

## Get a Player
```C#
// By player ID
service.GetPlayer(playerID);

// By player name
service.GetPlayer("Gamer Pig");

// Get expanded player (contains more properties in results)
service.GetExpandedPlayer(playerID);
```

## List Players
```C#
service.ListPlayers(
    new ListPlayersOptions {
        Ordering = PlayerOrdering.MostRecentlyActive
    }, 
    new PaginationOptions(1, 20)
);

// Get specific player IDs
service.ListPlayers(
    new ListPlayersOptions {
        PlayerIDs = new[]
        {
            PlayerID1,
            PlayerID2
        },
    }, 
    new PaginationOptions(1, 20)
);
```

## Login Player
> [!NOTE]
> This returns a poll token and a redirect URL.  See the [sign in flow documentation][sign-in-flow] for instructions on how to use the returned properties.
```C#
service.Login(LoginProvider.Discord);
```

## Login Poll
> [!NOTE]
> Periodically call this method with the poll token provided from the login request.  When the player completes the sign in process, a session key will be returned.
```C#
var response = service.LoginPoll(pollToken);
if (response.Session != null)
{
    var sessionKey = r.Session.Key;
}
```

## Refresh Session
> [!NOTE]
> Call periodically with a Player to keep their session alive.
```C#
service.RefreshSession();
```

## End Session
```C#
service.EndSession();
```

## Link Login Provider
> [!NOTE]
> Call this with a signed in player to add another login method to their Player account.  This method returns a poll token and a redirect URL.
```C#
service.LinkLoginProvider(LoginProvider.Github);
```

## Link Poll
> [!NOTE]
> Periodically call this method with the poll token provided from the link request.  Read the [link poll documentatio][link-poll-docs] for how to handle the response.
```C#
var response = service.LinkPoll(pollToken);
```

## Disconnect Login Provider
> [!NOTE]
> Prevents the Player from being able to login with this login provider in the future.
```C#
service.DisconnectLoginProvider(LoginProvider.Discord);
```

[cgs-account]: https://cgs.construct.net
[cgs-docs]: https://www.construct.net/en/game-services/manuals/game-services/authentication/concepts
[sign-in-flow]: https://www.construct.net/en/game-services/manuals/game-services/authentication/sign-in-flow
[link-poll-docs]: https://www.construct.net/en/game-services/manuals/game-services/authentication/api-end-points/login-providers/link-poll