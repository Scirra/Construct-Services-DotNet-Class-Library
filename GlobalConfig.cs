using JetBrains.Annotations;

namespace ConstructServices;

[UsedImplicitly]
public sealed class GlobalConfig
{
    internal static bool DevMode { get; private set; }

    [UsedImplicitly]
    public static void SetDevMode()
    {
        DevMode = true;
    }
}