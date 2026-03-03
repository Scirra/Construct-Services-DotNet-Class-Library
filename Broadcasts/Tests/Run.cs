using ConstructServices.Common;
using ConstructServices.Common.Tests;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using ConstructServices.Broadcasts.Actions;
using ConstructServices.Ratings.Actions;

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

        // Channels
        {
            var createResult = service.CreateChannel(new Channels.CreateChannelOptions("Test", "My test channel", true));
            results[nameof(BroadcastTest.CreateChannel)] = new TestResult(createResult);
            if (createResult.Success)
            {
                var channel = createResult.Channel;

                {
                    var result = service.ListChannels();
                    results[nameof(BroadcastTest.ListChannels)] = new TestResult(result);
                    if (result.Success && result.Channels.All(c => c.ID != channel.ID))
                    {
                        results[nameof(BroadcastTest.ListChannels)] = new TestResult(TestResultStatus.Failed, "Channel not found.");
                    }
                }

                {
                    var result = service.GetChannel(new Channels.GetChannelOptions(channel.ID));
                    results[nameof(BroadcastTest.GetChannel)] = new TestResult(result);
                }

                {
                    var result = service.UpdateChannel(channel.ID, new Channels.UpdateChannelOptions{Name = "New name"});
                    results[nameof(BroadcastTest.UpdateChannel)] = new TestResult(result);
                }

                {
                    var createDimensionResult = service.CreateRatingDimension(
                        new Dimensions.CreateBroadcastChannelRatingDimensionOptions(channel.ID, 100, "dimension",
                            "Title", "Description"));
                    results[nameof(BroadcastTest.CreateRatingDimension)] = new TestResult(createDimensionResult);

                    if (createDimensionResult.Success)
                    {
                        var dimension = createDimensionResult.Dimension;
                        const string testLangCode = "RU";
                        {
                            var result = service.UpdateRatingDimension(channel.ID, dimension.ID,
                                new Dimensions.UpdateChannelRatingDimensionOptions
                                    { Description = "Longer description", LanguageISO = testLangCode});
                            results[nameof(BroadcastTest.EditRatingDimension)] = new TestResult(result);
                        }

                        {
                            var result = service.ListRatingDimensions(new Dimensions.ListBroadcastChannelDimensionOptions(channel.ID));
                            results[nameof(BroadcastTest.GetRatingDimensions)] = new TestResult(result);

                            var d = result.Dimensions.FirstOrDefault(d => d.ID == dimension.ID);
                            if (d != null && !d.OriginalLanguage.ISO.Equals(testLangCode, StringComparison.CurrentCultureIgnoreCase))
                            {
                                results[nameof(BroadcastTest.GetRatingDimensions)] = new TestResult(TestResultStatus.Failed, "Language mismatch.");
                            }
                        }

                        // Messages
                        {
                            {
                                var createMessageResult =  service.CreateMessage(new Messages.CreateMessageOptions(channel, "Test", "My test message"));
                                results[nameof(BroadcastTest.CreateMessage)] = new TestResult(createMessageResult);

                                if (createMessageResult.Success)
                                {
                                    var message = createMessageResult.Message;

                                    {
                                        var result = service.ListMessages(new Messages.ListMessagesOptions(channel.ID));
                                        results[nameof(BroadcastTest.ListMessages)] = new TestResult(result);
                                        if (result.Success)
                                        {
                                            if (result.Messages.All(c => c.ID != message.ID))
                                            {
                                                results[nameof(BroadcastTest.ListMessages)] = new TestResult(TestResultStatus.Failed, "Message not found.");
                                            }
                                        }
                                    }

                                    {
                                        var result = service.GetMessage(new Messages.GetMessageOptions(message.ID));
                                        results[nameof(BroadcastTest.GetMessage)] = new TestResult(result);
                                    }
                                    
                                    {
                                        var result = service.UpdateMessage(message.ID, new Messages.UpdateMessageOptions
                                        {
                                            Text = "Another test string"
                                        });
                                        results[nameof(BroadcastTest.UpdateMessage)] = new TestResult(result);
                                    }

                                    {
                                        var result = service.DeleteMessage(message.ID);
                                        results[nameof(BroadcastTest.DeleteMessage)] = new TestResult(result);
                                    }
                                }
                            }
                        }
                        {
                            var result = service.DeleteRatingDimension(new Dimensions.DeleteBroadcastChannelRatingDimensionOptions(channel.ID, dimension.ID));
                            results[nameof(BroadcastTest.DeleteRatingDimension)] = new TestResult(result);
                        }
                    }
                }


                {
                    var result = service.DeleteChannel(channel.ID);
                    results[nameof(BroadcastTest.DeleteChannel)] = new TestResult(result);
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