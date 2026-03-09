using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.CloudSave.Actions;

public sealed class ListBucketCloudSaveFilters
{
    public string Name { get; [UsedImplicitly] set; }
    public string Key { get; [UsedImplicitly] set; }
    public HashSet<Guid> PlayerIDs { get; [UsedImplicitly] set; }
    public Dictionary<string, int> TotalRatings { get; [UsedImplicitly] set; }
    public Dictionary<string, byte> MinRating { get; [UsedImplicitly] set; }
    public HashSet<Guid> CloudSaveIDs { get; [UsedImplicitly] set; }
}