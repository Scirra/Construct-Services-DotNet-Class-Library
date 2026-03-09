# Cloud Save Service

For full documentation, please refer to the [full Construct Game Services docs][cgs-docs].  Please note, this library may contain some overload methods for convenience that do not have specific listed end points in the documentation.

> [!NOTE]
> A lot of these examples can be called from both an API key authenticated service, or player authenticated service.  The method call for each service may require additional parameters (for example, most requests authenticated with an API key require a player ID parameter).  In the interests of being concise, we have not given code examples for both types of services.

All methods are available as synchronous calls, and asynchronous calls.  All methods return an object that lets you know if the request succeeded or not.

# Cloud Save Service Examples

 - [The Cloud Save Service object][internal-service]  
   Create this object to make requests against this service

 - [Cloud Save examples][internal-cloud-saves]  
   Examples showing how to save and load data

 - [Bucket examples][internal-buckets]  
   Buckets are public containers/folders which players can save/load to and from

 - [Cloud Save Rating examples][internal-ratings]  
   You can allow players to rate Cloud Saves in buckets
   
# The Cloud Save Service Object

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

There are a few ways to construct a service object depending on your intentions:

### Requests where a secret API key is required

> [!WARNING]
> **Never** use the following code client side.  You are doing something wrong and potentially dangerous if you do this.

Pass in your game ID as a Guid, and your secret API key.  You can create API keys from your [CGS account][cgs-account].

```C#
var service = new CloudSaveService(
    yourGameID, 
    new SecretAPIKey("your-secret-key")
);
```

### Requests as a logged in player

> [!TIP]
> This is safe to use client side as well as server side.

If you are making requests on behalf of a logged in player, create a new Player service object passing in the players session key as follows:

```C#
var service = new PlayerCloudSaveService(
    yourGameID,
    new SessionKey("players-session-key")
);
```

### Requests where no authentication is required

Some requests do not require a secret key, or a player to be logged in.  You probably don't need to use this method, as the above two service objects can still call the end points that do not need authentication.

```C#
var service = new CloudSaveService(
    yourGameID
);
```

# Cloud Saves

## Create a Cloud Save in a Bucket
```C#
var createBucketSaveResponse = service.CreateCloudSave(new CreateCloudSaveOptions
{
    BucketID = bucketID,
    Data = byteArray,
    Key = "my.save.1",
    Name = "My Save File",
    Picture = new PictureData(pictureBytes)
});
if (createBucketSaveResponse.Success)
{
    var newSave = createBucketSaveResponse.CloudSave;
}
```

## Create a private Cloud Save in a Players account
```C#
// Create a private Cloud Save in the Players account
var createPrivateSaveResponse = service.CreateCloudSave(new CreateCloudSaveOptions
{
    Data = byteArray,
    Key = "my.save.1",
    Name = "My Save File",
    Picture = new PictureData(pictureBytes)
});
if (createPrivateSaveResponse.Success)
{
    var newSave = createPrivateSaveResponse.CloudSave;
}
```

## Get a Cloud Save
```C#
var getCloudSaveResponse = service.GetCloudSave(cloudSaveID);
if (getCloudSaveResponse.Success)
{
    var cloudSave = getCloudSaveResponse.CloudSave;
}
```

## Get a Cloud Save by Key
```C#
// Private save in Players account
var getPlayersPrivateCloudSaveResponse = service.GetPlayerSaveByKey("my.key");
if (getPlayersPrivateCloudSaveResponse.Success)
{
    var cloudSave = getPlayersPrivateCloudSaveResponse.CloudSave;
}

// A save in a Bucket
var getBucketCloudSaveResponse = service.GetBucketSaveByKey(bucketID, "my.key");
if (getBucketCloudSaveResponse.Success)
{
    var cloudSave = getBucketCloudSaveResponse.CloudSave;
}
```

## List a Players saves
```C#
// Private saves
var getPrivateSavesResponse = service.ListPrivateCloudSaves(new ListPlayersPrivateSavesOptions
    {
        SortBy = GetPlayerCloudSaveSortMethod.Newest
    },
    new PaginationOptions(1, 20)
);
if (getPrivateSavesResponse.Success)
{
    var cloudSaves = getPrivateSavesResponse.CloudSaves;
}

// Saves in buckets
var getBucketSavesResponse = service.ListPlayersCloudSaves(new ListPlayersSavesOptions
    {
        SortBy = GetPlayerCloudSaveSortMethod.KeyAZ,
        Filters = new ListPlayerCloudSaveFilters
        {
            Key = "some.key"
        }
    },
    new PaginationOptions(1, 20)
);
if (getBucketSavesResponse.Success)
{
    var cloudSaves = getBucketSavesResponse.CloudSaves;
}
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
var deletePictureResponse = service.DeletePicture(cloudSaveID);
if (deletePictureResponse.Success)
{
    // Picture was deleted
}
```

