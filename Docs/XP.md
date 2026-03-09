# XP Service

For full documentation, please refer to the [full Construct Game Services docs][cgs-docs].  Please note, this library may contain some overload methods for convenience that do not have specific listed end points in the documentation.

> [!NOTE]
> A lot of these examples can be called from both an API key authenticated service, or player authenticated service.  The method call for each service may require additional parameters (for example, most requests authenticated with an API key require a player ID parameter).  In the interests of being concise, we have not given code examples for both types of services.

All methods are available as synchronous calls, and asynchronous calls.  All methods return an object that lets you know if the request succeeded or not.

# XP Service Examples

 - [The XP Service object][internal-service]  
   Create this object to make requests against this service

 - [XP examples][internal-xp]  
   How to retrieve a players XP, rank and award, deduct or set XP.

 - [XP Bonus examples][internal-bonuses]  
   XP Bonuses are periods of time when any XP awareded to a player is multiplied.

 - [XP Rank examples][internal-ranks]  
   XP ranks allow players to earn ranks when they reach a defined XP threshold

# The XP Service Object

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

There are a few ways to construct a service object depending on your intentions:

### Requests where a secret API key is required

> [!WARNING]
> **Never** use the following code client side.  You are doing something wrong and potentially dangerous if you do this.

Pass in your game ID as a Guid, and your secret API key.  You can create API keys from your [CGS account][cgs-account].

```C#
var service = new XPService(
    yourGameID, 
    new SecretAPIKey("your-secret-key")
);
```

### Requests as a logged in player

> [!TIP]
> This is safe to use client side as well as server side.

If you are making requests on behalf of a logged in player, create a new Player service object passing in the players session key as follows:

```C#
var service = new PlayerXPService(
    yourGameID,
    new SessionKey("players-session-key")
);
```

### Requests where no authentication is required

Some requests do not require a secret key, or a player to be logged in.  You probably don't need to use this method, as the above two service objects can still call the end points that do not need authentication.

```C#
var service = new XPService(
    yourGameID
);
```

# XP

## Get Players XP, Rank + Next Rank
```C#
var getXPResponse = service.GetXP(playerID);
if (getXPResponse.Success)
{
    var currentXP = getXPResponse.XP;
    var currentRank = getXPResponse.Rank;
    var nextRank = getXPResponse.NextRank;
}
```

## Add XP to a player
> [!TIP]
> The passed XP value is automatically multipled if any bonuses are active.
```C#
var addXPResponse = service.AddXP(
    playerID,
    new ModifyXPOptions(100)
);
if (addXPResponse.Success)
{
    // XP was added
}
```

## Remove XP from a player
> [!TIP]
> The passed XP value is unaffacted by any active bonuses.
```C#
var removeXPResponse = service.RemoveXP(
    playerID,
    new ModifyXPOptions(100)
);
if (removeXPResponse.Success)
{
    // XP was removed
}
```

## Set a Players XP
> [!TIP]
> This sets the players XP to the specified amount.  The passed XP value is unaffacted by any active bonuses.
```C#
var setXPResponse = service.SetXP(
    playerID,
    new ModifyXPOptions(500)
);
if (setXPResponse.Success)
{
    // XP was set
}
```

# Bonuses

## Create a New XP Bonus

```C#
var createBonusResponse = service.CreateBonus(new CreateXPBonusOptions
{
    Title = "2.5x XP Weekend",
    Description = "Earn two and a half times XP this weekend!",
    Modifier = (decimal)2.5,
    Start = DateTime.UtcNow.AddDays(7),
    End = DateTime.UtcNow.AddDays(9)
});
if (createBonusResponse.Success)
{
    var newBonus = createBonusResponse.Bonus;
}
```

## Update an XP Bonus

```C#
var updateBonusResponse = service.UpdateBonus(
    bonusID,
    new Bonuses.UpdateXPBonusOptions
    {
        Title = "Triple XP Weekend",
        Description = "Earn 3 times XP this weekend!",
        Modifier = (decimal)3,
        Start = DateTime.UtcNow.AddDays(7),
        End = DateTime.UtcNow.AddDays(9)
    }
);
if (updateBonusResponse.Success)
{
    var updatedBonus = updateBonusResponse.Bonus;
}
```

## Get an XP Bonus

```C#
var getBonusResponse = service.GetBonus(bonusID);
if (getBonusResponse.Success)
{
    var bonus = getBonusResponse.Bonus;
}
```

## List XP Bonuses

```C#
// List all XP bonuses in the next 7 days
var listBonusesResponse = service.ListBonuses(new Bonuses.ListBonusesOptions
{
    Start = DateTime.UtcNow,
    End = DateTime.UtcNow.AddDays(7)
});
if (listBonusesResponse.Success)
{
    var bonuses = listBonusesResponse.Bonuses;
}
```

## List Active XP Bonuses

```C#
var listActiveBonusesResponse = service.ListActiveBonuses();
if (listActiveBonusesResponse.Success)
{
    var bonuses = listActiveBonusesResponse.Bonuses;
}
```

## Delete an XP Bonus

```C#
var deleteBonusResponse = service.DeleteBonus(bonusID);
if (deleteBonusResponse.Success)
{
    // Bonus was deleted
}
```

# Ranks

## Create an XP Rank

```C#
var createRankResponse = service.CreateRank(new CreateXPRankOptions
{
    Title = "Gold Pig",
    Description = "For seasoned verterans of the game",
    AtXP = 1000000
});
if (createRankResponse.Success)
{
    var newRank = createRankResponse.Rank;
}
```

## Update an XP Rank

```C#
var updateRankResponse = service.UpdateRank(
    rankID,
    new Rankings.UpdateXPRankOptions
    {
        Title = "Golden Pig",
        Description = "For overly seasoned verterans of the game",
        AtXP = 5000000
    }
);
if (updateRankResponse.Success)
{
    var updatedRank = updateRankResponse.Rank;
}
```

## Delete an XP Rank

```C#
var deleteRankResponse = service.DeleteRank(rankID);
if (deleteRankResponse.Success)
{
    // Rank was deleted
}
```

## List all XP Ranks

```C#
var listRanksResponse = service.ListAllRanks();
if (listRanksResponse.Success)
{
    var ranks = listRanksResponse.Ranks;
}
```

[cgs-account]: https://cgs.construct.net
[cgs-docs]: https://www.construct.net/en/game-services/manuals/game-services/xp/concepts
[internal-service]: #the-xp-service-object
[internal-xp]: #xp
[internal-bonuses]: #bonuses
[internal-ranks]: #ranks