using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDotnet.Application2.Aggregators;

public class FooCommand : IRequest<IActionResult>
{
    public string Message { get; set; }
    public string Operator { get; set; }
}