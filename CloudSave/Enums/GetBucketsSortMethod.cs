using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Enums;

public enum GetBucketsSortMethod
{
    [UsedImplicitly] AZ,
    [UsedImplicitly] ZA,
    [UsedImplicitly] MostBlobs,
    [UsedImplicitly] LeastBlobs,
    [UsedImplicitly] MostData,
    [UsedImplicitly] LeastData
}