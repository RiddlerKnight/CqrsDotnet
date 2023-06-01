using CqrsDotnet.Application.Aggregators;
using CqrsDotnet.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CqrsDotnet.Application.Handlers;

public class TaskMessageSenderCommand : IRequestHandler<SendMessageCommand, IActionResult>
{
    public async Task<IActionResult> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        Log.Information("SendMessageCommand Running with message : \"{Message}\"", request.Message);
        return new JsonResult(new ResponseMessage($"received: {request.Message}"));
    }
}
