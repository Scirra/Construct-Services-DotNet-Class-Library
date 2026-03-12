# Leaderboard Service

For full documentation, please refer to the [full Construct Game Services docs][cgs-docs].  Please note, this library may contain some overload methods for convenience that do not have specific listed end points in the documentation.

> [!NOTE]
> A lot of these examples can be called from both an API key authenticated service, or player authenticated service.  The method call for each service may require additional parameters (for example, most requests authenticated with an API key require a player ID parameter).  In the interests of being concise, we have not given code examples for both types of services.

All methods are available as synchronous calls, and asynchronous calls.  All methods return an object that lets you know if the request succeeded or not.

# Leaderboard Service Examples

 - [The Leaderboard Service object][internal-service]  
   Create this object to make requests against this service

 - [Leaderboard examples][internal-leaderboards]  
   You can have multiple leaderboards in your game

 - [Score examples][internal-scores]  
   Create, adjust and list scores

 - [Shadow Ban examples][internal-shadow-bans]  
   Shadow ban players or IPs to stop them polluting the leaderboard

 - [Team examples][internal-teams]  
   Create teams and manage the players on each team

# The Leaderboard Service Object

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

There are a few ways to construct a service object depending on your intentions:

### Requests where a secret API key is required

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

### Requests as a logged in player

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

### Requests where no authentication is required

Some requests do not require a secret key, or a player to be logged in.  You probably don't need to use this method, as the above two service objects can still call the end points that do not need authentication.

```C#
var service = new LeaderboardService(
    yourGameID
    yourLeaderboardID,
);
```

# Leaderboards

## Creating a Leaderboard

It is not possible to create a leaderboard via the API, you must login to your [CGS account][cgs-account] and create leaderboards from there.

# Scores

## Create Score
```C#
var createScoreResponse = service.CreateScore(new Scores.CreateScoreOptions
{
    Score = 1000,
    OptValue1 = 5
});
if (createScoreResponse.Success)
{
    var score = createScoreResponse.Score;
    var isPersonalBest = createScoreResponse.PersonalBest;
}
```

## Get Score
```C#
var getScoreResponse = service.GetScore(scoreID);
if (getScoreResponse.Success)
{
    var score = getScoreResponse.Score;
}
```

## Adjust Score
```C#
// Adjust by score ID
var adjustScoreByIDResponse = service.AdjustScore(scoreID, new Scores.AdjustScoreOptions
{
    Adjustment = 500
});
if (adjustScoreByIDResponse.Success)
{
    var score = adjustScoreByIDResponse.Score;
    var isPersonalBest = adjustScoreByIDResponse.PersonalBest;
}

// Adjust current best score
var adjustScoreByBestScoreResponse = service.AdjustBestScore(new Scores.AdjustScoreOptions
{
    Adjustment = -100
});
if (adjustScoreByBestScoreResponse.Success)
{
    var score = adjustScoreByBestScoreResponse.Score;
    var isPersonalBest = adjustScoreByBestScoreResponse.PersonalBest;
}
```

## List Newest Scores
```C#
// List all newest scores
var listAllNewestScoresResponse = service.ListNewestScores(
    new ListNewestScoresOptions(),
    new PaginationOptions(1, 20)
);
if (listAllNewestScoresResponse.Success)
{
    var scores = listAllNewestScoresResponse.Scores;
}

// List all newest score from the UK
var listNewestUKScoresResponse = service.ListNewestScores(
    new ListNewestScoresOptions
    {
        Country = Country.UnitedKingdom
    },
    new PaginationOptions(1, 20)
);
if (listNewestUKScoresResponse.Success)
{
    var scores = listNewestUKScoresResponse.Scores;
}
```

## List Players Scores
> [!TIP]
> Always returns best scores first
```C#
var listPlayerScoresResponse = service.ListPlayerScores(
    playerID, 
    new PaginationOptions(1, 20)
);
if (listPlayerScoresResponse.Success)
{
    var scores = listPlayerScoresResponse.Scores;
}
```

## List Score History
```C#
var listScoreHistoryResponse = service.ListScoreHistory(scoreID);
if (listScoreHistoryResponse.Success)
{
    var scoreHistory = listScoreHistoryResponse.ScoreHistory;
}
```

## List Score Neighbours
```C#
var listScoreNeighboursResponse = service.ListScoreNeighbours(
    scoreID, 
    new ListScoreNeighbourOptions
    {
        Range = 5
    }
);
if (listScoreNeighboursResponse.Success)
{
    var neighbours = listScoreNeighboursResponse.Scores;
}
```

