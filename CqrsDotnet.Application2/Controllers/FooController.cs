using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CqrsDotnet.Application2.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class FooController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string command)
    {
        Log.Information("Ok 555 {Message}", "FooController");
        return new OkObjectResult("foo");
    }
}