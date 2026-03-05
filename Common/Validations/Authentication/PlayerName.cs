using System.Collections.Generic;
using System.Linq;

namespace ConstructServices.Common.Validations.Authentication;
internal static partial class Functions
{    
    private static readonly HashSet<char> UnpermittedPlayerNameCharacters = [
        '<', '>', ';', '\'', '"'
    ];

    internal static Responses.ValidationResponseBase IsPlayerNameValid(string playerName)
    {
        const int MinPlayerNameLength = 1;
        const int MaxPlayerNameLength = 50;

        playerName = (playerName ?? string.Empty).Trim();

        var length = playerName.Length;
        if (length is < MinPlayerNameLength or > MaxPlayerNameLength)
        {
            return new Responses.FailedValidation(
                $"Player name should be between {MinPlayerNameLength} and {MaxPlayerNameLength} characters long.");
        }

        if (IsValidEmailForm(playerName))
        {
            return new Responses.FailedValidation("Cannot use an email address as a player name.");
        }        
        
        // Unpermitted characters
        {
            var found = new HashSet<char>();
            foreach (var c in playerName.Where(c => UnpermittedPlayerNameCharacters.Contains(c)))
            {
                found.Add(c);
            }
            if (found.Any())
            {
                return new Responses.FailedValidation(
                    "The characters [" + string.Join(", ", found.Select(c => c.ToString())) + "] are not permitted in player names."
                );
            }
        }
        
        return new Responses.SuccessfullValidation();
    }
}