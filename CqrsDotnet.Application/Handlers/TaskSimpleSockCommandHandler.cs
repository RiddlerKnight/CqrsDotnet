using System.Text;
using CqrsDotnet.Application.Aggregators;
using MediatR;
using Serilog;

namespace CqrsDotnet.Application.Handlers;

public class TaskSimpleSockCommandHandler : IRequestHandler<SimpleSockCommand>
{
    public async Task<Unit> Handle(SimpleSockCommand request, CancellationToken cancellationToken)
    {
        var buffer = new byte[1024 * 4];
        var connectionState = true;
        while (request.WebSocket != null && connectionState)
        {
            // Wait for receive Message
            var result = await request
                .WebSocket
                .ReceiveAsync(new ArraySegment<byte>(buffer), new CancellationToken())!;
            
            // Exit if client send close connection
            connectionState = !result.CloseStatus.HasValue;
            if (!connectionState) break;
            
            // Just log message
            var message = Encoding.UTF8.GetString(buffer, 0, buffer.TakeWhile(b => b != 0).Count());
            Log.Information("Data: {Data}", message);
            
            // Return Latest message
            var sendByte = Encoding.UTF8.GetBytes(message);
            await request.WebSocket
                .SendAsync(new ArraySegment<byte>(sendByte, 0, sendByte.Length), 
                    result.MessageType ,result.EndOfMessage  , cancellationToken);
        }

        return Unit.Value;
    }
}
