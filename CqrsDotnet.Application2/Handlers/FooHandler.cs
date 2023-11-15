using CqrsDotnet.Application2.Aggregators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CqrsDotnet.Application2.Handlers;

public class FooHandler : IRequestHandler<FooCommand, IActionResult>
{
    public async Task<IActionResult> Handle(FooCommand request, CancellationToken cancellationToken)
    {
        Log.Information("Ok 555 {Message}", "FooController");
        return new OkObjectResult("Foo");
    }
}