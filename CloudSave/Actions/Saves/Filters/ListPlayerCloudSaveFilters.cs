using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

public sealed class ListPlayerCloudSaveFilters
{
    public string Name { get; [UsedImplicitly] set; }
    public string Key { get; [UsedImplicitly] set; }
}