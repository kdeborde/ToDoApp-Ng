
using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Services;
using ToDoApp.Core.Interfaces;
using ToDoApp.Infrastructure;
using ToDoApp.Infrastructure.Persistence;
using ToDoApp.Infrastructure.Repositories;

namespace ToDoApp.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //CORS
            builder.Services.AddCors();

            // Database
            builder.Services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // DI
            builder.Services.AddScoped<IToDoListRepository, ToDoListRepository>();
            builder.Services.AddScoped<IToDoListItemRepository, ToDoListItemRepository>();

            builder.Services.AddScoped<IToDoListService, ToDoListService>();
            builder.Services.AddScoped<IToDoListItemService, ToDoListItemService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                await Seed.SeedData(context);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // CORS
            app.UseCors(x => x.AllowAnyHeader().AllowAnyHeader().WithOrigins("http://localhost:4200", "https://localhost:4200"));

            app.MapControllers();

            app.Run();
        }
    }
}
