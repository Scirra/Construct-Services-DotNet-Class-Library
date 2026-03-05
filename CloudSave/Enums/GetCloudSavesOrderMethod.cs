using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Enums;

public enum GetPlayerCloudSaveSortMethod
{
    [UsedImplicitly] NameAZ,
    [UsedImplicitly] NameZA,
    [UsedImplicitly] KeyAZ,
    [UsedImplicitly] KeyZA,
    [UsedImplicitly] Newest,
    [UsedImplicitly] Oldest
}
public enum ListBucketCloudSaveSortMethod
{
    [UsedImplicitly] NameAZ,
    [UsedImplicitly] NameZA,
    [UsedImplicitly] KeyAZ,
    [UsedImplicitly] KeyZA,
    [UsedImplicitly] Newest,
    [UsedImplicitly] Oldest,
    [UsedImplicitly] HighestRated,
    [UsedImplicitly] LowestRated
}