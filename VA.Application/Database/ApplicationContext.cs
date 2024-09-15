using Microsoft.EntityFrameworkCore;
using VA.Infrastructure.Entities;

namespace VA.Application.Database;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    
    public DbSet<OrderEntity> Orders { get; set; }
}
