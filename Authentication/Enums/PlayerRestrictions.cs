using JetBrains.Annotations;

namespace ConstructServices.Authentication.Enums;

public enum PlayerRestriction
{
    /* 0 - 100 Player account restrictions */
    [PlayerRestriction("Upload Avatar", "Prevents player from being able to set a new avatar.")]
    [UsedImplicitly] PlayerUploadAvatar = 0,

    [PlayerRestriction("Change Player Name", "Prevents player from being able to set a new player name for themselves.")]
    [UsedImplicitly] PlayerChangePlayerName = 1,
        
    /* 101-200 Cloud save restrictions */
    [PlayerRestriction("Cloud Save To Game Buckets", "Prevents player from being able to cloud save to game buckets.")]
    [UsedImplicitly] PlayerUploadCloudSaveGameBucketBlobs = 101,

    [PlayerRestriction("Cloud Save To Player Account", "Prevents player from being able to cloud save files to their own player account.")]
    [UsedImplicitly] PlayerUploadCloudSavePlayerBlobs = 102,

    /* 201-300 Rating restrictions */
    [PlayerRestriction("Rate Things", "Prevents player from being able to rate things.")]
    [UsedImplicitly] PlayerRateObjects = 200
}

[UsedImplicitly] 
public sealed class PlayerRestrictionAttribute(string friendlyName, string description) : System.Attribute
{
    public string FriendlyName { [UsedImplicitly] get; set; } = friendlyName;
    public string Description { [UsedImplicitly] get; set; } = description;
}