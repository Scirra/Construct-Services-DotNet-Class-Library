# Achievement Service

For full documentation, please refer to the [full Construct Game Services docs][cgs-docs].  Please note, this library may contain some overload methods for convenience that do not have specific listed end points in the documentation.

> [!NOTE]
> A lot of these examples can be called from both an API key authenticated service, or player authenticated service.  The method call for each service may require additional parameters (for example, most requests authenticated with an API key require a player ID parameter).  In the interests of being concise, we have not given code examples for both types of services.

All methods are available as synchronous calls, and asynchronous calls.  All methods return an object that lets you know if the request succeeded or not.

# Achievement Service Examples

 - [The Achievement Service object][internal-service]  
   Create this object to make requests against this service

 - [Create achievement][internal-create]  

 - [Update achievement][internal-update]  

 - [Delete achievement][internal-delete]  

 - [Get achievement][internal-get]  

 - [List all achievements][internal-list-all]  
 
 - [List all a players achievements][internal-list-all-players] 
 
 - [List players with an achievement][internal-list-all-players-with]  

# The Achievement Service Object

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

There are a few ways to construct a service object depending on your intentions:

### Requests where a secret API key is required

> [!WARNING]
> **Never** use the following code client side.  You are doing something wrong and potentially dangerous if you do this.

Pass in your game ID as a Guid, and your secret API key.  You can create API keys from your [CGS account][cgs-account].

```C#
var service = new AchievementService(
    yourGameID, 
    new SecretAPIKey("your-secret-key")
);
```

### Requests as a logged in player

> [!TIP]
> This is safe to use client side as well as server side.

If you are making requests on behalf of a logged in player, create a new Player service object passing in the players session key as follows:

```C#
var service = new PlayerAchievementService(
    yourGameID,
    new SessionKey("players-session-key")
);
```

### Requests where no authentication is required

Some requests do not require a secret key, or a player to be logged in.  You probably don't need to use this method, as the above two service objects can still call the end points that do not need authentication.

```C#
var service = new AchievementService(
    yourGameID
);
```

# Create Achievement

```C#
var createAchievementResponse = service.CreateAchievement(new Actions.CreateAchievementOptions
{
    Name = "My Achievement",
    Description = "Some description",
    ClientProgressAllowed = true,
    IsSecret = false,
    MaxUnlocks = 1,
    ProgressionRequired = 1000
});
if (createAchievementResponse.Success)
{
    var achievement = createAchievementResponse.Achievement;
}
```

# Update Achievement

```C#
var updateResponse = service.UpdateAchievement(achievementID, new Actions.UpdateAchievementOptions
{
    Description = "Some updated description",
    MaxUnlocks = 100,
    ClientProgressAllowed = true
});
```

# Delete Achievement

```C#
var deleteResponse = service.DeleteAchievement(achievementID);
if (deleteResponse.Success)
{
    // Achievement was deleted
}
```

# Get Achievement

```C#
var getResponse = service.GetAchievement(achievementID);
if (getResponse.Success)
{
    var achievement = getResponse.Achievement;
}
```

# List all Achievements

```C#
var listResponse = service.ListAchievements();
if (listResponse.Success)
{
    var achievements = listResponse.Achievements;
}
```

# List a Players Achievements

```C#
var listResponse = service.ListPlayerAchievements(playerID);
if (listResponse.Success)
{
    var playerAchievements = listResponse.PlayerAchievements;
}
```

# List Players with Achievement

```C#
var listResponse = service.ListAwardedPlayers(
    achievementID, 
    PlayerAwardedAchievementOrdering.MostRecentlyAwarded,
    new PaginationOptions(1, 100));
if (listResponse.Success)
{
   
```

[cgs-account]: https://cgs.construct.net
[cgs-docs]: https://www.construct.net/en/game-services/manuals/game-services/achievements/concepts
[internal-service]: #the-achievement-service-object
[internal-create]: #create-achievement
[internal-update]: #update-achievement
[internal-delete]: #delete-achievement
[internal-get]: #get-achievement
[internal-list-all]: #list-all-achievements
[internal-list-all-players]: #list-a-players-achievements
[internal-list-all-players-with]: #list-players-with-achievement