using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Enums;

public enum GetPlayerCloudSaveFilters
{
    [UsedImplicitly] Key,
    [UsedImplicitly] Name
}
public enum GetBucketCloudSaveFilters
{
    [UsedImplicitly] Key,
    [UsedImplicitly] Name,
    [UsedImplicitly] PlayerIDs,
    [UsedImplicitly] Rating,
    [UsedImplicitly] TotalRatings
}