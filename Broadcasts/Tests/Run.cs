using ConstructServices.Broadcasts.Actions;
using ConstructServices.Common;
using ConstructServices.Common.Tests;
using ConstructServices.Ratings.Actions;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        CreateMessage,
        ListMessages,
        GetMessage,
        UpdateMessage,
        DeleteMessage,

        DeleteRatingDimension,
        DeleteChannel
    }

    [UsedImplicitly]
    public static Dictionary<string, TestResult> RunTests(Guid gameID, SecretAPIKey apiKey)
    {
        var results = new Dictionary<string, TestResult>();
        var service = new BroadcastService(gameID, apiKey);
        
        var sw = new Stopwatch();
        sw.Start();

        // Channels
        {
            var createResult = service.CreateChannel(new Channels.CreateChannelOptions("Test")
            {
                Description = "Test description",
                LanguageISO = "de",
                AllowRatings = true
            });
            results[nameof(BroadcastTest.CreateChannel)] = new TestResult(createResult, sw);
            if (createResult.Success)
            {
                var channel = createResult.Channel;

                {
                    sw.Restart();
                    var result = service.ListChannels();
                    results[nameof(BroadcastTest.ListChannels)] = new TestResult(result, sw);
                    if (result.Success && result.Channels.All(c => c.ID != channel.ID))
                    {
                        results[nameof(BroadcastTest.ListChannels)] = new TestResult(TestResultStatus.Failed, sw, "Channel not found.");
                    }
                }

                {
                    sw.Restart();
                    var result = service.GetChannel(channel.ID);
                    results[nameof(BroadcastTest.GetChannel)] = new TestResult(result, sw);
                }

                {
                    sw.Restart();
                    var result = service.UpdateChannel(channel.ID, new Channels.UpdateChannelOptions{Name = "New name"});
                    results[nameof(BroadcastTest.UpdateChannel)] = new TestResult(result, sw);
                }

                {
                    sw.Restart();
                    var createDimensionResult = service.CreateRatingDimension(
                        new Dimensions.CreateBroadcastChannelRatingDimensionOptions(channel.ID, 100, "dimension",
                            "Title", "Description"));
                    results[nameof(BroadcastTest.CreateRatingDimension)] = new TestResult(createDimensionResult, sw);

                    if (createDimensionResult.Success)
                    {
                        var dimension = createDimensionResult.Dimension;
                        const string testLangCode = "RU";
                        {
                            sw.Restart();
                            var result = service.UpdateRatingDimension(channel.ID, dimension.ID,
                                new Dimensions.UpdateChannelRatingDimensionOptions
                                    { Description = "Longer description", LanguageISO = testLangCode});
                            results[nameof(BroadcastTest.EditRatingDimension)] = new TestResult(result, sw);
                        }

                        {
                            sw.Restart();
                            var result = service.ListRatingDimensions(new Dimensions.ListBroadcastChannelDimensionOptions(channel.ID));
                            results[nameof(BroadcastTest.GetRatingDimensions)] = new TestResult(result, sw);

                            var d = result.Dimensions.FirstOrDefault(d => d.ID == dimension.ID);
                            if (d != null && !d.OriginalLanguage.ISO.Equals(testLangCode, StringComparison.CurrentCultureIgnoreCase))
                            {
                                results[nameof(BroadcastTest.GetRatingDimensions)] = new TestResult(TestResultStatus.Failed, sw, "Language mismatch.");
                            }
                        }

                        // Messages
                        {
                            {
                                sw.Restart();
                                var createMessageResult =  service.CreateMessage(new Messages.CreateMessageOptions(channel.ID, "Test")
                                {
                                    Title = "My title"
                                });
                                results[nameof(BroadcastTest.CreateMessage)] = new TestResult(createMessageResult, sw);

                                if (createMessageResult.Success)
                                {
                                    var message = createMessageResult.Message;

                                    {
                                        sw.Restart();
                                        var result = service.ListMessages(channel.ID, new PaginationOptions(1, 20));
                                        results[nameof(BroadcastTest.ListMessages)] = new TestResult(result, sw);
                                        if (result.Success)
                                        {
                                            if (result.Messages.All(c => c.ID != message.ID))
                                            {
                                                results[nameof(BroadcastTest.ListMessages)] = new TestResult(TestResultStatus.Failed, sw, "Message not found.");
                                            }
                                        }
                                    }

                                    {
                                        sw.Restart();
                                        var result = service.GetMessage(message.ID);
                                        results[nameof(BroadcastTest.GetMessage)] = new TestResult(result, sw);
                                    }
                                    
                                    {
                                        sw.Restart();
                                        var result = service.UpdateMessage(message.ID, new Messages.UpdateMessageOptions
                                        {
                                            Text = "Another test string"
                                        });
                                        results[nameof(BroadcastTest.UpdateMessage)] = new TestResult(result, sw);
                                    }

                                    {
                                        sw.Restart();
                                        var result = service.DeleteMessage(message.ID);
                                        results[nameof(BroadcastTest.DeleteMessage)] = new TestResult(result, sw);
                                    }
                                }
                            }
                        }
                        {
                            sw.Restart();
                            var result = service.DeleteRatingDimension(new Dimensions.DeleteBroadcastChannelRatingDimensionOptions(channel.ID, dimension.ID));
                            results[nameof(BroadcastTest.DeleteRatingDimension)] = new TestResult(result, sw);
                        }
                    }
                }


                {
                    sw.Restart();
                    var result = service.DeleteChannel(channel.ID);
                    results[nameof(BroadcastTest.DeleteChannel)] = new TestResult(result, sw);
                }
            }
        }

        var testNames = Enum.GetNames(typeof(BroadcastTest));
        foreach (var testName in testNames)
        {
            if (!results.ContainsKey(testName))
            {
                results[testName] = new TestResult();
            }
        }
        return results;
    }
}