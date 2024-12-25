using DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using BuisnessLogic.Interfaces;
using BuisnessLogic.Services;
using Microsoft.Extensions.Logging;

namespace APILayer
{

    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddContext(connectionString);

            builder.Services.AddRepositories();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            // Ensure database is created and apply migrations
            app.Run();
        }
    }
}
