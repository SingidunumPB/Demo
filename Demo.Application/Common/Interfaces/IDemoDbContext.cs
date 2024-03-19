using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Common.Interfaces;

public interface IDemoDbContext
{
    public DbSet<Product> Products { get; }
    public DbSet<Company> Companies { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}