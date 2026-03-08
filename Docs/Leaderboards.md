# Leaderboard Requests

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

There are a few ways to construct a service object depending on your intentions:

## Requests where a secret API key is required

> [!WARNING]
> **Never** use the following code client side.  You are doing something wrong and potentially dangerous if you do this.

Pass in your game ID as a Guid, and your secret API key.  You can create API keys from your [CGS account][cgs-account].

```C#
var service = new LeaderboardService(
    yourGameID, 
    yourLeaderboardID,
    new SecretAPIKey("your-secret-key")
);
```

## Requests as a logged in player

> [!TIP]
> This is safe to use client side as well as server side.

If you are making requests on behalf of a logged in player, create a new Player service object passing in the players session key as follows:

```C#
var service = new PlayerLeaderboardService(
    yourGameID,
    yourLeaderboardID,
    new SessionKey("players-session-key")
);
```

## Requests where no authentication is required

Some requests do not require a secret key, or a player to be logged in.  You probably don't need to use this method, as the above two service objects can still call the end points that do not need authentication.

```C#
var service = new LeaderboardService(
    yourGameID
    yourLeaderboardID,
);
```

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

## Creating a Leaderboard

It is not possible to create a leaderboard via the API, you must login to your [CGS account][cgs-account] and create leaderboards from there.

## Create Score
```C#
service.CreateScore(new Scores.CreateScoreOptions
{
    Score = 1000,
    OptValue1 = 5
});
```

## Adjust Score
```C#
service.CreateScore(new Scores.CreateScoreOptions
{
    Score = 1000,
    OptValue1 = 5
});
```

## Create Shadow Ban
```C#
// On IP address
service.CreateShadowBan(new ShadowBans.CreateIPShadowBanOptions("1.2.3.4"));

// On Player ID
service.CreateShadowBan(new ShadowBans.CreatePlayerShadowBanOptions(playerID));
```

## List Shadow Bans
```C#
// List IP bans
service.ListIPShadowBans(new PaginationOptions(1, 20));

// List Player bans
service.ListPlayerShadowBans(new PaginationOptions(1, 20));
```

## Delete Shadow Bans
```C#
// Delete IP ban
service.DeleteShadowBan(new ShadowBans.DeleteIPShadowBanOptions("1.2.3.4"));

// Delete Player ban
service.DeleteShadowBan(new ShadowBans.DeletePlayerShadowBanOptions(playerID));
```

## Create a Leaderboard Team
```C#
service.CreateTeam("Team Name");
```

## Update a Leaderboard Team
```C#
service.UpdateTeam(teamID, new Teams.UpdateTeamOptions
{
    Name = "New Team Name"
});
```

## Get a Leaderboard Team
```C#
service.GetTeam(teamID);
```

## List Leaderboard Teams
```C#
service.ListTeams(
    new Teams.ListTeamOptions
    {
        Ordering = GetTeamsOrdering.MostPlayers,
    },
    new PaginationOptions(1, 20)
);
```


## Assign Player to a Leaderboard Team
```C#
service.AssignPlayerToTeam(teamID, playerID);
```

## Delete (Remove) Player from a Leaderboard Team
```C#
service.DeletePlayerFromTeam(teamID, playerID);
```

## List Players in a Leaderboard Team
```C#
service.ListTeamPlayers(
    teamID,
    new Teams.ListTeamPlayersOptions
    {
        Ordering = TeamPlayersOrdering.Score
    },
    new PaginationOptions(1, 20)
);
```

## Delete a Leaderboard Team
```C#
service.DeleteTeam(teamID);
```


[cgs-account]: https://cgs.construct.net
[cgs-docs]: https://www.construct.net/en/game-services/manuals/game-services/leaderboards/getting-started