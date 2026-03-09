using ConstructServices.Broadcasts.Actions;
using ConstructServices.Common;
using ConstructServices.Common.Tests;
using ConstructServices.Ratings.Actions;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ConstructServices.Authentication;
using ConstructServices.Authentication.Actions;
using ConstructServices.Common.Languages;

namespace ConstructServices.Broadcasts.Tests;

public static class Run
{
    private enum BroadcastTest
    {
        CreateChannel,
        ListChannels,
        GetChannel,
        UpdateChannel,

        CreateRatingDimension,
        EditRatingDimension,
        GetRatingDimensions,
        DimensionlessRating,
        DimensionRating,
        CombinedRating,

        CreateMessage,
        ListMessages,
        GetMessage,
        UpdateMessage,
        DeleteMessage,

        DeleteRatingDimension,
        DeleteChannel
    }

    [UsedImplicitly]
    public static List<Tuple<string, TestResult>> RunTests(Guid gameID, SecretAPIKey apiKey, Action<string> logger = null)
    {
        var results = new Dictionary<BroadcastTest, TestResult>();
        var service = new BroadcastService(gameID, apiKey);
        
        var sw = new Stopwatch();
        sw.Start();

        // CREATE CHANNEL
        {
            var createResult = service.CreateChannel(new Channels.CreateChannelOptions
            {
                Name = "Test",
                Description = "Test description",
                LanguageISO = "de",
                AllowRatings = true
            });
            results[BroadcastTest.CreateChannel] = new TestResult(createResult, sw);
            if (createResult.Success)
            {
                var channel = createResult.Channel;

                // LIST CHANNELS
                {
                    sw.Restart();
                    var result = service.ListChannels();
                    results[BroadcastTest.ListChannels] = new TestResult(result, sw);
                    if (result.Success && result.Channels.All(c => c.ID != channel.ID))
                    {
                        results[BroadcastTest.ListChannels] = new TestResult(TestResultStatus.Failed, sw, "Channel not found.");
                    }
                }

                // GET CHANNEL
                {
                    sw.Restart();
                    var result = service.GetChannel(channel.ID);
                    results[BroadcastTest.GetChannel] = new TestResult(result, sw);
                }

                // UPDATE CHANNEL
                {
                    sw.Restart();
                    var result = service.UpdateChannel(
                        channel.ID,
                        new Channels.UpdateChannelOptions
                        {
                            Name = "New name"
                        }
                    );
                    results[BroadcastTest.UpdateChannel] = new TestResult(result, sw);
                }

                // CREATE RATING DIMENSION
                const string ratingDimensionID = "testdimension";
                {
                    sw.Restart();
                    var createDimensionResult = service.CreateRatingDimension(
                        channel.ID,
                        new Dimensions.CreateRatingDimensionOptions
                        {
                            ID = ratingDimensionID,
                            Language = SourceLanguage.English,
                            Title = "Test Title",
                            MaxRating = 10
                        }
                    );
                    results[BroadcastTest.CreateRatingDimension] = new TestResult(createDimensionResult, sw);

                    if (createDimensionResult.Success)
                    {
                        var dimension = createDimensionResult.Dimension;
                        const string testLangCode = "RU";
                        
                        // UPDATE RATING DIMENSION
                        {
                            sw.Restart();
                            var result = service.UpdateRatingDimension(
                                channel.ID, dimension.ID, new Dimensions.UpdateRatingDimensionOptions
                                {
                                    Description = "New dimension description",
                                    Title = "My new title",
                                    LanguageISO = testLangCode
                                });
                            results[BroadcastTest.EditRatingDimension] = new TestResult(result, sw);
                        }

                        // LIST RATING DIMENSIONS
                        {
                            sw.Restart();
                            var result = service.ListRatingDimensions(channel.ID);
                            results[BroadcastTest.GetRatingDimensions] = new TestResult(result, sw);

                            var d = result.Dimensions.FirstOrDefault(d => d.ID == dimension.ID);
                            if (d != null && !d.OriginalLanguage.ISO.Equals(testLangCode, StringComparison.CurrentCultureIgnoreCase))
                            {
                                results[BroadcastTest.GetRatingDimensions] = new TestResult(TestResultStatus.Failed, sw, "Language mismatch.");
                            }
                            if (d != null && d.MaxRating != 10)
                            {
                                results[BroadcastTest.GetRatingDimensions] = new TestResult(TestResultStatus.Failed, sw, "Max rating mistmatch [" + d.MaxRating + "]");
                            }
                        }

                        // CREATE MESSAGE
                        {
                            {
                                sw.Restart();
                                var createMessageResult =  service.CreateMessage(new Messages.CreateMessageOptions
                                {
                                    ChannelID = channel.ID,
                                    Text = "Test message",
                                    Title = "My title"
                                });
                                results[BroadcastTest.CreateMessage] = new TestResult(createMessageResult, sw);

                                if (createMessageResult.Success)
                                {
                                    var message = createMessageResult.Message;

                                    // LIST MESSAGES
                                    {
                                        sw.Restart();
                                        var result = service.ListMessages(channel.ID, new PaginationOptions(1, 20));
                                        results[BroadcastTest.ListMessages] = new TestResult(result, sw);
                                        if (result.Success)
                                        {
                                            if (result.Messages.All(c => c.ID != message.ID))
                                            {
                                                results[BroadcastTest.ListMessages] = new TestResult(TestResultStatus.Failed, sw, "Message not found.");
                                            }
                                        }
                                    }
                                    
                                    // UPDATE MESSAGE
                                    {
                                        sw.Restart();
                                        var result = service.UpdateMessage(message.ID, new Messages.UpdateMessageOptions
                                        {
                                            Text = "Another test string"
                                        });
                                        results[BroadcastTest.UpdateMessage] = new TestResult(result, sw);
                                    }

                                    // RATE MESSAGE
                                    {
                                        var authService = new AuthenticationService(gameID, apiKey);
                                        var createPlayerResult = authService.RegisterPlayer(
                                            new Players.RegisterPlayerOptions
                                            {
                                                PlayerName = "Test" + new Random().Next(0, 10000)
                                            }
                                        );
                                        if (createPlayerResult.Success)
                                        {
                                            var player = createPlayerResult.Player;
                                            var playerService = new PlayerBroadcastService(gameID,
                                                new SessionKey(createPlayerResult.Session.Key));
                                            
                                            // RATE MESSAGE DIMENSIONLESS
                                            {
                                                sw.Restart();
                                                var result = playerService.Rate(
                                                    message.ID, 
                                                    new Rating.RateObjectOptions
                                                    {
                                                        DimensionlessRating = 5
                                                    }
                                                );
                                                results[BroadcastTest.DimensionlessRating] = new TestResult(result, sw);
                                            }

                                            // RATE MESSAGE DIMENSION
                                            {
                                                sw.Restart();
                                                var result = playerService.Rate(message.ID, new Rating.RateObjectOptions
                                                {
                                                    DimensionRatings =
                                                    [
                                                        new Rating.DimensionRating
                                                        {
                                                            DimensionID = dimension.ID,
                                                            Rating = 5
                                                        }
                                                    ]
                                                });
                                                results[BroadcastTest.DimensionRating] = new TestResult(result, sw);
                                            }
                                            
                                            // COMBINED RATING
                                            {
                                                sw.Restart();
                                                var result = playerService.Rate(message.ID, new Rating.RateObjectOptions
                                                {
                                                    DimensionlessRating = 3,
                                                    DimensionRatings =
                                                    [
                                                        new Rating.DimensionRating
                                                        {
                                                            DimensionID = dimension.ID,
                                                            Rating = 5
                                                        }
                                                    ]
                                                });
                                                results[BroadcastTest.CombinedRating] = new TestResult(result, sw);
                                            }
                                            
                                            // GET MESSAGE
                                            {
                                                sw.Restart();
                                                var result = playerService.GetMessage(message.ID);
                                                results[BroadcastTest.GetMessage] = new TestResult(result, sw);
                                                if (result.Success)
                                                {
                                                    message = result.Message;

                                                    var myRatings = result.Message.RatingStatus.MyRatings;
                                                    if (!myRatings.ContainsKey(string.Empty))
                                                    {
                                                        results[BroadcastTest.GetMessage] =
                                                            new TestResult(TestResultStatus.Failed, sw,
                                                                "No dimensionless rating returned.");
                                                    }
                                                    else if (myRatings[string.Empty].Value != 3)
                                                    {
                                                        results[BroadcastTest.GetMessage] =
                                                            new TestResult(TestResultStatus.Failed, sw,
                                                                "Invalid dimensionless rating value [" + myRatings[string.Empty].Value + "].");
                                                    }

                                                    if (!myRatings.TryGetValue(dimension.ID, out var dimensionRating))
                                                    {
                                                        results[BroadcastTest.GetMessage] =
                                                            new TestResult(TestResultStatus.Failed, sw,
                                                                "No dimension rating returned.");
                                                    }
                                                    else if (dimensionRating.Value != 5)
                                                    {
                                                        results[BroadcastTest.GetMessage] =
                                                            new TestResult(TestResultStatus.Failed, sw,
                                                                "Invalid dimension rating value [" + myRatings[string.Empty].Value + "].");
                                                    }
                                                }
                                            }

                                            // DELETE PLAYER
                                            authService.DeletePlayer(player.ID);
                                        }
                                    }

                                    // DELETE MESSAGE
                                    {
                                        sw.Restart();
                                        var result = service.DeleteMessage(message.ID);
                                        results[BroadcastTest.DeleteMessage] = new TestResult(result, sw);
                                    }
                                }
                            }
                        }

                        // DELETE RATING DIMENSION
                        {
                            sw.Restart();
                            var result = service.DeleteRatingDimension(channel.ID, dimension.ID);
                            results[BroadcastTest.DeleteRatingDimension] = new TestResult(result, sw);
                        }
                    }
                }

                // DELETE CHANNEL
                {
                    sw.Restart();
                    var result = service.DeleteChannel(channel.ID);
                    results[BroadcastTest.DeleteChannel] = new TestResult(result, sw);
                }
            }
        }

        var tests = Extensions.ToList<BroadcastTest>();
        foreach (var test in tests.Where(test => !results.ContainsKey(test)))
        {
            results[test] = new TestResult();
        }
        return results
            .OrderBy(c=> (int)c.Key)
            .Select(c=> 
                new Tuple<string, TestResult>(c.Key.ToString(), c.Value)
            )
            .ToList();
    }
}