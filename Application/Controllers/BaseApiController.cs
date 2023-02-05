using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => (_mediator = HttpContext.RequestServices.GetService<IMediator>() 
                                                     ?? throw new InvalidOperationException()) 
                                        ?? throw new InvalidOperationException();

    }
}
