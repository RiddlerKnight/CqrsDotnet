using CqrsDotnet.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CqrsDotnet.Domain.EntityConfigs;

public class ProductEntityConfig : BaseEntityConfig<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
    }
}