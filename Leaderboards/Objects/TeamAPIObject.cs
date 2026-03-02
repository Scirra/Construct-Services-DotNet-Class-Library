using ConstructServices.Leaderboards.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Leaderboards.Objects;

public sealed class AssignPlayerOptions(Guid leaderboardID, Guid teamID, Guid playerID)
{
    [UsedImplicitly]
    public Guid LeaderboardID { get; private set; } = leaderboardID;

    [UsedImplicitly]
    public Guid TeamID { get; private set; } = teamID;

    [UsedImplicitly]
    public Guid PlayerID { get; private set; } = playerID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() },
            { "teamID", TeamID.ToString() },
            { "playerID", PlayerID.ToString() }
        };
        return formData;
    }
}
public sealed class DeleteTeamOptions(Guid leaderboardID, Guid teamID)
{
    private Guid LeaderboardID { get; } = leaderboardID;
    private Guid TeamID { get; } = teamID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() },
            { "teamID", TeamID.ToString() }
        };
        return formData;
    }
}
public sealed class GetTeamOptions(Guid leaderboardID, Guid teamID)
{
    private Guid LeaderboardID { get; } = leaderboardID;
    private Guid TeamID { get; } = teamID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() },
            { "teamID", TeamID.ToString() }
        };
        return formData;
    }
}
public sealed class DeleteTeamPlayerOptions(Guid leaderboardID, Guid teamID, Guid playerID)
{
    private Guid LeaderboardID { get; } = leaderboardID;
    private Guid TeamID { get; } = teamID;
    private Guid PlayerID { get; } = playerID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() },
            { "teamID", TeamID.ToString() },
            { "playerID", PlayerID.ToString() }
        };
        return formData;
    }
}
public sealed class UpdateTeamOptions(Guid leaderboardID, Guid teamID, string name)
{
    private Guid LeaderboardID { get; } = leaderboardID;
    private Guid TeamID { get; } = teamID;
    private string Name { get; } = name;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() },
            { "teamID", TeamID.ToString() },
            { "teamName", Name }
        };
        return formData;
    }
}
public sealed class CreateTeamOptions(Guid leaderboardID, string name)
{
    private Guid LeaderboardID { get; } = leaderboardID;
    private string Name { get; } = name;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() },
            { "teamName", Name }
        };
        return formData;
    }
}
public sealed class ListTeamOptions
{
    private Guid LeaderboardID { get; }
    private GetTeamsOrdering? Ordering { get; }
    
    public ListTeamOptions(Guid leaderboardID, GetTeamsOrdering ordering)
    {
        LeaderboardID = leaderboardID;
        Ordering = ordering;
    } 
    public ListTeamOptions(Guid leaderboardID)
    {
        LeaderboardID = leaderboardID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() }
        };
        if (Ordering.HasValue) formData.Add("order", Ordering.Value.ToString());
        return formData;
    }
}
public sealed class ListTeamPlayersOptions
{
    private Guid LeaderboardID { get; }
    private Guid TeamID { get; }
    private TeamPlayersOrdering? Ordering { get; }
    
    public ListTeamPlayersOptions(Guid leaderboardID, Guid teamID, TeamPlayersOrdering ordering)
    {
        LeaderboardID = leaderboardID;
        TeamID = teamID;
        Ordering = ordering;
    } 
    public ListTeamPlayersOptions(Guid leaderboardID, Guid teamID)
    {
        LeaderboardID = leaderboardID;
        TeamID = teamID;
    } 

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "leaderboardID", LeaderboardID.ToString() },
            { "teamID", TeamID.ToString() }
        };
        if (Ordering.HasValue) formData.Add("order", Ordering.Value.ToString());
        return formData;
    }
}