# Construct-Services-DotNet-Class-Library

The official Construct Services .NET library, supporting .NET Standard 2.0+.

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

For a comprehensive list of examples, check out the [API documentation][api-docs].  The first thing you'll need to do is [create a game][create-game] in your Construct Services account.

# Usage

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
