using ConstructServices.Leaderboards.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Leaderboards.Objects;

public sealed class AssignPlayerOptions(Guid teamID, Guid playerID)
{
    [UsedImplicitly]
    public Guid TeamID { get; private set; } = teamID;

    [UsedImplicitly]
    public Guid PlayerID { get; private set; } = playerID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "teamID", TeamID.ToString() },
            { "playerID", PlayerID.ToString() }
        };
        return formData;
    }
}
public sealed class DeleteTeamOptions(Guid teamID)
{
    private Guid TeamID { get; } = teamID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "teamID", TeamID.ToString() }
        };
        return formData;
    }
}
public sealed class GetTeamOptions(Guid teamID)
{
    private Guid TeamID { get; } = teamID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "teamID", TeamID.ToString() }
        };
        return formData;
    }
}
public sealed class DeleteTeamPlayerOptions(Guid teamID, Guid playerID)
{
    private Guid TeamID { get; } = teamID;
    private Guid PlayerID { get; } = playerID;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "teamID", TeamID.ToString() },
            { "playerID", PlayerID.ToString() }
        };
        return formData;
    }
}
public sealed class UpdateTeamOptions(Guid teamID, string name)
{
    private Guid TeamID { get; } = teamID;
    private string Name { get; } = name;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "teamID", TeamID.ToString() },
            { "teamName", Name }
        };
        return formData;
    }
}
public sealed class CreateTeamOptions(string name)
{
    private string Name { get; } = name;

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "teamName", Name }
        };
        return formData;
    }
}
public sealed class ListTeamOptions
{
    private GetTeamsOrdering? Ordering { get; }
    
    public ListTeamOptions(GetTeamsOrdering ordering)
    {
        Ordering = ordering;
    } 
    public ListTeamOptions()
    {
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>();
        if (Ordering.HasValue) formData.Add("order", Ordering.Value.ToString());
        return formData;
    }
}
public sealed class ListTeamPlayersOptions
{
    private Guid TeamID { get; }
    private TeamPlayersOrdering? Ordering { get; }
    
    public ListTeamPlayersOptions(Guid teamID, TeamPlayersOrdering ordering)
    {
        TeamID = teamID;
        Ordering = ordering;
    } 
    public ListTeamPlayersOptions(Guid teamID)
    {
        TeamID = teamID;
    } 

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "teamID", TeamID.ToString() }
        };
        if (Ordering.HasValue) formData.Add("order", Ordering.Value.ToString());
        return formData;
    }
}