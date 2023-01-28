using LinqToDB;
using Microsoft.EntityFrameworkCore;
using MovieDataBase_Api.Db;
using MovieDataBase_Api.Db.Entities;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContextConnection")));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //builder.Services.AddDbContextPool<AppDbContext>(c =>
        //    c.UseSqlServer(builder.Configuration["AppDbContextConnection"]));
        //builder.Services.AddDbContext<AppDbContext>();


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