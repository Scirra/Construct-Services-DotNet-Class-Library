using JetBrains.Annotations;

namespace ConstructServices;

public class GlobalConfig
{
    internal static bool DevMode { get; private set; }

    [UsedImplicitly]
    public static void SetDevMode()
    {
        DevMode = true;
    }
}