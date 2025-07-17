namespace ConstructServices.Authentication.Enums
{
    public enum PlayerRestriction
    {
        [PlayerRestriction("Upload Avatar", "Prevents player from being able to set a new avatar.")]
        PlayerUploadAvatar = 0,

        [PlayerRestriction("Change Player Name", "Prevents player from being able to set a new player name for themselves.")]
        PlayerChangePlayerName = 1
    }

    public class PlayerRestrictionAttribute : System.Attribute
    {
        public string FriendlyName { get; set; }
        public string Description { get; set; }
        public PlayerRestrictionAttribute(string friendlyName, string description)
        {
            FriendlyName = friendlyName;
            Description = description;
        }
    }

}
