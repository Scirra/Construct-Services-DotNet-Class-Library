using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace ConstructServices.Notifications;

[UsedImplicitly]
public sealed class NotificationClient : IDisposable
{
    private ClientWebSocket _socket;
    private Guid GameID { get; }
    private SessionKey SessionKey { get; }
    private Action<WebsocketMessage> MessageHandler { get; }
    private Action<Exception> ErrorHandler { get; }
    
    public NotificationClient(Guid gameID, Action<WebsocketMessage> messageHandler, Action<Exception> errorHandler = null)
    {
        GameID = gameID;
        MessageHandler = messageHandler;
        ErrorHandler = errorHandler;
    }
    public NotificationClient(Guid gameID, SessionKey sessionKey, Action<WebsocketMessage> messageHandler, Action<Exception> errorHandler = null)
    {
        GameID = gameID;
        SessionKey = sessionKey;
        MessageHandler = messageHandler;
        ErrorHandler = errorHandler;
    }

    private Uri GetWSPath()
    {
        string root;
        if (GlobalConfig.DevMode)
            root = "wss://auth.constructdev.net/wshandler";
        else
            root = "wss://auth.construct.net/wshandler";
        return new Uri(root + "?gameID=" + GameID + "&sessionKey=" + HttpUtility.UrlEncode(SessionKey?.Key ?? string.Empty));
    }
    
    [UsedImplicitly]
    public async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        var socket = new ClientWebSocket();

        _socket?.Dispose();
        _socket = socket;

        try
        {
            await socket.ConnectAsync(GetWSPath(), cancellationToken);
            _ = ReceiveLoopAsync(socket, cancellationToken);
        }
        catch
        {
            socket.Dispose();

            if (ReferenceEquals(_socket, socket))
                _socket = null;

            throw;
        }
    }

    private async Task ReceiveLoopAsync(ClientWebSocket socket, CancellationToken cancellationToken)
    {
        var buffer = new byte[8192];

        try
        {
            while (socket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
            {
                var message = new StringBuilder();
                WebSocketReceiveResult result;

                do
                {
                    result = await socket.ReceiveAsync(
                        new ArraySegment<byte>(buffer),
                        cancellationToken
                    );

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        if (socket.State == WebSocketState.CloseReceived)
                        {
                            await socket.CloseOutputAsync(
                                WebSocketCloseStatus.NormalClosure,
                                "Closing",
                                CancellationToken.None
                            );
                        }

                        return;
                    }

                    if (result.MessageType != WebSocketMessageType.Text)
                        break;

                    message.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));

                } while (!result.EndOfMessage);
                
                if (message.Length > 0)
                    OnMessageReceived(message.ToString());
            }
        }
        catch (OperationCanceledException)
        {
            // Normal shutdown
        }
        catch (ObjectDisposedException)
        {
            // Normal shutdown
        }
        catch (Exception ex)
        {
            ErrorHandler?.Invoke(ex);
        }
    }

    public async Task CloseAsync(CancellationToken cancellationToken = default)
    {
        var socket = _socket;

        if (socket == null)
            return;

        try
        {
            if (socket.State == WebSocketState.Open ||
                socket.State == WebSocketState.CloseReceived)
            {
                await socket.CloseAsync(
                    WebSocketCloseStatus.NormalClosure,
                    "Client closing",
                    cancellationToken
                );
            }
        }
        finally
        {
            socket.Dispose();

            if (ReferenceEquals(_socket, socket))
                _socket = null;
        }
    }

    private void OnMessageReceived(string message)
    {
        if (MessageHandler == null)
            return;

        // Pings
        if (string.IsNullOrWhiteSpace(message))
            return;

        try
        {
            var json = JsonConvert.DeserializeObject<dynamic>(message);
            var typeStr = (string)json["type"];

            if (!Enum.TryParse<MessageType>(typeStr, true, out var type))
                return;

            switch (type)
            {
                case MessageType.NewBroadcastMessage:
                    MessageHandler.Invoke(JsonConvert.DeserializeObject<NewBroadcastWebsocketMessage>(message));
                    break;

                case MessageType.AchievementAwarded:
                    MessageHandler.Invoke(JsonConvert.DeserializeObject<AchievementAwardedWebsocketMessage>(message));
                    break;

                case MessageType.XPChanged:
                    MessageHandler.Invoke(JsonConvert.DeserializeObject<XPChangedWebsocketMessage>(message));
                    break;

                case MessageType.XPRankChanged:
                    MessageHandler.Invoke(JsonConvert.DeserializeObject<XPRankChangedWebsocketMessage>(message));
                    break;
                default:
                    return;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler?.Invoke(ex);
        }
    }

    public void Dispose()
    {
        _socket?.Dispose();
        _socket = null;
    }
}