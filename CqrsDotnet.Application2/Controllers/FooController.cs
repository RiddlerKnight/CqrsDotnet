using CqrsDotnet.Application2.Aggregators;
using CqrsDotnet.Infrastructure.Bases;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDotnet.Application2.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class FooController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FooCommand command)
    {
        var result = await Mediator.Send(command);
        return result;
    }
    
    [HttpPost]
    [Route("CreateAbc")]
    public async Task<IActionResult> CreateAbc([FromQuery] string command)
    {
        return Ok(command);
    }
    
    [HttpPatch]
    [Route("UpdateAbc")]
    public async Task<IActionResult> UpdateAbc([FromQuery] string command)
    {
        return Ok(command);
    }
    
    [HttpPut]
    [Route("EditAbc")]
    public async Task<IActionResult> EditAbc([FromQuery] string command)
    {
        return Ok(command);
    }
}