## List All Scores
```C#
// Get this months best scores
var listThisMonthsBestScoresResponse = service.ListScores(
    new ListScoreOptions
    {
        Range = ScoreRange.Monthly
    }
);
if (listThisMonthsBestScoresResponse.Success)
{
    var scores = listThisMonthsBestScoresResponse.Scores;
}

// Get last months best scores
var listLastMonthsBestScoresResponse = service.ListScores(
    new ListScoreOptions
    {
        Range = ScoreRange.Monthly,
        RangeOffset = 1
    }
);
if (listLastMonthsBestScoresResponse.Success)
{
    var scores = listLastMonthsBestScoresResponse.Scores;
}

// Get all time best scores in the UK
var listBestUKScoresResponse = service.ListScores(
    new ListScoreOptions
    {
        Range = ScoreRange.All,
        Country = Country.UnitedKingdom
    }
);
if (listBestUKScoresResponse.Success)
{
    var scores = listBestUKScoresResponse.Scores;
}
```

## Delete Score
```C#
var deleteScoreResponse = service.DeleteScore(scoreID);
if (deleteScoreResponse.Success)
{
    // Score was deleted
}
```

# Shadow Bans

## Create Shadow Ban
```C#
// On IP address
var createIPShadowBanResponse = service.CreateShadowBan(new CreateIPShadowBanOptions("1.2.3.4"));
if (createIPShadowBanResponse.Success)
{
    // Ban was created
}

// On Player ID
var createPlayerShadowBan = service.CreateShadowBan(new CreatePlayerShadowBanOptions(playerID));
if (createPlayerShadowBan.Success)
{
    // Ban was created
}
```

## List Shadow Bans
```C#
// List IP bans
var listIPShadowBanResponse = service.ListIPShadowBans(
    new PaginationOptions(1, 20)
);
if (listIPShadowBanResponse.Success)
{
    var bans = listIPShadowBanResponse.Bans;
}

// List Player bans
var listPlayerShadowBans = service.ListPlayerShadowBans(
    new PaginationOptions(1, 20)
);
if (listPlayerShadowBans.Success)
{
    var bans = listPlayerShadowBans.Bans;
}
```

## Delete Shadow Bans
```C#
// Delete IP ban
var deleteIPBanResponse = service.DeleteShadowBan(
    new DeleteIPShadowBanOptions("1.2.3.4")
);
if (deleteIPBanResponse.Success)
{
    // Ban was lifted
}

// Delete Player ban
var deletePlayerBanResponse = service.DeleteShadowBan(
    new DeletePlayerShadowBanOptions(playerID)
);
if (deletePlayerBanResponse.Success)
{
    // Ban was lifted
}
```

# Teams

## Create a Leaderboard Team
```C#
var createTeamResponse = service.CreateTeam("Team Name");
if (createTeamResponse.Success)
{
    var newTeam = createTeamResponse.Team;
}
```

## Update a Leaderboard Team
```C#
var updateTeamResponse = service.UpdateTeam(teamID, new Teams.UpdateTeamOptions
{
    Name = "New Team Name"
});
if (updateTeamResponse.Success)
{
    // Team was updated
}
```

## Get a Leaderboard Team
```C#
var getTeamResponse = service.GetTeam(teamID);
if (getTeamResponse.Success)
{
    var team = getTeamResponse.Team;
}
```

## List Leaderboard Teams
> [!TIP]
> Returns teams in ranked order, best first.
```C#
var listTeamsResponse = service.ListTeams(
    new Teams.ListTeamOptions
    {
        Ordering = GetTeamsOrdering.MostPlayers,
    },
    new PaginationOptions(1, 20)
);
if (listTeamsResponse.Success)
{
    var teams = listTeamsResponse.Teams;
}
```

## Assign Player to a Leaderboard Team
```C#
var assignPlayerResponse = service.AssignPlayerToTeam(teamID, playerID);
if (assignPlayerResponse.Success)
{
    // Player was added to team
}
```

## Delete (Remove) Player from a Leaderboard Team
```C#
var deletePlayerResponse = service.DeletePlayerFromTeam(teamID, playerID);
if (deletePlayerResponse.Success)
{
    // Player was removed from the team
}
```

## List Players in a Leaderboard Team
```C#
var listTeamPlayersResponse = service.ListTeamPlayers(
    teamID,
    new Teams.ListTeamPlayersOptions
    {
        Ordering = TeamPlayersOrdering.Score
    },
    new PaginationOptions(1, 20)
);
if (listTeamPlayersResponse.Success)
{
    var players = listTeamPlayersResponse.Players;
}
```

## Delete a Leaderboard Team
```C#
var deleteTeamResponse = service.DeleteTeam(teamID);
if (deleteTeamResponse.Success)
{
    // Team was deleted
}
```


[cgs-account]: https://cgs.construct.net
[cgs-docs]: https://www.construct.net/en/game-services/manuals/game-services/leaderboards/getting-started
[internal-service]: #the-leaderboard-service-object
[internal-leaderboards]: #leaderboards
[internal-scores]: #scores
[internal-shadow-bans]: #shadow-bans
[internal-teams]: #teams