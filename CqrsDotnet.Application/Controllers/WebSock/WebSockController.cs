using CqrsDotnet.Application.Aggregators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CqrsDotnet.Application.Controllers.WebSock;

/// <summary>
/// Init WebSock
/// </summary>
public class WebSockController : ControllerBase
{
    private IMediator? _mediator;

    private IMediator Mediator => (_mediator = HttpContext.RequestServices.GetService<IMediator>() 
                                               ?? throw new InvalidOperationException()) 
                                  ?? throw new InvalidOperationException();
    
    /// <summary>
    /// Route for websocket
    /// </summary>
    [HttpGet]
    [Route("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            Log.Information("=== Open WebSocket connection ===");
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await Mediator.Send(new SimpleSockCommand{ WebSocket = webSocket});
        }
    }
}
