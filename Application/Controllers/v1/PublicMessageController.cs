using System.Net;
using Application.Aggregators;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.v1;

[ApiVersion("1")]
[Route("[controller]")]
public class PublicMessageController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PublicMessageCommand command)
    {
        await Mediator.Publish(command);
        return StatusCode((int)HttpStatusCode.Accepted);
    }
}
