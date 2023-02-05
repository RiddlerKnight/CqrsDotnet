using MediatR;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable CS8618

namespace Application.Aggregators;

public class SendMessageCommand : IRequest<IActionResult>
{

    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Message { get; set; }
}