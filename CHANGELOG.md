# Changelog

## 1.0.9.0 - 11th July 2025

<ul>
	<li>Use Authentication Player object as the main player object - removed all other player objects.</li>
</ul>

## 1.0.8.0 - 11th July 2025

<ul>
	<li>Introduction of expanded authentication service</li>
	<li>Some leaderboard requests now take session keys in as authentication parameters</li>
	<li>Various minor bug fixes and improvements.</li>
</ul>

## 1.0.7.0 - 1st July 2025

<ul>
	<li>New authentication service that allows you to get and register players, returning their corresponding player ID's.</li>
	<li>Various minor bug fixes and improvements.</li>
</ul>

#### BREAKING CHANGES:
<ul>
	<li>Leaderboard player identifiers have been renamed to `playerID` parameters which expect a Guid value.</li>
</ul>

## 1.0.6.0 - 29th April 2025
Initial beta release