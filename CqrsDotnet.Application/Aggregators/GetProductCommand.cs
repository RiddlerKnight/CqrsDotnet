using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDotnet.Application.Aggregators;

public class GetProductCommand : IRequest<IActionResult>
{
    public string Name { get; set; }
}