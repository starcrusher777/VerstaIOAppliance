using Microsoft.EntityFrameworkCore;
using VerstaIOAppliance.Entities;

namespace VerstaIOAppliance;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<OrderEntity> Orders { get; set; }
}