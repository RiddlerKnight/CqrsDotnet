using CqrsDotnet.Application.Aggregators;
using CqrsDotnet.Infrastructure.Bases;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDotnet.Application.Controllers.v1;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SendMessageController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] SendMessageCommand command)
    {
        var result = await Mediator.Send(command);
        return result;
    }
}
