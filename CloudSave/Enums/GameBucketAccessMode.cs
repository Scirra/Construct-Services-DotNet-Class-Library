using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Enums;

public enum CloudSaveBucketAccessMode
{
    [UsedImplicitly]
    Private,
    
    [UsedImplicitly]
    PublicRead,
    
    [UsedImplicitly]
    PublicReadWrite
}