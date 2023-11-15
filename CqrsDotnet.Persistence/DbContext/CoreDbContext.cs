using CqrsDotnet.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CqrsDotnet.Persistence.DbContext;

public partial class CoreDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public CoreDbContext(Microsoft.EntityFrameworkCore.DbContextOptions option) : base(option)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    
    public virtual DbSet<Product> Products { get; set; }
}