using JetBrains.Annotations;

namespace ConstructServices.Authentication.Enums;

public enum PlayerOrdering
{
    [UsedImplicitly] AZ,
    [UsedImplicitly] ZA,
    [UsedImplicitly] Newest,
    [UsedImplicitly] Oldest
}