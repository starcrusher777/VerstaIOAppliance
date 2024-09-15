using Microsoft.EntityFrameworkCore;
using VA.Domain.Interfaces;
using VA.Infrastructure.Data;

namespace VA.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddAuthorization();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<IOrderRepository>();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddAutoMapper(typeof(Program));
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
        
        app.Run();
    }
}