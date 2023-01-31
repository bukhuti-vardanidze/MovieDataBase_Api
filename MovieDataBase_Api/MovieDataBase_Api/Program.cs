using LinqToDB;
using Microsoft.EntityFrameworkCore;
using MovieDataBase_Api.Db;
using MovieDataBase_Api.Db.Entities;
using MovieDataBase_Api.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        var connection = builder.Configuration["AppDbContextConnection"];
        builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connection));

       builder.Services.AddTransient<IMovieRequestRepository, MovieRequestRepository>();

         builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();




        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}