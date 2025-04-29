namespace ConstructServices
{
    public class GlobalConfig
    {
        internal static bool DevMode { get; private set; }

        public static void SetDevMode()
        {
            DevMode = true;
        }
    }
}
