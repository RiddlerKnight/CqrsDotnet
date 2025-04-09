using CqrsDotnet.Application.Aggregators;
using CqrsDotnet.Domain.Models;
using CqrsDotnet.Persistence.DbContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CqrsDotnet.Application.Handlers;

public class TaskMessageSenderCommand : IRequestHandler<SendMessageCommand, IActionResult>
{
    private readonly IConfiguration _configuration;
    private readonly CoreDbContext _dbContext;

    public TaskMessageSenderCommand(IConfiguration configuration, CoreDbContext dbContext)
    {
        _configuration = configuration;
        _dbContext = dbContext;
    }
    public async Task<IActionResult> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        Log.Information("SendMessageCommand Running with message : \"{Message}\"", request.Message);
        return new JsonResult(new ResponseMessage($"received: {request.Message}"));
    }
}