## Set a Cloud Saves Picture
```C#
var setPictureResponse = service.SetPicture(cloudSaveID, new PictureData(pictureBytes));
if (setPictureResponse.Success)
{
    // Picture was set
}
```

## Delete a Cloud Save
> [!WARNING]
> This is a permanent and irreversible action.
```C#
var deleteCloudSaveResponse = service.DeleteCloudSave(cloudSaveID);
if (deleteCloudSaveResponse.Success)
{
    // Cloud save was deleted
}
```

# Buckets

## Create a Bucket
```C#
var createBucketResponse = service.CreateBucket(new CreateBucketOptions
{
    Name = "Official Examples"
    AccessMode = CloudSaveBucketAccessMode.PublicRead,
    AllowRatings = true
});
if (createBucketResponse.Success)
{
    var newBucket = createBucketResponse.Bucket;
}
```

## Update a Bucket
```C#
var updateBucketResponse = service.UpdateBucket(bucketID, new UpdateBucketOptions
{
    Name = "New Name",
    AccessMode = CloudSaveBucketAccessMode.PublicReadWrite,
    MaxSavesPerPlayer = 3
});
if (updateBucketResponse.Success)
{
    var updatedBucket = updateBucketResponse.Bucket;
}
```

## Get a Bucket
```C#
var getBucketResponse = service.GetBucket(bucketID);
if (getBucketResponse.Success)
{
    var bucket = getBucketResponse.Bucket;
}
```

## List all Buckets
```C#
var listBucketsResponse = service.ListBuckets(new ListBucketOptions
    {
        SortBy = GetBucketsSortMethod.MostData
    },
    new PaginationOptions(1, 20)
);
if (listBucketsResponse.Success)
{
    var buckets = listBucketsResponse.Buckets;
}
```

## List Bucket Saves
```C#
var listBucketSavesResponse = service.ListCloudSaves(bucketID,
    new ListBucketSavesOptions
    {
        Filters = new ListBucketCloudSaveFilters
        {
            PlayerIDs = playerIDs,
            CloudSaveIDs = cloudSaveIDs,
            Key = "key.filter"
        },
        SortBy = ListBucketCloudSaveSortMethod.HighestRated
    },
    new PaginationOptions(1, 20)
);
if (listBucketSavesResponse.Success)
{
    var buckets = listBucketSavesResponse.CloudSaves;
}
```
## Delete a Bucket
> [!WARNING]
> This is a permanent and irreversible action.  All Cloud Saves in the bucket will also be permanently deleted.
```C#
var deleteBucketResponse = service.DeleteBucket(bucketID);
if (deleteBucketResponse.Success)
{
    // Bucket was deleted
}
```

# Ratings

## Create a Bucket Rating Dimension
```C#
var createRatingDimensionResponse = service.CreateRatingDimension(
    bucketID,
    new Dimensions.CreateRatingDimensionOptions
    {
        ID = "mydimension",
        Title = "Graphics",
        Description = "How do you rate the graphics in this save on a scale 0-10?",
        MaxRating = 9
    }
);
if (createRatingDimensionResponse.Success)
{
    var newDimension = createRatingDimensionResponse.Dimension;
}
```

## Update a Bucket Rating Dimension
```C#
var updateRatingDimensionResponse = service.UpdateRatingDimension(
    bucketID,
    "mydimension",
    new Dimensions.UpdateRatingDimensionOptions
    {
        Title = "New title",
        MaxRating = 100
    }
);
if (updateRatingDimensionResponse.Success)
{
    var updatedDimension = updateRatingDimensionResponse.Dimension;
}
```

## List all Bucket Rating Dimensions
```C#
var listRatingDimensionsResponse = service.ListRatingDimensions(bucketID);
if (listRatingDimensionsResponse.Success)
{
    var ratingDimensions = listRatingDimensionsResponse.Dimensions;
}
```

## Rate a Cloud Save
```C#
var rateResponse = service.Rate(cloudSaveID, new RateObjectOptions
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
if (rateResponse.Success)
{
    // Rating succesfully recorded
}
```

## Delete a Bucket Rating Dimension
```C#
var deleteDimensionResponse = service.DeleteRatingDimension(bucketID, "mydimension");
if (deleteDimensionResponse.Success)
{
    // Dimension was deleted
}
```

[cgs-account]: https://cgs.construct.net
[cgs-docs]: https://www.construct.net/en/game-services/manuals/game-services/cloud-save/concepts
[internal-service]: #the-cloud-save-service-object
[internal-cloud-saves]: #cloud-saves
[internal-buckets]: #buckets
[internal-ratings]: #ratings