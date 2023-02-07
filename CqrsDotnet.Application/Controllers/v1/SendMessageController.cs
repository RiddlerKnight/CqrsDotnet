using CqrsDotnet.Application.Aggregators;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDotnet.Application.Controllers.v1;

[ApiVersion("1")]
[Route("[controller]")]
public class SendMessageController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] SendMessageCommand command)
    {
        var result = await Mediator.Send(command);
        return result;
    }
}