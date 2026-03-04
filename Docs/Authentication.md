## Authentication Requests

Create a new authentication service object, and pass in the game ID you're making requests against.

```C#
var service = new AuthenticationService("c59fca77-46f0-4069-9af2-8b40008906c0");
```

### Create a Player

Create a player in your game with the authentication service object.  This will return a `Player` object with a unique ID which can be used to make further requests in other services.

```C#
var result = service.CreatePlayer(new CreatePlayerOptions("Tom"));
if (result.Success){
	var player = result.Player;
}
```

### Delete a Player


```C#
var playerID = Guid.Parse("1130517d-6241-4238-8a71-b20dccc514c8");
var result = service.DeletePlayer(new DeletePlayerOptions(playerID));
if (result.Success){
	var player = result.Player;
}
```
