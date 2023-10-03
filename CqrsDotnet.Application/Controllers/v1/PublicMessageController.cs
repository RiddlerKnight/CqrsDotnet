using System.Net;
using CqrsDotnet.Application.Aggregators;
using CqrsDotnet.Infrastructure.Bases;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDotnet.Application.Controllers.v1;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PublicMessageController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PublicMessageCommand command)
    {
        await Mediator.Publish(command);
        return StatusCode((int)HttpStatusCode.Accepted);
    }
}
