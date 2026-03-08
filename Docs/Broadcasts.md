# Broadcast Requests

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

There are a few ways to construct a service object depending on your intentions:

## Requests where a secret API key is required

> [!WARNING]
> **Never** use the following code client side.  You are doing something wrong and potentially dangerous if you do this.

Pass in your game ID as a Guid, and your secret API key.  You can create API keys from your [CGS account][cgs-account].

```C#
var service = new BroadcastService(
    yourGameID, 
    new SecretAPIKey("your-secret-key")
);
```

## Requests as a logged in player

> [!TIP]
> This is safe to use client side as well as server side.

If you are making requests on behalf of a logged in player, create a new Player service object passing in the players session key as follows:

```C#
var service = new PlayerBroadcastService(
    yourGameID,
    new SessionKey("players-session-key")
);
```

## Requests where no authentication is required

Some requests do not require a secret key, or a player to be logged in.  You probably don't need to use this method, as the above two service objects can still call the end points that do not need authentication.

```C#
var service = new BroadcastService(
    yourGameID
);
```

# Example Code

For full documentation, please refer to the [full Construct Game Services docs][cgs-docs].  Please note, this library may contain some overload methods for convenience that do not have specific listed end points in the documentation.

> [!NOTE]
> A lot of these examples can be called from both an API key authenticated service, or player authenticated service.  The method call for each service may require additional parameters (for example, most requests authenticated with an API key require a player ID parameter).  In the interests of being concise, we have not given code examples for both types of services.

All methods are available as synchronous calls, and asynchronous calls.  All methods return an object that lets you know if the request succeeded or not.

# Channels

## Create a Broadcast Channel
```C#
var createChannelResponse = service.CreateChannel(new CreateChannelOptions
{
    Name = "Game Updates and News",
    Description = "For game updates and news!",
    AllowRatings = true
});
if(createChannelResponse.Success)
{
    var newChannel = createChannelResponse.Channel;
}
```

## Update a Broadcast Channel
```C#
var updateChannelResponse = service.UpdateChannel(
    channelID,
    new Channels.UpdateChannelOptions
    {
        Name = "Game Updates & News",
        Description = "For the latest game updates and news!",
        AllowRatings = true
    }
);
if (updateChannelResponse.Success)
{
    var updatedChannel = updateChannelResponse.Channel;
}
```

## Get a Broadcast Channel
```C#
var getChannelResponse = service.GetChannel(channelID);
if (getChannelResponse.Success)
{
    var channel = getChannelResponse.Channel;
}
```

## List all Broadcast Channels
```C#
var listChannelsResponse = service.ListChannels();
if (listChannelsResponse.Success)
{
    var channels = listChannelsResponse.Channels;
}
```

## Delete a Broadcast Channel
> [!WARNING]
> This is a permanent and irreversible action.  Any messages in the channel are also deleted permamently.
```C#
var deleteResponse = service.DeleteChannel(channelID);
if (deleteResponse.Success)
{
    // Was deleted
}
```

# Messages

## Create a Broadcast Message
```C#
var createMessageResponse = service.CreateMessage(new CreateMessageOptions
{
    ChannelID = channelID,
    Title = "New Feature Added",
    Text = "We're excited to introduce the following new features into the game..."
});
if (createMessageResponse.Success)
{
    var publishedMessage = createMessageResponse.Message;
}
```

## Update a Broadcast Message
```C#
var updateMessageResponse = service.UpdateMessage(
    messageID,
    new Messages.UpdateMessageOptions(
    {
        Title = "A New Feature Added",
        Text = "We're introducing the following new features into the game..."
    }
);
if (updateMessageResponse.Success)
{
    // Was updated
}
```
## Get a Broadcast Message
```C#
var getMessageResponse = service.GetMessage(messageID);
if (getMessageResponse.Success)
{
    var message = getMessageResponse.Message;
}
```

## List Broadcast Messages
> [!NOTE]
> Always returns the messages newest first
```C#
var listMessagesResponse = service.ListMessages(
    channelID, 
    new PaginationOptions(1, 20)
);
if (listMessagesResponse.Success)
{
    var messages = listMessagesResponse.Messages;
}
```

## Delete a Broadcast Message
```C#
var deleteMessageResponse = service.DeleteMessage(messageID);
if (deleteMessageResponse.Success)
{
    // Message was deleted
}
```

# Ratings

## Create a Broadcast Channel Rating Dimension
```C#
var createDimensionResponse = service.CreateRatingDimension(
    channelID,
    new CreateRatingDimensionOptions
    {
        ID = "mydimension",
        Title = "Positivity",
        Description = "How do you rate the positivity of this message on a scale 1-5?",
        MaxRating = 4
    }
);
if (createDimensionResponse.Success)
{
    var newDimension = createDimensionResponse.Dimension;
}
```

## Update a Broadcast Channel Rating Dimension
```C#
var updateDimensionResponse = service.UpdateRatingDimension(
    channelID,
    "mydimension",
    new UpdateRatingDimensionOptions
    {
        Title = "New title",
        MaxRating = 100
    }
);
if (updateDimensionResponse.Success)
{
    var updatedDimension = updateDimensionResponse.Dimension;
}
```

## List all Broadcast Channels Rating Dimensions
```C#
var listDimensionsResponse = service.ListRatingDimensions(channelID);
if (listDimensionsResponse.Success)
{
    var dimensions = listDimensionsResponse.Dimensions;
}
```

## Rate a Broadcast Message
```C#
var rateMessageResponse = service.Rate(messageID, new RateObjectOptions
{
    DimensionlessRating = 5,
    DimensionRatings =
    [
        new DimensionRating
        {
            DimensionID = "mydimension",
            Rating = 4
        }
    ]
});
if (rateMessageResponse.Success)
{
    var messageRating = rateMessageResponse.Rating;
}
```

## Delete a Broadcast Channel Rating Dimension
```C#
var deleteDimensionResponse = service.DeleteRatingDimension(channelID, "mydimension");
if (deleteDimensionResponse.Success)
{
    // Dimension was deleted
}
```


[cgs-account]: https://cgs.construct.net
[cgs-docs]: https://www.construct.net/en/game-services/manuals/game-services/broadcasts/concepts