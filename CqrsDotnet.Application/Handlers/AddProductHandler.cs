using CqrsDotnet.Application.Aggregators;
using CqrsDotnet.Domain.Models;
using CqrsDotnet.Persistence.DbContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDotnet.Application.Handlers;

public class AddProductHandler : IRequestHandler<AddProductCommand, IActionResult>
{
    private readonly CoreDbContext _dbContext;

    public AddProductHandler(CoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IActionResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product() { Name = request.Name, Type = request.Type };
        await _dbContext.Products.AddAsync(product, 
            cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new CreatedResult();
    }
}