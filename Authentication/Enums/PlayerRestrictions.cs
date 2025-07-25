namespace ConstructServices.Authentication.Enums;

public enum PlayerRestriction
{
    /* 0 - 100 Player account restrictions */
    [PlayerRestriction("Upload Avatar", "Prevents player from being able to set a new avatar.")]
    PlayerUploadAvatar = 0,

    [PlayerRestriction("Change Player Name", "Prevents player from being able to set a new player name for themselves.")]
    PlayerChangePlayerName = 1,
        
    /* 101-200 Cloud save restrictions */
    [PlayerRestriction("Cloud Save To Game Buckets", "Prevents player from being able to cloud save to game buckets.")]
    PlayerUploadCloudSaveGameBucketBlobs = 101,

    [PlayerRestriction("Cloud Save To Player Account", "Prevents player from being able to cloud save files to their own player account.")]
    PlayerUploadCloudSavePlayerBlobs = 102,

    /* 201-300 Rating restrictions */
    [PlayerRestriction("Rate Things", "Prevents player from being able to rate things.")]
    PlayerRateObjects = 200
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