using Microsoft.EntityFrameworkCore;
using VA.Domain.Entities;


namespace VA.Infrastructure.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    
    public DbSet<OrderEntity> Orders { get; set; }
}