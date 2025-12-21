using ConstructServices.Authentication.Objects;
using JetBrains.Annotations;

namespace ConstructServices.Authentication;

public static class Functions
{
    [UsedImplicitly]
    public static string GetProviderLogoURL(this PlayerLoginProvider playerLoginProvider)
    {
        var provider = (LoginProvider)playerLoginProvider.ProviderID;
        return provider.GetProviderLogoURL();
    }

    [UsedImplicitly]
    public static string GetProviderLogoURL(this LoginProvider provider)
    {
        string logoFilename;
        switch (provider)
        {
            case LoginProvider.UsernamePassword:
            {
                logoFilename = "username-password.svg";
                break;
            }
            case LoginProvider.Facebook:
            {
                logoFilename = "facebook-logo.svg";
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
            case LoginProvider.Github:
            {
                logoFilename = "github-logo.svg";
                break;
            }
            case LoginProvider.TikTok:
            {
                logoFilename = "tiktok-logo.svg";
                break;
            }
            case LoginProvider.ItchIO:
            {
                logoFilename = "itchio-logo.svg";
                break;
            }
            case LoginProvider.Twitch:
            {
                logoFilename = "twitch-logo.svg";
                break;
            }
            default: return string.Empty;
        }
        return "https://auth.construct.net/images/1/" + logoFilename;
    }
}