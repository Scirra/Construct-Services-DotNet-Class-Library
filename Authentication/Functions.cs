using ConstructServices.Authentication.Objects;
using JetBrains.Annotations;

namespace ConstructServices.Authentication
{
    public static class Functions
    {
        [UsedImplicitly]
        public static string GetProviderLogoURL(this PlayerLoginProvider playerLoginProvider)
        {
            var provider = (LoginProvider)playerLoginProvider.ProviderID;
            return GetProviderLogoURL(provider);
        }

        [UsedImplicitly]
        public static string GetProviderLogoURL(this LoginProvider provider)
        {
            string logoFilename;
            switch (provider)
            {
                case LoginProvider.Facebook:
                {
                    logoFilename = "faceboook-logo.svg";
                    break;
                }
                case LoginProvider.Discord:
                {
                    logoFilename = "discord-logo.svg";
                    break;
                }
                case LoginProvider.X:
                {
                    logoFilename = "x-logo.svg";
                    break;
                }
                case LoginProvider.Reddit:
                {
                    logoFilename = "reddit-logo.svg";
                    break;
                }
                case LoginProvider.Yandex:
                {
                    logoFilename = "yandex-logo.svg";
                    break;
                }
                case LoginProvider.Google:
                {
                    logoFilename = "google-logo.svg";
                    break;
                }
                case LoginProvider.Steam:
                {
                    logoFilename = "steam-logo.svg";
                    break;
                }
                case LoginProvider.BattleNet:
                case LoginProvider.BattleNetChina:
                {
                    logoFilename = "battlenet-logo.svg";
                    break;
                }
                case LoginProvider.Microsoft:
                {
                    logoFilename = "microsoft-logo.svg";
                    break;
                }
                case LoginProvider.Apple:
                {
                    logoFilename = "apple-logo.svg";
                    break;
                }
                default: return string.Empty;
            }
            return "https://auth.construct.net/images/1/" + logoFilename;
        }
    }
}
