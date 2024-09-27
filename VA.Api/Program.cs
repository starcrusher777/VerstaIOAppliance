using Microsoft.EntityFrameworkCore;
using VA.Application.Services;
using VA.Domain.Interfaces;
using VA.Infrastructure.Data;
using VA.Infrastructure.Mappings.Profiles;

namespace VA.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        
        builder.Services.AddAuthorization();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<OrderService>();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddHealthChecks().AddSqlServer(connectionString);
        builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowAnyOrigin");
        }
        

        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapHealthChecks("/health");
        
        app.Run();
    }
}