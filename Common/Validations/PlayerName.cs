using System.Collections.Generic;
using System.Linq;

namespace ConstructServices.Common;

internal static partial class Validations
{    
    private static readonly HashSet<char> UnpermittedPlayerNameCharacters = [
        '<', '>', ';', '\'', '"'
    ];

    internal static ValidationResponseBase IsPlayerNameValid(string playerName)
    {
        const int MinPlayerNameLength = 1;
        const int MaxPlayerNameLength = 50;
        
        var length = playerName.Trim().Length;
        if (length is < MinPlayerNameLength or > MaxPlayerNameLength)
        {
            return new FailedValidation(
                $"Player name should be between {MinPlayerNameLength} and {MaxPlayerNameLength} characters long.");
        }

        if (IsValidEmailForm(playerName))
        {
            return new FailedValidation("Cannot use an email address as a player name.");
        }        
        
        // Unpermitted characters
        {
            var found = new HashSet<char>();
            foreach (var c in playerName)
            {
                if (UnpermittedPlayerNameCharacters.Contains(c))
                {
                    found.Add(c);
                }
            }
            if (found.Any())
            {
                return new FailedValidation(
                    "The characters [" + string.Join(", ", found.Select(c => c.ToString())) + "] are not permitted in player names."
                );
            }
        }
        
        return new SuccessfullValidation();
    }
}