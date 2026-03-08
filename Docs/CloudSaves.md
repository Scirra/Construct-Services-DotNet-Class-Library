# Cloud Save Requests

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

There are a few ways to construct a service object depending on your intentions:

## Requests where a secret API key is required

> [!WARNING]
> **Never** use the following code client side.  You are doing something wrong and potentially dangerous if you do this.

Pass in your game ID as a Guid, and your secret API key.  You can create API keys from your [CGS account][cgs-account].

```C#
var service = new CloudSaveService(
    yourGameID, 
    new SecretAPIKey("your-secret-key")
);
```

## Requests as a logged in player

> [!TIP]
> This is safe to use client side as well as server side.

If you are making requests on behalf of a logged in player, create a new Player service object passing in the players session key as follows:

```C#
var service = new PlayerCloudSaveService(
    yourGameID,
    new SessionKey("players-session-key")
);
```

## Requests where no authentication is required

Some requests do not require a secret key, or a player to be logged in.  You probably don't need to use this method, as the above two service objects can still call the end points that do not need authentication.

```C#
var service = new CloudSaveService(
    yourGameID
);
```

# Example Code

For full documentation, please refer to the [full Construct Game Services docs][cgs-docs].  Please note, this library may contain some overload methods for convenience that do not have specific listed end points in the documentation.

> [!NOTE]
> A lot of these examples can be called from both an API key authenticated service, or player authenticated service.  The method call for each service may require additional parameters (for example, most requests authenticated with an API key require a player ID parameter).  In the interests of being concise, we have not given code examples for both types of services.

All methods are available as synchronous calls, and asynchronous calls.  All methods return an object that lets you know if the request succeeded or not.  If you're requesting data, the requested data will also be returned in this object.  A typically pattern when using this API would be:
```C#
var result = service.GetSomething();
if (!result.Success)
{
    var errorMessage = result.ErrorMessage;    
    // Retry or handle the error
}
else
{
    var thing = result.Thing;
}
```

## Create a Cloud Save
```C#
// Create a Cloud Save in a Bucket
service.CreateCloudSave(new Saves.CreateCloudSaveOptions
{
    BucketID = bucketID,
    Data = byteArray,
    Key = "my.save.1",
    Name = "My Save File",
    Picture = new PictureData(pictureBytes)
});

// Create a private Cloud Save in the Players account
service.CreateCloudSave(new Saves.CreateCloudSaveOptions
{
    Data = byteArray,
    Key = "my.save.1",
    Name = "My Save File",
    Picture = new PictureData(pictureBytes)
});
```

## Get a Cloud Save
```C#
service.GetCloudSave(cloudSaveID);
```

## Get a Cloud Save by Key
```C#
// Private save in Players account
service.GetPlayerSaveByKey("my.key");

// A save in a Bucket
service.GetBucketSaveByKey(bucketID, "my.key");
```

## List a Players saves
```C#

// Private saves
service.ListPrivateCloudSaves(new Saves.ListPlayersPrivateSavesOptions
    {
        SortBy = GetPlayerCloudSaveSortMethod.Newest
    },
    new PaginationOptions(1, 20)
);

// Saves in buckets
service.ListPlayersCloudSaves(new Saves.ListPlayersSavesOptions
    {
        SortBy = GetPlayerCloudSaveSortMethod.KeyAZ,
        Filters = new ListPlayerCloudSaveFilters
        {
            Key = "some.key"
        }
    },
    new PaginationOptions(1, 20)
);
```

## Get Cloud Save data
```C#
// By ID
var bytes = service.GetCloudSaveBytes(cloudSaveID);

// By Cloud Save object
var bytes = service.GetCloudSaveBytes(cloudSaveObject);
```

## Delete a Cloud Saves Picture
```C#
service.DeletePicture(cloudSaveID);
```

## Set a Cloud Saves Picture
```C#
service.SetPicture(cloudSaveID, new PictureData(pictureBytes));
```

## Delete a Cloud Save
```C#
service.DeleteCloudSave(cloudSaveID);
```

## Create a Bucket
```C#
service.CreateBucket(new Buckets.CreateBucketOptions
{
    Name = "Official Examples"
    AccessMode = CloudSaveBucketAccessMode.PublicRead,
    AllowRatings = true
});
```

## Update a Bucket
```C#
service.UpdateBucket(bucketID, new Buckets.UpdateBucketOptions
{
    Name = "New Name",
    AccessMode = CloudSaveBucketAccessMode.PublicReadWrite,
    MaxSavesPerPlayer = 3
});
```

## Get a Bucket
```C#
service.GetBucket(bucketID);
```

## List all Buckets
```C#
service.ListBuckets(new Buckets.ListBucketOptions
    {
        SortBy = GetBucketsSortMethod.MostData
    },
    new PaginationOptions(1, 20)
);
```

## List Bucket Saves
```C#
service.ListCloudSaves(bucketID,
    new Buckets.ListBucketSavesOptions
    {
        Filters = new ListBucketCloudSaveFilters
        {
            PlayerIDs = playerIDs,
            BlobIDs = blobIDs,
            Key = "key.filter"
        },
        SortBy = ListBucketCloudSaveSortMethod.HighestRated
    },
    new PaginationOptions(1, 20)
);
```
## Delete a Bucket
> [!WARNING]
> This is a permanent and irreversible action.  All Cloud Saves in the bucket will also be permanently deleted.
```C#
service.DeleteBucket(bucketID);
```

## Create a Bucket Rating Dimension
```C#
service.CreateRatingDimension(
    bucketID,
    new Dimensions.CreateRatingDimensionOptions
    {
        ID = "mydimension",
        Title = "Graphics",
        Description = "How do you rate the graphics in this save on a scale 0-10?",
        MaxRating = 9
    }
);
```

## Update a Bucket Rating Dimension
```C#
service.UpdateRatingDimension(
    bucketID,
    "mydimension",
    new Dimensions.UpdateRatingDimensionOptions
    {
        Title = "New title",
        MaxRating = 100
    }
);
```

## List all Bucket Rating Dimensions
```C#
service.ListRatingDimensions(channelID);
```

## Rate a Cloud Save
```C#
service.Rate(cloudSaveID, new RateObjectOptions
{
    DimensionlessRating = 5,
    DimensionRatings =
    [
        new DimensionRating
        {
            DimensionID = "mydimension",
            Rating = 8
        }
    ]
});
```

## Delete a Bucket Rating Dimension
```C#
service.DeleteRatingDimension(bucketID, "mydimension");
```

[cgs-account]: https://cgs.construct.net
[cgs-docs]: https://www.construct.net/en/game-services/manuals/game-services/cloud-save/concepts