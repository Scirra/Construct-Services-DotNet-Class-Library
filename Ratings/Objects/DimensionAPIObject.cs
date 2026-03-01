using ConstructServices.Broadcasts.Objects;
using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Ratings.Objects;

public abstract class RatingDimensionBase
{        
    [UsedImplicitly]
    public string ID { get; set; }

    [UsedImplicitly]
    public string Title { get; set; }

    [UsedImplicitly]
    public string Description { get; set; }

    [UsedImplicitly]
    public string LanguageISO { get; set; }
    
    protected Dictionary<string, string> BuildBaseFormData() => new()
    {
        { "dimensionID", ID },
        { "title", Title },
        { "description", Description },
        { "language", LanguageISO },
    };
}

public abstract class CreateRatingDimensionOptions : RatingDimensionBase
{
    [UsedImplicitly]
    internal Thing ForThing { get; private set; }

    [UsedImplicitly]
    internal Guid ForThingID { get; private set; }

    [UsedImplicitly]
    public byte MaxRating { get; private set; }

    protected CreateRatingDimensionOptions(
        Thing forThing,
        Guid forThingID,
        byte maxRating,
        string id,
        string title,
        string description,
        string languageISO = null)
    {
        ForThing = forThing;
        ForThingID = forThingID;
        MaxRating = maxRating;
        ID = id;
        Title = title;
        Description = description;
        LanguageISO = languageISO;
    }
    protected CreateRatingDimensionOptions(
        Thing forThing,
        string strForThingID,
        byte maxRating,
        string id,
        string title,
        string description,
        string languageISO = null)
    {
        ForThing = forThing;
        ForThingID = Guid.Parse(strForThingID);
        MaxRating = maxRating;
        ID = id;
        Title = title;
        Description = description;
        LanguageISO = languageISO;
    }

    [UsedImplicitly]
    protected internal Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        formData.Add("thingTypeID", ((byte)ForThing).ToString());
        formData.Add("thingID", ForThingID.ToString());
        formData.Add("maxRating", MaxRating.ToString());
        return formData;
    }
}

public sealed class CreateBroadcastChannelRatingDimensionOptions : CreateRatingDimensionOptions
{    
    [UsedImplicitly]
    public CreateBroadcastChannelRatingDimensionOptions(
        Channel channel,
        byte maxRating,
        string id,
        string title,
        string description,
        string languageISO = null) 
        : base(Thing.BroadcastChannel, channel.ID, maxRating, id, title, description, languageISO)
    {
    }

    [UsedImplicitly]
    public CreateBroadcastChannelRatingDimensionOptions(
        Guid channelID,
        byte maxRating,
        string id,
        string title,
        string description,
        string languageISO = null) 
        : base(Thing.BroadcastChannel, channelID, maxRating, id, title, description, languageISO)
    {
    }

    [UsedImplicitly]
    public CreateBroadcastChannelRatingDimensionOptions(
        string channelID,
        byte maxRating,
        string id,
        string title,
        string description,
        string languageISO = null) 
        : base(Thing.BroadcastChannel, channelID, maxRating, id, title, description, languageISO)
    {
    }
}
public sealed class CreateCloudSaveBucketRatingDimensionOptions : CreateRatingDimensionOptions
{
    [UsedImplicitly]
    public CreateCloudSaveBucketRatingDimensionOptions(
        GameBucket bucket,
        byte maxRating,
        string id,
        string title,
        string description,
        string languageISO = null) 
        : base(Thing.BroadcastChannel, bucket.ID, maxRating, id, title, description, languageISO)
    {
    }

    [UsedImplicitly]
    public CreateCloudSaveBucketRatingDimensionOptions(
        Guid bucketID,
        byte maxRating,
        string id,
        string title,
        string description,
        string languageISO = null) 
        : base(Thing.BroadcastChannel, bucketID, maxRating, id, title, description, languageISO)
    {
    }

    [UsedImplicitly]
    public CreateCloudSaveBucketRatingDimensionOptions(
        string bucketID,
        byte maxRating,
        string id,
        string title,
        string description,
        string languageISO = null) 
        : base(Thing.BroadcastChannel, bucketID, maxRating, id, title, description, languageISO)
    {
    }
}

public abstract class UpdateRatingDimensionBase : RatingDimensionBase
{
    [UsedImplicitly]
    public byte? MaxRating { get; set; }

    [UsedImplicitly]
    internal Thing ForThing { get; private set; }

    [UsedImplicitly]
    internal Guid ForThingID { get; private set; }

    protected UpdateRatingDimensionBase(
        Thing forThing, 
        Guid forThingID, 
        string dimensionID)
    {
        ForThing = forThing;
        ForThingID = forThingID;
        ID = dimensionID;
    }

    internal Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        formData.Add("thingTypeID", ((byte)ForThing).ToString());
        formData.Add("thingID", ForThingID.ToString());
        if(MaxRating.HasValue) formData.Add("maxRating", MaxRating.ToString());
        return formData;
    }
}
public sealed class UpdateBroadcastChannelRatingDimensionOptions : UpdateRatingDimensionBase
{
    private const Thing ThisThing = Thing.BroadcastChannel;

    [UsedImplicitly]
    public UpdateBroadcastChannelRatingDimensionOptions(Channel channel, string dimensionID) 
        : base(ThisThing, channel.ID, dimensionID)
    {
    }

