# Construct-Services-DotNet-Class-Library

The official Construct Services .NET library, supporting .NET Framework 4.8.1+.

## Installation

Using the [.NET Core command-line interface (CLI) tools][dotnet-core-cli-tools]:

```sh
dotnet add package ConstructServices
```

Using the [NuGet Command Line Interface (CLI)][nuget-cli]:

```sh
nuget install ConstructServices
```

Using the [Package Manager Console][package-manager-console]:

```powershell
Install-Package ConstructServices
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on _Manage NuGet Packages..._
4. Click on the _Browse_ tab and search for "Stripe.net".
5. Click on the Stripe.net package, select the appropriate version in the
   right-tab and click _Install_.

## Documentation

For a comprehensive list of examples, check out the [API documentation][api-docs].  The first thing you'll need to do is [create a game][create-game] in your Construct Services account..

# Usage

## Authentication Requests

Create a new authentication service object, and pass in the game ID you're making requests against.

```C#
var service = new AuthenticationService("c59fca77-46f0-4069-9af2-8b40008906c0");
```

### Register a Player

Register a player in your game with the authentication service object.  This will return a `Player` object with a unique ID which can be used to make further requests in other services.

```C#
var result = service.RegisterPlayer("Tom");
if (result.Success){
	var playerID = result.Player.ID;
}
```

## Leaderboard Requests

Create a leaderboard service object, and pass in the leaderboard ID you're making requests against.

```C#
var service = new LeaderboardService("a1cd2297-a9d7-407f-b33a-881580df8228");
```

The leaderboard service object also has constructors for passing in an API key and a culture code for rendering various responses to a certain culture.

The leaderboard service object is a cheap object and can be created once and reused, or on demand.

### Querying a Leaderboard

Once you have a leaderboard service object, all methods available in the leaderboard API will be exposed.  Most requests only have one or two parameters such as BanIPAddress():

```C#
var result = service.BanIPAddress("1.2.3.4");
```

However other requests such as GetScores() may have more parameters: 

```C#
var result = service.GetScores(
	new PaginationOptions(page),
	"US",
	ScoreRange.All,
	0,
	7,
	new RequestPerspective(Code.Helpers.Common.Functions.GetUserIPAddress())
);
```
Queries always return `Success` indicating if the response was succesfull.  If not successful, `ErrorMessage` and `ShouldRetry` properties are returned.  If `ShouldRetry` is true, likely the request is rate limited and you can retry the request in a few seconds.

## Support

For any requests, bug or comments, please [open an issue][issues] or [submit a
pull request][pulls].

[create-game]: https://www.construct.net/en/game-services/account
[api-docs]: https://www.construct.net/en/game-services/manuals/game-services
[dotnet-core-cli-tools]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
[issues]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/issues/new
[pulls]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/pulls
