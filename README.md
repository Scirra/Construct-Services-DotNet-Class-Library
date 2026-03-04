# Construct-Services-DotNet-Class-Library

The official Construct Services .NET library, supporting .NET Standard 2.0+.

# Installation

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

# Documentation

You can read the full [API documentation here][api-docs].  Below are links to documentation and examples for using this package.

# Usage

### Before you start
You need to create a [Construct Game Services][cgs-account] account.  From here, you can create a new Game, and get your Game ID, which is required to make requests to these services.

> Even though the service is called the Construct Game Services, it can be used outside of the gaming world for other purposes!

 - ### Authentication Service
   For signing in players, forgotten password emails, setting player avatars and much more.

   [Documentation and Examples][docs-auth]

 - ### Broadcast Service
   For publishing messages to channels that can be read by your player base.  Support translations into various languages.

   [Documentation and Examples][docs-broadcast]

 - ### CloudSave Service
   For saving data blobs.  Supports private player saves, along with public saves into buckets.  Images can be stored alongside the cloud saves, and cloud saves can be rated by the player base.

   [Documentation and Examples][docs-cloudsave]

 - ### Leaderboard Service
   For maintaining a list of scores for players.  Supports teams, shadow banning players or IP's.  View a players score history over time.  You can filter scores by countries as well as many other views.

   [Documentation and Examples][docs-leaderboards]

 - ### XP Service
   For maintaining an XP level for individual players.  Supports bonus date periods, for example you can create a "Double XP Weekend" where any XP earned during that weekend is doubled automatically.

   [Documentation and Examples][docs-xp]

# Support

For any requests, bug or comments, please [open an issue][issues] or [submit a
pull request][pulls].

[cgs-account]: https://cgs.construct.net
[docs-auth]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/blob/master/Docs/Authentication.md
[docs-broadcast]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/blob/master/Docs/Broadcasts.md
[docs-cloudsave]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/blob/master/Docs/CloudSaves.md
[docs-leaderboards]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/blob/master/Docs/Leaderboards.md
[docs-xp]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/blob/master/Docs/XP.md
[create-game]: https://www.construct.net/en/game-services/account
[api-docs]: https://www.construct.net/en/game-services/manuals/game-services
[dotnet-core-cli-tools]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
[issues]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/issues/new
[pulls]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/pulls
