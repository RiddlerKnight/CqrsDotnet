using CqrsDotnet.Application.Aggregators;
using CqrsDotnet.Persistence.DbContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CqrsDotnet.Application.Handlers;

public class GetProductHandler : IRequestHandler<GetProductCommand, IActionResult>
{
    private readonly CoreDbContext _dbContext;

    public GetProductHandler(CoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IActionResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Products.Where(product => product.Name == request.Name ).ToListAsync();

        return new JsonResult(result);
    }
}