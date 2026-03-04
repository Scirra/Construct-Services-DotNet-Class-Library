# Authentication Requests

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

There are two ways to construct a service object:

### For requests where authentication is not required
Some requests do not require a secret key or a players session key.  For these requests you can simply pass your games ID to the constructor as follows:
```C#
var service = new AuthenticationService(
	"c59fca77-46f0-4069-9af2-8b40008906c0"
);
```

### For requests using your secret key
If you are making requests that require use of your games secret key, pass in the game ID and a new SecretAPIKey object as follows:
```C#
var service = new AuthenticationService(
	"c59fca77-46f0-4069-9af2-8b40008906c0",
	new SecretAPIKey("your-secret-key")
);
```
Services constructed with a secret key will also work for requests that don't require a secret key.

# Player names and Usernames

A player name is one that is shown to other players.  A username is optional, and is used for signing in.

# Create a new player

Creates a new player in your game with a specified player name and all optional parameters set.
```C#
    var result = service.CreatePlayer(
        new CreatePlayerOptions("Player-1337")
        {
            EmailAddress = "player1337@test.com",
            Username = "Player1337",
            Password = "MyPassword123!",
            SessionExpiry = TimeSpan.FromMinutes(60)
        }
    );

    if (result.Success)
    {
        var player = result.Player;
    }
```

# Change a player name

Using a secret key:
```C#
    var result = service.ChangePlayerName(
        new ChangePlayerNameOptions(player.ID, "NewPlayerName")
    );
```

Or using a players session key:
```C#
    var result = service.ChangePlayerName(
        new ChangePlayerNameOptions("player-session-key", "NewPlayerName")
    );
```

# Change a players login username

Using a secret key:
```C#
    var result = service.ChangeUsername(
        new ChangeUsernameOptions(player.ID, "NewPlayerName")
    );
```

Or using a players session key:
```C#
    var result = service.ChangeUsername(
        new ChangeUsernameOptions("player-session-key", "NewPlayerName")
    );
```

# Change a players password

Using a secret key:
```C#
    var result = service.ChangePassword(
        new ChangePasswordOptions(player.ID, "NewPlayerName")
    );
```

Or using a players session key:
```C#
    var result = service.ChangePassword(
        new ChangePasswordOptions("player-session-key", "NewPlayerName")
    );
```