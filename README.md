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

> [!TIP]
> Even though the service is called the Construct Game Services, it can be used outside of the gaming world for other purpos

### Translated content
When text content is returned from a service, it is returned in the original language it was written in.  The object is returned with properties such as:
```C#
obj.title = "My Test Title";
obj.text = "Example test string";
obj.originalLanguage = { 
	iso = "EN", 
	englishName = "English"
};
obj.responseLanguage =  { 
	iso = "EN", 
	englishName = "English"
};
```

By setting a requested language before making the request, the text will be returned in the requested language if your plan supports the translation.  For example, setting:

```C#
// Returns all translatable text content in response objects to German
service.SetRequestedLanguage(TargetLanguage.German);
```

Could return the above example object as:

```C#
obj.title = "Mein Testtitel";
obj.text = "Beispieltestzeichenkette";
obj.originalLanguage = { 
	iso = "EN", 
	englishName = "English"
};
obj.responseLanguage =  { 
	iso = "DE", 
	englishName = "German"
};
```

If the translation cannot be served (typically because your plan doesn't support it) the request will fail gracefully, and simply return the original untranslated string:

```C#
obj.title = "My Test Title";
obj.text = "Example test string";
obj.originalLanguage = { 
	iso = "EN", 
	englishName = "English"
};
obj.responseLanguage =  { 
	iso = "EN", 
	englishName = "English"
};
```

### Culture formatting
When an object is returned from a service, a lot of the times it will contain properties such as:
```C#
obj.value = 1000;
obj.formattedValue = "1,000";
obj.date = DateTime;
obj.formattedDate = "06/03/2026 15:18:42";
```

By setting the service culture before making the request, the formatted versions of the properties will be returned in the specified culture.  For example, setting:

```C#
// Returns all dates, numbers formatted to German culture
service.SetCulture(new CultureInfo("de-DE"));
```

Would return the above example object as:

```C#
obj.value = 1000;
obj.formattedValue = "1.000";
obj.date = DateTime;
obj.formattedDate = "06.03.2026 15:18:42";
```

### Pagination

Some requests return results in paginated form.  For these requests, you'll need to pass in a new PaginationOptions object:
```C#
var requestedPage = 1;
var recordsPerPage = 20;

var result = service.ListPlayers(new ListPlayersOptions {
        Ordering = PlayerOrdering.Newest
    },
    new PaginationOptions(requestedPage, recordsPerPage)
);
```

This then returns:

```C#
var hasMore = result.Pagination.HasMore;
var totalPages = result.Pagination.TotalPages;
var totalRecords = result.Pagination.TotalRecords;
```

Using these properties you can make further requests to fetch results on other pages.

# The Services

 - ## Authentication Service
   Allow players to sign in to your game/application with username & password, Apple, BattleNet, Discord, Email magic links, Facebook, Github, Google, ItchIO, Microsoft, Patreon, Reddit, Steam, X and Yandex.

   Once a player is signed in, they can also:

	- Change their player name (displayed to other users)
	- Set an avatar
	- Link their account to other login providers allowing for multiple sign in optionsh
	- Delete their account
    - Set an email address for their account
    - Request a forgotten password

   See the [Examples][docs-auth] or read the [full API documentation][docs-auth-api]

 - ## Broadcast Service
   Allows you to create Broadcast Channels, and from these channels create Broadcast Messages that are accessible to all players in your game/application. For example, you might create a channel "New Features" and publish messages into this channel describing new features you have introduced when you update your game.

   Messages can be translated into multiple languages to cater to international audiences.  If enabled, players can also rate Broadcast Messages.
   
   See the [Examples][docs-broadcast] or read the [full API documentation][docs-broadcast-api]

 - ## CloudSave Service
   Allow players to save blobs of data into the cloud for retrieval at a later date. The most useful and simple applciation for this is allowing players to save their game progress. You can also save a picture alongside a cloud save to represent the data more visually - for example a screenshot of the game where the save game was created.
   
	You can also create public Game Buckets that players can save data into - for example if your game allows you to create custom levels, you could create a public bucket for these levels and allow players to share their creations with other players. These data blobs can also be rated with multiple dimensions, and returned to players sorted by the ratings.

   See the [Examples][docs-cloudsave] or read the [full API documentation][docs-cloudsave-api]

 - ## Leaderboard Service
   Unlike other services, CGS leaderboards automatically track scores by country allowing you to see how players from different countries are performing for specific leaderboards.
   
	CGS leaderboards boast a large array of advanced features built in:

	- Format scores for all types of values, time, money, points etc.
	- Group players into Tiers/Divisions
	- Assign players to teams and customise how teams are ranked
	- Show daily, weekly, monthly or annual leaderboards
	- Track players historic performance showing how their rank is improving over time
	- Shadow ban players to prevent cheaters from spoiling the experience of legitimate players
	- Set up thresholds that automatically reject scores if they fall outside of expected ranges
	- Store additional values with scores to provide extra context when viewing leaderboards (for example, how many gold coins were collected)
	
   See the [Examples][docs-leaderboards] or read the [full API documentation][docs-leaderboards-api]

 - ## XP Service
	Tracks player XP. The XP service allows you to:

	 - Add, remove or set a players XP
	 - Define ranks for XP, unlocked by players when they reach certain XP levels.
	 - Define periods where XP earnt is multiplied by a custom amount (EG a 3x XP bonus weekend)
	
   See the [Examples][docs-xp] or read the [full API documentation][docs-xp-api]

# Support

For any requests, bug or comments, please [open an issue][issues] or [submit a
pull request][pulls].

[cgs-account]: https://cgs.construct.net
[docs-auth]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/blob/master/Docs/Authentication.md
[docs-auth-api]: https://www.construct.net/en/game-services/manuals/game-services/authentication/concepts
[docs-broadcast]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/blob/master/Docs/Broadcasts.md
[docs-broadcast-api]: https://www.construct.net/en/game-services/manuals/game-services/broadcasts/concepts
[docs-cloudsave]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/blob/master/Docs/CloudSaves.md
[docs-cloudsave-api]: https://www.construct.net/en/game-services/manuals/game-services/cloud-save/concepts
[docs-leaderboards]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/blob/master/Docs/Leaderboards.md
[docs-leaderboards-api]: https://www.construct.net/en/game-services/manuals/game-services/leaderboards/getting-started
[docs-xp]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/blob/master/Docs/XP.md
[docs-xp-api]: https://www.construct.net/en/game-services/manuals/game-services/xp/concepts
[create-game]: https://www.construct.net/en/game-services/account
[api-docs]: https://www.construct.net/en/game-services/manuals/game-services
[dotnet-core-cli-tools]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
[issues]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/issues/new
[pulls]: https://github.com/Scirra/Construct-Services-DotNet-Class-Library/pulls
