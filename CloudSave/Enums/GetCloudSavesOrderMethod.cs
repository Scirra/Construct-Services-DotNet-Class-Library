using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Enums;

public enum ListPlayerCloudSavesSortMethod
{
    [UsedImplicitly] NameAZ,
    [UsedImplicitly] NameZA,
    [UsedImplicitly] KeyAZ,
    [UsedImplicitly] KeyZA,
    [UsedImplicitly] Newest,
    [UsedImplicitly] Oldest
}
public enum ListBucketCloudSavesSortMethod
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