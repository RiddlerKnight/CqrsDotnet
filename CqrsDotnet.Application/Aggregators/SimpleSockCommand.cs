using System.Net.WebSockets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDotnet.Application.Aggregators;

public class SimpleSockCommand : IRequest {
    public WebSocket? WebSocket { get; set; }
}