    [UsedImplicitly]
    public UpdateBroadcastChannelRatingDimensionOptions(Guid channelID, string dimensionID) 
        : base(ThisThing, channelID, dimensionID)
    {
    }

    [UsedImplicitly]
    public UpdateBroadcastChannelRatingDimensionOptions(string strChannelID, string dimensionID) 
        : base(ThisThing, Guid.Parse(strChannelID), dimensionID)
    {
    }
}

public sealed class UpdateCloudSaveBucketRatingDimensionOptions : UpdateRatingDimensionBase
{
    private const Thing ThisThing = Thing.CloudSaveBucket;

    [UsedImplicitly]
    public UpdateCloudSaveBucketRatingDimensionOptions(GameBucket bucket, string dimensionID) 
        : base(ThisThing, bucket.ID, dimensionID)
    {
    }

    [UsedImplicitly]
    public UpdateCloudSaveBucketRatingDimensionOptions(Guid bucketID, string dimensionID) 
        : base(ThisThing, bucketID, dimensionID)
    {
    }

    [UsedImplicitly]
    public UpdateCloudSaveBucketRatingDimensionOptions(string strBucketID, string dimensionID) 
        : base(ThisThing, Guid.Parse(strBucketID), dimensionID)
    {
    }
}





public abstract class DeleteRatingDimensionOptions
{
    [UsedImplicitly]
    internal Thing ForThing { get; private set; }

    [UsedImplicitly]
    internal Guid ForThingID { get; private set; }

    [UsedImplicitly]
    public string DimensionID { get; private set; }

    protected DeleteRatingDimensionOptions(Thing forThing, Guid forThingID, string dimensionID)
    {
        ForThing = forThing;
        ForThingID = forThingID;
        DimensionID = dimensionID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "thingTypeID", ((byte)ForThing).ToString() },
            { "thingID", ForThingID.ToString() },
            { "dimensionID", DimensionID }
        };
        return formData;
    }
}

public sealed class DeleteBroadcastChannelRatingDimensionOptions : DeleteRatingDimensionOptions
{
    private const Thing ThisThing = Thing.BroadcastChannel;

    [UsedImplicitly]
    public DeleteBroadcastChannelRatingDimensionOptions(Channel channel, string dimensionID) 
        : base(ThisThing, channel.ID, dimensionID)
    {
    }

    [UsedImplicitly]
    public DeleteBroadcastChannelRatingDimensionOptions(Guid channelID, string dimensionID) 
        : base(ThisThing, channelID, dimensionID)
    {
    }

    [UsedImplicitly]
    public DeleteBroadcastChannelRatingDimensionOptions(string strChannelID, string dimensionID) 
        : base(ThisThing, Guid.Parse(strChannelID), dimensionID)
    {
    }
}

public sealed class DeleteCloudSaveBucketRatingDimensionOptions : DeleteRatingDimensionOptions
{
    private const Thing ThisThing = Thing.CloudSaveBucket;

    [UsedImplicitly]
    public DeleteCloudSaveBucketRatingDimensionOptions(GameBucket bucket, string dimensionID) 
        : base(ThisThing, bucket.ID, dimensionID)
    {
    }

    [UsedImplicitly]
    public DeleteCloudSaveBucketRatingDimensionOptions(Guid bucketID, string dimensionID) 
        : base(ThisThing, bucketID, dimensionID)
    {
    }

    [UsedImplicitly]
    public DeleteCloudSaveBucketRatingDimensionOptions(string strBucketID, string dimensionID) 
        : base(ThisThing, Guid.Parse(strBucketID), dimensionID)
    {
    }
}
public abstract class ListRatingDimensionOptions
{
    [UsedImplicitly]
    internal Thing ForThing { get; private set; }

    [UsedImplicitly]
    internal Guid ForThingID { get; private set; }

    protected ListRatingDimensionOptions(
        Thing forThing,
        Guid forThingID)
    {
        ForThing = forThing;
        ForThingID = forThingID;
    }

    [UsedImplicitly]
    protected internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "thingTypeID", ((byte)ForThing).ToString() },
            { "thingID", ForThingID.ToString() }
        };
        return formData;
    }
}
public sealed class ListBroadcastChannelDimensionOptions : ListRatingDimensionOptions
{
    private const Thing ThisThing = Thing.BroadcastChannel;

    [UsedImplicitly]
    public ListBroadcastChannelDimensionOptions(Channel channel) : base(ThisThing, channel.ID)
    {
    }

    [UsedImplicitly]
    public ListBroadcastChannelDimensionOptions(Guid channelID) : base(ThisThing, channelID)
    {
    }

    [UsedImplicitly]
    public ListBroadcastChannelDimensionOptions(string strChannelID) : base(ThisThing, Guid.Parse(strChannelID))
    {
    }
}
public sealed class ListCloudSaveBucketDimensionOptions : ListRatingDimensionOptions
{
    private const Thing ThisThing = Thing.BroadcastChannel;

    [UsedImplicitly]
    public ListCloudSaveBucketDimensionOptions(GameBucket bucket) : base(ThisThing, bucket.ID)
    {
    }

    [UsedImplicitly]
    public ListCloudSaveBucketDimensionOptions(Guid bucketID) : base(ThisThing, bucketID)
    {
    }

    [UsedImplicitly]
    public ListCloudSaveBucketDimensionOptions(string strBucketID) : base(ThisThing, Guid.Parse(strBucketID))
    {
    }
}