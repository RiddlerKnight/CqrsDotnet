using System.Net;
using Application.Aggregators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Application.Handlers;

public class TaskMessageSenderCommand : IRequestHandler<SendMessageCommand, IActionResult>
{
    public async Task<IActionResult> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        Log.Information("SendMessageCommand Running with message : \"{Message}\"", request.Message);
        return new StatusCodeResult((int)HttpStatusCode.Accepted);
    }
}