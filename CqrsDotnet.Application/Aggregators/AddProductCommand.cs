using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDotnet.Application.Aggregators;

public class AddProductCommand : IRequest<IActionResult>
{
    public string Name { get; set; }
    public string Type { get; set; }
}